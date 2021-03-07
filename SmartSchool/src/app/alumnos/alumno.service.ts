import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Alumno } from '../models/alumno';

@Injectable({
  providedIn: 'root'
})
export class AlumnoService {

  baseUrl =  `${environment.mainUrl}/api/alumno`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Alumno[]>{
    return this.http.get<Alumno[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Alumno>{
    return this.http.get<Alumno>(`${this.baseUrl}/${id}`);
  }

  post(alumno: Alumno){
    return this.http.post(`${this.baseUrl}`,alumno);
  }

  put(alumno: Alumno){
    return this.http.put(`${this.baseUrl}/${alumno.id}`,alumno);
  }

  delete(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
