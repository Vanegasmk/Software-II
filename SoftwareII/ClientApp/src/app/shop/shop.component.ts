import { Component, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Product } from "./product.interface";

@Component({
  selector: "app-shop",
  templateUrl: "./shop.component.html",
  styleUrls: ["./shop.component.css"]
})
export class ShopComponent {
  public products: Product[];

  constructor(
    public http: HttpClient,
    @Inject("BASE_URL") public baseUrl: string) 
  {
    this.getProducts();
  }

  getProducts() {
    this.http.get<Product[]>(this.baseUrl + "api/product").subscribe(
      result => {
        this.products = result;
      },
      error => {
        console.log(error);
      }
    );
  }

  getProductsFilter(category:string) {
    this.http.get<Product[]>(this.baseUrl + "api/product/" + category + "/filter").subscribe(
      result => {
        this.products = result;
      },error => {
        console.log(error);
      }
    );
  }



  
}
