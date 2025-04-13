import { Component, OnInit } from '@angular/core';
import { AnimalFormularioComponent } from "../../components/animal-formulario/animal-formulario.component";
import { AnimalService } from '../../services/animal/animal.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Animal } from '../../models/animal';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-animal-editar',
  imports: [AnimalFormularioComponent, CommonModule],
  templateUrl: './animal-editar.component.html',
  styleUrl: './animal-editar.component.css'
})
export class AnimalEditarComponent implements OnInit {

  btnAction: string = 'Salvar';
  title: string = 'Atualizar';
  animal!: Animal;

  constructor(
    private animalService: AnimalService,
    private route: Router,
    private activatedRoute: ActivatedRoute) {

  }

  ngOnInit() {
    const id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.animalService.getById(id).subscribe(response => {
      this.animal = response;
    })
  }

  editarAnimal(animal: Animal) {
    const id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.animalService.update(id, animal).subscribe(() => {
      this.route.navigate(['animais']);
    });
  }
}
