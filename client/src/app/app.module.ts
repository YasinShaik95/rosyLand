import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShopAllComponent } from './shop-all/shop-all.component';
import { Router, RouterModule } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FooterComponent } from './footer/footer.component';
import { HomepageComponent } from './homepage/homepage.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AdminMangeuserComponent } from './admin-mangeuser/admin-mangeuser.component';

@NgModule({
  declarations: [
    AppComponent,
    ShopAllComponent,
    NavbarComponent,
    SidebarComponent,
    FooterComponent,
    HomepageComponent,
    LoginComponent,
    RegisterComponent,
    AdminMangeuserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path:'shopAll',component:ShopAllComponent },
      { path: 'home', component: HomepageComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: LoginComponent },
      { path: 'manageUsers', component:AdminMangeuserComponent }
    ]),
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
