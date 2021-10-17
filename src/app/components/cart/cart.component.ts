import { Component, OnInit } from '@angular/core';
import { Product } from '../home/interfaces/product';
import productsMockData from '../home/mock/mock-product-data.json';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  products: Product[] = productsMockData as Product[];
  totalPrice!: number;

  constructor() { }

  ngOnInit(): void {
  }

  priceEmitter(totalPrice: number) {
    this.totalPrice = totalPrice;
  }

}
