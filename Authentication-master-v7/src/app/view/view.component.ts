import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'

import { Dlist } from '../dlist';


@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  urll='https://localhost:44393/api/DrugsApi/getdrug';
  dlist: any = [];

  constructor(private http: HttpClient) { 
  
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


  gett(){
    this.dlist = [];
    let header = this.setHeaders();
    this.http.get(this.urll ,{ headers: header }).subscribe((res) => {
      console.log(true);
      this.dlist = res as Dlist[];
      console.log(res);
      //this.y=true;
      // console.log();
    });
  }




  

  ngOnInit(): void {
    this.gett();
  }

}
