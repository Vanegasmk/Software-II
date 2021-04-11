import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from "@angular/common/http";



const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {

  form: any = {
    name: null,
    firstSurname: null,
    lastSurname: null,
    email: null,
    password: null,
    phone: null,
    address: null
  };
  



  constructor(public http: HttpClient, @Inject("BASE_URL") public baseUrl: string, private router: Router) { }

  ngOnInit(): void {
  }


  postUser() {

    const { name, email, password, firstSurname, lastSurname, phone, address} = this.form;
    var signupinfo = {
      "name":name,
      "email":email,
      "password":password,
      "firstSurname": firstSurname,
      "lastSurname": lastSurname,
      "phone": phone,
      "address": address
    }

    this.http.post(this.baseUrl + "api/user/register", signupinfo, httpOptions).subscribe(
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
