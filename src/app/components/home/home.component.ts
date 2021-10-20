import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from './interfaces/user';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  userLogged!: User;
  availableUsers: User[] = [
    { userId: 1001, name: 'Iván', lastname: 'Miranda Stavenuiter', email: 'ivanmist90@gmail.com' },
    { userId: 1002, name: 'GCAdmin', lastname: 'gc-admin', email: 'gc-admin@gmail.com' },
  ];

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

}
