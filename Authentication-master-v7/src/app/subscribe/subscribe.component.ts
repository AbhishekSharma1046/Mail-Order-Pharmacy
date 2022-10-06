import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHandler,HttpHeaders } from '@angular/common/http';
import { Subdetail } from '../subdetail';

@Component({
  selector: 'app-subscribe',
  templateUrl: './subscribe.component.html',
  styleUrls: ['./subscribe.component.css']
})
export class SubscribeComponent implements OnInit {

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }
  
  Login = new FormGroup({
    id: new FormControl(0),
    insurancePolicyNumber: new FormControl(""),
    insuranceProvider : new FormControl(""),
    prescriptionDate : new FormControl("2022-07-23T21:23:07.073Z"),
    DrugName : new FormControl("", Validators.required),
    doctorName: new FormControl(""), 
    refillOccurrence : new FormControl("")
  
 
  });
  obj:any;
  id:any;
  date:any;
  tr:any=false;
  
  
  private setHeaders(): HttpHeaders {
    console.log(localStorage.getItem('token1'));
    let Authorization = localStorage.getItem('token1');
    const headersConfig: any = {
      'Access-Control-Allow-Origin': 'http://localhost:4200/',
      'Content-Type': 'application/json',
      Accept: 'application/json',
    };
    if (Authorization) {
      headersConfig.authorization = `Bearer ${Authorization}`;
    }
    return new HttpHeaders(headersConfig);
  }

  submit(){
      let header = this.setHeaders();
    this.http.post('https://localhost:44345/api/Subscribe/PostSubscribe/Po/5',this.Login.value,{ headers: header }).subscribe(
      (result) => {
       // console.log("result");
       alert("Welcome To Application")
        if(result){

        
          console.log(result);
      
          this.tr=result;
        
        }
      },
      (error) => { 
       // console.log(result);
        console.log("eeerrrrr");
      }
    );
 }


}
