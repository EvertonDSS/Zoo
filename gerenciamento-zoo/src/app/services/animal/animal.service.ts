import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';
import { Animal } from '../../models/animal';

@Injectable({
  providedIn: 'root'
})
export class AnimalService {


  private api = environment.urlApi;

  constructor(private httpClient: HttpClient) { }

  adicionarCuidadoAoAnimal(idAnimal: number, idCuidado: number): Observable<Animal> {
    return this.httpClient.post<Animal>(`${this.api}/Animais/${idAnimal}/Cuidado/${idCuidado}`, {});
  }

  removerCuidadoAoAnimal(idAnimal: number, idCuidado: number): Observable<Animal> {
    return this.httpClient.delete<Animal>(`${this.api}/Animais/${idAnimal}/Cuidado/${idCuidado}`, {});
  }


  getAll(): Observable<Animal[]> {
    return this.httpClient.get<Animal[]>(`${this.api}/Animais`);
  }

  getById(id: number): Observable<Animal> {
    return this.httpClient.get<Animal>(`${this.api}/Animais/${id}`);
  }

  create(animal: Animal): Observable<Animal> {
    return this.httpClient.post<Animal>(`${this.api}/Animais`, animal);
  }

  update(id: number, animal: Animal): Observable<void> {
    return this.httpClient.put<void>(`${this.api}/Animais/${id}`, animal);
  }

  delete(id: number | undefined): Observable<Animal> {
    return this.httpClient.delete<Animal>(`${this.api}/Animais/${id}`);
  }
}
