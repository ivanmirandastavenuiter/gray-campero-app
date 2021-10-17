import { Component, OnInit } from '@angular/core';
import { Product } from './interfaces/product';
import productsMockData from './mock/mock-product-data.json';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  products: Product[] = productsMockData as Product[];

  constructor() {
  }

  ngOnInit(): void {
  }

}
