import { AfterViewInit, Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import axios from 'axios';
import { User } from 'src/app/components/home/interfaces/user';

@Component({
  selector: 'app-cart-navbar',
  templateUrl: './cart-navbar.component.html',
  styleUrls: ['./cart-navbar.component.css']
})
export class CartNavbarComponent implements OnInit, AfterViewInit {

  @Input() userLogged!: User;
  @Input() totalPrice!: number;
  @Input() inputUpdateDtos!: any[];
  @Input() show!: boolean;

  constructor(private router: Router) {
  }

  ngOnInit(): void {
  }

  ngAfterViewInit() {
  }

  async confirmCheckout(event: any) {
    this.setSpinner(event);
  }

  async updateBeforeCheckout() {
    const url = 'http://localhost:5000/gc-api/cart/';

    for (const inputUpdateDto of this.inputUpdateDtos) {
      let res = await axios.patch(url, inputUpdateDto);
      console.log(`Obtained response from server: ${res}`);
    }
  }

  async setSpinner(event: any) {
    const spinner = event.target.parentElement.children[1];
    spinner.style.display = 'inline';
    setTimeout(async () => {
      await this.updateBeforeCheckout();

      const url = 'http://localhost:5000/gc-api/cart/';
      let res = await axios.post(url + this.userLogged.userId);
      console.log(`Obtained response from server: ${res}`);
      spinner.style.display = 'none';
      localStorage.setItem('checkout', 'done');
      this.router.navigate(['/home']);
    }, 3000);
  }

}
