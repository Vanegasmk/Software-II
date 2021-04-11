import { Component, OnInit, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from "@angular/common/http";


@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent{

  product: any;
  
  public id:number;

  constructor(private ActivatedRoute: ActivatedRoute,public http: HttpClient,@Inject("BASE_URL") public baseUrl: string) { 

    this.getProductId();
    this.getProduct()
    
  }

  getProductId() {
    this.ActivatedRoute.paramMap.subscribe(param => {
      this.id = parseInt(param.get('id'));
    });
  }

  getProduct() { // Remove room from database
    console.log(this.id)
    this.http.get(this.baseUrl + "api/product/" + this.id).subscribe(
      (result) => {
        this.product = result;
        console.log(this.product);
      },
      (error) => console.error(error)
    );
  }
  

}
