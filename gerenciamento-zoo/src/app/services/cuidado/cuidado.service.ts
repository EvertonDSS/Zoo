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

  delete(id: number | undefined): Observable<Cuidado> {
    return this.httpClient.delete<Cuidado>(`${this.api}/Cuidados/${id}`);
  }
}
