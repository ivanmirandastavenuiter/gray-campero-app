import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Product } from 'src/app/components/home/interfaces/product';
import axios from 'axios';
import { Cart } from 'src/app/components/home/interfaces/cart';
import { User } from 'src/app/components/home/interfaces/user';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {

  @Input() userLogged!: User;
  private _products!: Product[];
  public get products(): Product[] {
    return this._products;
  }
  public set products(value: Product[]) {
    this._products = value;
  }
  cartlines!: any[];
  cartProducts!: Cart[];
  totalPrice!: number;
  isLoaded: boolean = false;
  @Output() priceEmitter = new EventEmitter<number>();
  @Output() dtoEmitter = new EventEmitter<any[]>();
  @Output() showEmitter = new EventEmitter<boolean>();

  constructor() { }

  async ngOnInit(): Promise<void> {
    await this.getCartForLoggedUser();
    this.setProductsList();
    this.balanceStockBeforeCheckout();
    this.calculateTotalPrice();
    this.updateCart();
  }

  incrementQuantity(id: number) {
    const selectedProduct = this.products.find(p => p.productId == id);
    
    if (selectedProduct && selectedProduct.stock && selectedProduct.stock > 0) {
      const productIndex = this.products.findIndex(p => p.productId == selectedProduct.productId);
      this.products[productIndex].currentQuantity++;
      this.products[productIndex].stock--;
    }

    this.calculateTotalPrice();
    this.updateCart();
  }

  decrementQuantity(id: number) {
    const selectedProduct = this.products.find(p => p.productId == id);

    if (selectedProduct && selectedProduct.currentQuantity > 0) {
      const productIndex = this.products.findIndex(p => p.productId == selectedProduct.productId);
      this.products[productIndex].currentQuantity--;
      this.products[productIndex].stock++;
    }

    this.calculateTotalPrice();
    this.updateCart();
  }

  calculateTotalPrice() {
    if (this.products.length > 0) {
      this.totalPrice = this.products.map(p => p.price * p.currentQuantity)
                            .reduce((acc, price) => acc + price);
      this.priceEmitter.emit(this.totalPrice);
    }
  }

  async removeCartItem(id: number) {
    const url = 'http://localhost:5000/gc-api/cart/';

    const cartId = this.cartlines[0].cartLines[0].cartId;

    const payload: any = {
      CartId: cartId,
      UserId: this.userLogged.userId,
      ProductId: id
    }

    let res = await axios.delete(url, { data: payload });
    console.log(`Obtained response from server: ${res}`);

    // Remove item deleted
    this.products = this.products.filter(p => p.productId !== id);
    // And to re render prices and checkout button to be hidden
    this.updateCart();
    
  }

  async getCartForLoggedUser() {
    const url = 'http://localhost:5000/gc-api/cart/';

    const serverResponse = await axios.get(url + this.userLogged.userId);
    const cartlines = serverResponse.data;
    this.cartlines = cartlines as any[];
    this.isLoaded = true;
  }

  setProductsList() {
    if (this.cartlines.length > 0) {
      let products: Product[] = this.cartlines[0].products;
      products = products.map(p => {
        const productCartLine = (this.cartlines[0].cartLines as Cart[]).find(c => c.productId == p.productId);
        p.currentQuantity = productCartLine!.quantity;
        return p;
      });
      this.products = products;
    } else {
      this.products = [];
    }

  }

  balanceStockBeforeCheckout() {
    if (this.cartlines.length > 0) {
      const productIdsFromCart = (this.cartlines[0].products as Product[]).map(p => p.productId);
      const productIdsAndQuantitiesInCart = productIdsFromCart.map(productId => {
        const cartLine = (this.cartlines[0].cartLines as Cart[]).find(c => c.productId == productId);
        return {
          productId: productId,
          quantityToUpdate: cartLine?.quantity
        }
      });
      this.products = this.products.map(p => {
        const matchedProduct = productIdsAndQuantitiesInCart.find(productFromCart => productFromCart.productId == p.productId);
        if (matchedProduct && matchedProduct.quantityToUpdate) {
          p.stock = p.stock - matchedProduct.quantityToUpdate;
        }
        return p;
      });
    }

  }

  async updateCart() {
    const inputUpdateDtos: any = [];
    const _this = this;
    if (this.products.length) {
      this.products.forEach(p => {  
        inputUpdateDtos.push(_this.getInputDtoForCartUpdate(p.productId, this.userLogged.userId, p.currentQuantity))
      });
      this.dtoEmitter.emit(inputUpdateDtos);
      this.showEmitter.emit(true);
    } else {
      this.dtoEmitter.emit(undefined);
      this.showEmitter.emit(false);
    }

  }

  getInputDtoForCartUpdate(productId: number, userId: number, quantityToUpdate: number) {

    // A cart already exists
    if (this.cartlines.length > 0) {
      const cartId = this.cartlines[0].cartLines[0].cartId;

      const totalAmout = quantityToUpdate;
      const payload = {
        CartId: cartId,
        UserId: userId,
        ProductId: productId,
        QuantityToUpdate: totalAmout
      }

      return payload;
    } 
    return null;
  }



}
