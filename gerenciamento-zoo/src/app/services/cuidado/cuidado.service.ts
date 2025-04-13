import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Cuidado } from '../../models/cuidado';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CuidadoService {

  private api = environment.urlApi;

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<Cuidado[]> {
    return this.httpClient.get<Cuidado[]>(`${this.api}/Cuidados`);
  }

  getById(id: number): Observable<Cuidado> {
    return this.httpClient.get<Cuidado>(`${this.api}/Cuidados/${id}`);
  }

  create(cuidado: Cuidado): Observable<Cuidado> {
    return this.httpClient.post<Cuidado>(`${this.api}/Cuidados`, cuidado);
  }

  update(id: number, cuidado: Cuidado): Observable<void> {
    return this.httpClient.put<void>(`${this.api}/Cuidados/${id}`, cuidado);
  }

  delete(id: number | undefined): Observable<Cuidado> {
    return this.httpClient.delete<Cuidado>(`${this.api}/Cuidados/${id}`);
  }

}
