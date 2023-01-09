import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AppService {

  constructor(
    private http: HttpClient
  ) { }

  getAll(): Observable<any> {
    return this.http.get('https://localhost:7100/api/Employee/GetAll');
  }

  getDetail(id: any) {
    return this.http.get('https://localhost:7100/api/Employee/GetById?id=' + id);
  }
}