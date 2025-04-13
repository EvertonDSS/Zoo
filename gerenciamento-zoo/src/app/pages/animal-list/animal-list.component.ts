import { Component, OnInit } from '@angular/core';
import { AnimalService } from '../../services/animal/animal.service';
import { Animal } from '../../models/animal';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-animal-list',
  imports: [CommonModule, RouterModule],
  templateUrl: './animal-list.component.html',
  styleUrl: './animal-list.component.css'
})
export class AnimalListComponent implements OnInit {

  animais: Animal[] = [];

  constructor(private animalService: AnimalService) { }

  ngOnInit(): void {
    this.animalService.getAll().subscribe((response: Animal[]) => {
      this.animais = response;
      //console.log(response);
    });
  }

  deletar(id: number | undefined) {
    this.animalService.delete(id).subscribe(response => {
      //console.log(response);
      window.location.reload();
    });
  }
  listarAnimais() {

  }

}
