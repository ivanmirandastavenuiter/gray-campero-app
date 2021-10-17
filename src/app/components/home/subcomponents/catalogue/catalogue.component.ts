import { Component, Input, OnInit } from '@angular/core';
import { Product } from '../../interfaces/product';
import axios from 'axios';

@Component({
  selector: 'app-catalogue',
  templateUrl: './catalogue.component.html',
  styleUrls: ['./catalogue.component.css']
})
export class CatalogueComponent implements OnInit {

  @Input() products!: Product[];
  chunks!: any[];

  constructor() {
  }

  ngOnInit(): void {
    this.setInitialQuantity();
    this.setChunks(this.products);
  }

  setInitialQuantity() {
    this.products = this.products.map(p => {
      p.currentQuantity = 0;
      return p;
    });
  }

  setChunks(products: Product[]) {
    this.chunks = [];
    const splitAt = 4;
    const iterations = this.products.length;
    for (let i = 0; i < iterations; i += 4) {
      this.chunks.push(this.products.slice(i, i + 4));
    }
  }

  incrementQuantity(id: number) {
    const selectedProduct = this.products.find(p => p.id == id);
    
    if (selectedProduct && selectedProduct.stock && selectedProduct.stock > 0) {
      const productIndex = this.products.findIndex(p => p.id == selectedProduct.id);
      this.products[productIndex].currentQuantity++;
      this.products[productIndex].stock--;
      this.setChunks(this.products);
    }
  }

  decrementQuantity(id: number) {
    const selectedProduct = this.products.find(p => p.id == id);

    if (selectedProduct && selectedProduct.currentQuantity > 0) {
      const productIndex = this.products.findIndex(p => p.id == selectedProduct.id);
      this.products[productIndex].currentQuantity--;
      this.products[productIndex].stock++;
      this.setChunks(this.products);
    }
  }

  async updateCart(id: number) {
    // We would need here the user id and the product to update the cart
    const selectedProduct = this.products.find(p => p.id == id);
    
    if (selectedProduct && selectedProduct.currentQuantity) {
      const url = 'https://localhost:5001/gc-api/cart/' + selectedProduct.id;
      const body = {
        // To be defined
      }
      let res = await axios.patch(url, body);
      console.log(`Obtained response from server: ${res}`);
    }
  }

}
