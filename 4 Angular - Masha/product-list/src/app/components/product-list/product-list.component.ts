import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import Product from 'src/app/model/product.model';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {
  product?: Product;
  productList: Product[] = []

  constructor(private productService: ProductService) {
    this.productService.get().subscribe((data) => {
      this.productList = data as Product[];
    })
  }

  onDelete(id: number) { //purchase product
    this.productService.delete(id).subscribe((data) => {
      this.productList = this.productList.filter(item => item.id != id);
    })
  }

  sortPrice() {
    if (this.productList && this.productList.length) {
      this.productList.sort((a, b) => a.price - b.price);
    }
  }

  sortDate() {
    try {
      if (this.productList && this.productList.length) {
        this.productList.sort((a, b) => new Date(b.publish).getTime() - new Date(a.publish).getTime());
      }
    } catch (error) {
      console.error(error);
    }
  }
}
