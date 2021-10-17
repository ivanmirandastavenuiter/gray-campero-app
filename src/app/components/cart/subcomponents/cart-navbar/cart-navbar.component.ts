import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart-navbar',
  templateUrl: './cart-navbar.component.html',
  styleUrls: ['./cart-navbar.component.css']
})
export class CartNavbarComponent implements OnInit {

  @Input() totalPrice!: number;

  constructor() { }

  ngOnInit(): void {
  }

  confirmCheckout() {
    // Aquí meter userid para confirmar el cart.
    // Cambiar todos los registros del carro con ese user id a CHECKED
  }

}
