import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Profesor } from '../models/profesor';

@Injectable({
  providedIn: 'root'
})
export class ProfesorService {

  baseUrl =  `${environment.mainUrl}/api/profesor`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Profesor[]>{
    return this.http.get<Profesor[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Profesor>{
    return this.http.get<Profesor>(`${this.baseUrl}/${id}`);
  }

  post(profesor: Profesor){
    return this.http.post(`${this.baseUrl}`,profesor);
  }

  put(profesor: Profesor){
    return this.http.put(`${this.baseUrl}/${profesor.id}`,profesor);
  }

  delete(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
