import { Component } from '@angular/core';
import Product from 'src/app/model/product.model';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'create-new',
  templateUrl: './create-new.component.html',
  styleUrls: ['./create-new.component.css']
})
export class CreateNewComponent {
  products: Product[] = [];
  newProduct: Product = new Product();
  isError = false;
  isCompleted = false;
  formChecked = false;

  phoneNumberPattern = "^[0-9]{10}$";

  constructor(private productService: ProductService) {
    productService.get().subscribe({
      next: (data) => {
        this.products = data as Product[];
      },
      error: (error) => {
        this.isError = true;
      }
    })
  }

  addProduct() {
    this.productService.post(this.newProduct)
      .subscribe((newProduct) => {
        this.onSubmit();
        if (this.formChecked) {
          this.products.push(newProduct as Product);
          this.isCompleted = true;
          return newProduct;
        }
        return this.isError = true;
      })
  }

  onSubmit() {
    if (!this.newProduct.name) {
      alert('name is required'!)
      return;
    }
    if (!this.newProduct.description) {
      alert('description is required'!)
      return;
    }
    if (!this.newProduct.image) {
      alert('image is required'!)
      return;
    }
        if (!this.newProduct.price) {
      alert('price is required'!)
      return;
    }
        if (!this.newProduct.sellerPhone) {
      alert('phone number is required'!)
      return;
    }
        if (!this.newProduct.productLocation) {
      alert('location is required'!)
      return;
    }
    this.formChecked = true;
    return;
  }
}
