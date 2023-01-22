import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductComponent } from './components/product/product.component';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './components/home/home.component';
import { routing } from './routing';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { CreateNewComponent } from './components/create-new/create-new.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ProductComponent,
    HomeComponent,
    ProductDetailsComponent,
    CreateNewComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    routing
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
