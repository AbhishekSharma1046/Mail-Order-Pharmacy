


//This code
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Refill } from '../refill';
import { Injectable } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AuthService } from '../service/auth.service';
import { RefillDue } from '../refill-details';
import { DrugDetails } from '../drug-details';

@Component({
  selector: 'app-refilldues',
  templateUrl: './refilldues.component.html',
  styleUrls: ['./refilldues.component.css'],
})
export class RefillduesComponent implements OnInit {
  n: any;
  Ref: any = [];
  dowehaveatoken: boolean = false;
  Id: number = 0;
  u:boolean=false;
  refi:any
  // https://refillapi20220708115116.azurewebsites.net/
  apiurl =
    'https://localhost:44365/api/RefillOrders/RefillDues/';
  constructor(private http: HttpClient) {
    this.dowehaveatoken = localStorage.getItem('token1') != null;
    console.log(this.dowehaveatoken);
    if (this.dowehaveatoken) {
      console.log('Token valid');
    } else {
      console.log('Token Invalid');
    }
    this.u=false;
  }
  getvalue(val: any) {
    this.Id = val;
  }

  private setHeaders(): HttpHeaders {
    console.log(localStorage.getItem('token1'));
    let token = localStorage.getItem('token1');
    const headersConfig: any = {
      'Access-Control-Allow-Origin': 'http://localhost:4200/',
      'Content-Type': 'application/json',
      Accept: 'application/json',
    };
    if (token) {
      headersConfig.authorization = `Bearer ${token}`;
    }
    return new HttpHeaders(headersConfig);
  }
  ProceedWithSearch() {
    //validation done
    if (this.dowehaveatoken) {
      this.Ref = [];
      this.u=false;

      let finalurl = this.apiurl + this.Id;
      console.log(finalurl);
      let header = this.setHeaders();
      return this.http.get(finalurl, { headers: header }).subscribe((res) => {
        //this.n = res;
        //console.log(this.res[0].Payment);
        this.refi=res as Refill [];
        console.log(this.refi);
        if(this.refi.payment){
          this.n = 'Due Cleared';
        }else {
          this.n = 'Due not Cleared';
        } 
        console.log(this.refi.payment);
        if(this.refi.id==0){
          this.u=true;
          this.n =" "
        }
       
       /*
        if(this.refi.payment){
          this.n = 'Due Cleared';
        }else {
          this.n = 'Due not Cleared';
        } 
     */
        this.Ref.push(res);
       
      });
    }

    return null;
    //just have to show data
  }

  ngOnInit(): void {
    
    
  }
}
