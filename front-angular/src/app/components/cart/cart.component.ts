import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from '../home/interfaces/user';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  userLogged!: User;
  availableUsers: User[] = [
    { userId: 1001, name: 'Iván', lastname: 'Miranda Stavenuiter', email: 'ivanmist90@gmail.com' },
    { userId: 1002, name: 'GCAdmin', lastname: 'gc-admin', email: 'gc-admin@gmail.com' },
  ];

  totalPrice!: number;
  inputUpdateDtos!: any[];
  show!: boolean;

  constructor(private route: ActivatedRoute) { 
    this.route.queryParams.subscribe(params => {
      if (params['user']) {
        this.userLogged = this.availableUsers.find(u => u.userId == parseInt(params['user'])) as User;
      } else {
        this.userLogged = this.availableUsers[0];
      }
    });
  }

  ngOnInit(): void {
  }

  priceEmitter(totalPrice: number) {
    this.totalPrice = totalPrice;
  }

  showEmitter(show: boolean) {
    this.show = show;
  }

  dtoEmitter(inputUpdateDtos: any[]) {
    this.inputUpdateDtos = inputUpdateDtos;
  }

}
