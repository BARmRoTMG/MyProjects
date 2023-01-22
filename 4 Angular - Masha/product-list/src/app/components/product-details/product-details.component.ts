import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import Product from 'src/app/model/product.model';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent {
  productList: Product[]= []

  product?: Product;
  id: number=0;

  constructor(private route: ActivatedRoute, private productService: ProductService){
      this.route.params.subscribe((params)=>{

          this.id = Number(params["id"]);

          this.productService.getById(this.id).subscribe(data=>{
            this.product = data as Product;
          })

      })
  }

  onDelete(id: number){ //purchase product
    this.productService.delete(id).subscribe((data)=>{
      this.productList = this.productList.filter(item => item.id != id);
    })
}
}
