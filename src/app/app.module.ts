import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { CatalogueComponent } from './components/home/subcomponents/catalogue/catalogue.component';
import { FooterComponent } from './components/home/subcomponents/footer/footer.component';
import { LandingComponent } from './components/home/subcomponents/landing/landing.component';
import { NavbarComponent } from './components/home/subcomponents/navbar/navbar.component';
import { CartComponent } from './components/cart/cart.component';
import { CartHeaderComponent } from './components/cart/subcomponents/cart-header/cart-header.component';
import { CartItemComponent } from './components/cart/subcomponents/cart-item/cart-item.component';
import { CartNavbarComponent } from './components/cart/subcomponents/cart-navbar/cart-navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LandingComponent,
    CatalogueComponent,
    FooterComponent,
    HomeComponent,
    CartComponent,
    CartHeaderComponent,
    CartItemComponent,
    CartNavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
