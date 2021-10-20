import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Product } from '../../interfaces/product';
import axios from 'axios';
import { Cart } from '../../interfaces/cart';
import { User } from '../../interfaces/user';

@Component({
  selector: 'app-catalogue',
  templateUrl: './catalogue.component.html',
  styleUrls: ['./catalogue.component.css']
})
export class CatalogueComponent implements OnInit {

  @Input() userLogged!: User;
  products!: Product[];
  chunks!: any[];
  cartlines!: any[];
  isLoaded: boolean = false;
  @ViewChild('checkout') banner!: ElementRef;

  constructor() {
  }

  async ngOnInit(): Promise<void> {
    await this.getProducts();
    await this.getCartForLoggedUser();
    this.balanceStockBeforeCheckout();
    this.setInitialQuantity();
    this.setChunks();
  }

  ngAfterViewInit() {
    if (localStorage.getItem('checkout') && localStorage.getItem('checkout') === 'done') {
      this.banner.nativeElement.style.display = 'block';
      const _this = this;
      setTimeout(() => {
        _this.banner.nativeElement.style.display = 'none';
        localStorage.clear();
      }, 3000);
    }
  }

  setInitialQuantity() {
    if (this.products) {
      this.products = this.products.map(p => {
        p.currentQuantity = 0;
        p.disabled = p.stock == 0 ? true : false;
        return p;
      });
    }
  }

  setChunks() {
    this.chunks = [];
    const iterations = this.products.length;
    for (let i = 0; i < iterations; i += 4) {
      this.chunks.push(this.products.slice(i, i + 4));
    }
  }

  incrementQuantity(id: number) {
    const selectedProduct = this.products.find(p => p.productId == id);
    
    if (selectedProduct && selectedProduct.stock && selectedProduct.stock > 0) {
      const productIndex = this.products.findIndex(p => p.productId == selectedProduct.productId);
      this.products[productIndex].currentQuantity++;
      this.products[productIndex].stock--;
      this.setChunks();
    }
  }

  decrementQuantity(id: number) {
    const selectedProduct = this.products.find(p => p.productId == id);

    if (selectedProduct && selectedProduct.currentQuantity > 0) {
      const productIndex = this.products.findIndex(p => p.productId == selectedProduct.productId);
      this.products[productIndex].currentQuantity--;
      this.products[productIndex].stock++;
      this.setChunks();
    }
  }

  async upsertCart(event: any, id: number) {

    const selectedProduct = this.products.find(p => p.productId == id);

    if (selectedProduct && selectedProduct.currentQuantity) {
      const url = 'http://localhost:5000/gc-api/cart/';
      const inputUpdateDto = this.getInputDtoForCartUpdate(id, this.userLogged.userId, selectedProduct.currentQuantity);

      const productExistInCart = this.cartlines.length && (this.cartlines[0].products as Product[]).find(p => p.productId == id) != undefined;
      // Here decide if create or update
      if (productExistInCart) {
        let res = await axios.patch(url, inputUpdateDto);
        console.log(`[UPDATED]: Obtained response from server: ${res}`);
        this.showProductAddedMessage(event);
      } else {
        let res = await axios.post(url, inputUpdateDto);
        console.log(`[CREATED]: Obtained response from server: ${res}`);
        this.showProductAddedMessage(event);

        // We store the new created resource globally, so next is updated and not created
        await this.getCartForLoggedUser();
      }

    }
  }

  async getCartForLoggedUser() {
    const url = 'http://localhost:5000/gc-api/cart/';

    const serverResponse = await axios.get(url + this.userLogged.userId);
    const cartlines = serverResponse.data;
    this.cartlines = cartlines as any[];
  }

  async getProducts() {
    const url = 'http://localhost:5000/gc-api/products/';

    const serverResponse = await axios.get(url);
    const products = serverResponse.data;
    this.products = products as Product[];
    this.isLoaded = true;
  }

  getInputDtoForCartUpdate(productId: number, userId: number, quantityToUpdate: number) {

    // Product in cart existence check
    let productExistsInCart;
    if (this.cartlines.length > 0) {
      productExistsInCart = (this.cartlines[0].products as Product[]).find(p => p.productId == productId) != undefined;
    }
    // A cart already exists
    if (this.cartlines.length > 0 && productExistsInCart) {
      const cartId = this.cartlines[0].cartLines[0].cartId;
      const productFromCart = (this.cartlines[0].cartLines as Cart[]).find(c => c.productId == productId);

      const updatedProduct = this.products.find(p => p.productId == productId);

      if (updatedProduct && updatedProduct.stock == 0 && updatedProduct.disabled == false) {
        const index = this.products.findIndex(p => p.productId == updatedProduct.productId);
        this.products[index].disabled = true;
      }

      const totalAmount = productFromCart!.quantity + quantityToUpdate;
      const payload = {
        CartId: cartId,
        UserId: userId,
        ProductId: productId,
        QuantityToUpdate: totalAmount
      }

      return payload;
    } else {

      // Check if new product for existing cart, or new product for new cart
      return this.cartlines.length > 0 ?
      {
        CartId: this.cartlines[0].cartLines[0].cartId,
        UserId: userId,
        ProductId: productId,
        Quantity: quantityToUpdate
      } :
      {
        UserId: userId,
        ProductId: productId,
        Quantity: quantityToUpdate
      }

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

  getProductMessageElement(event: any) {
    const button = event.target;
    const mainParent = button.parentElement;
    const productMessageElement = mainParent.parentElement.children[mainParent.parentElement.children.length - 1];
    return productMessageElement;
  }

  showProductAddedMessage(event: any) {
    const productAddedMessage = this.getProductMessageElement(event);
    productAddedMessage.style.display = 'block';
    setTimeout(() => productAddedMessage.style.display = 'none', 3000);
  }

}
