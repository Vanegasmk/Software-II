import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from "@angular/common/http";



const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})


export class LoginComponent {

  form: any = {
    email: null,
    password: null
  };





  constructor(public http: HttpClient, @Inject("BASE_URL") public baseUrl: string, private router: Router) { }

  getUser() {

    const { email, password } = this.form;
    var authinfo = {
      "email": email,
      "password": password
    }


    this.http.post(this.baseUrl + "api/user/login", authinfo, httpOptions).subscribe(
      result => {
        console.log(result)
        this.redirectPage();
      }, error => {
        console.log(error);
      }
    );
  }

  redirectPage(): void {
    this.router.navigate(['/shop']);
  }



}
