import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Product } from 'src/app/components/home/interfaces/product';
import axios from 'axios';
import { Cart } from 'src/app/components/home/interfaces/cart';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {

  @Input() products!: Product[];
  @Output() priceEmitter = new EventEmitter<number>();
  cartProducts!: Cart[];
  totalPrice!: number;

  constructor() { }

  ngOnInit(): void {
    this.getCartProductsForUser(1001);
    this.setRandomProductsAndQuantities();
    this.calculateTotalPrice(this.products);
  }

  setRandomProductsAndQuantities() {
    this.products = this.products.map(p => {
      p.currentQuantity = Math.floor(Math.random() * 10);
      return p;
    });
    this.products = this.products.filter(p => Math.floor(Math.random() * 2) === 1);
  }

  incrementQuantity(id: number) {
    const selectedProduct = this.products.find(p => p.id == id);
    
    if (selectedProduct && selectedProduct.stock && selectedProduct.stock > 0) {
      const productIndex = this.products.findIndex(p => p.id == selectedProduct.id);
      this.products[productIndex].currentQuantity++;
      this.products[productIndex].stock--;
    }

    this.calculateTotalPrice(this.products);
  }

  decrementQuantity(id: number) {
    const selectedProduct = this.products.find(p => p.id == id);

    if (selectedProduct && selectedProduct.currentQuantity > 0) {
      const productIndex = this.products.findIndex(p => p.id == selectedProduct.id);
      this.products[productIndex].currentQuantity--;
      this.products[productIndex].stock++;
    }

    this.calculateTotalPrice(this.products);
  }

  calculateTotalPrice(products: Product[]) {
    this.totalPrice = this.products.map(p => p.price * p.currentQuantity)
                                   .reduce((acc, price) => acc + price);
    this.priceEmitter.emit(this.totalPrice);
  }

  removeCartItem(id: number) {
    console.log(id);
  }

  async getCartProductsForUser(id: number) {
    const url = 'https://localhost:5001/gc-api/cart/' + id;

    let res = await axios.get(url);
    console.log(`Obtained response from server: ${res}`);
  }

}
