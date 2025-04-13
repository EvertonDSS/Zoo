import { Component } from '@angular/core';
import { AnimalFormularioComponent } from '../../components/animal-formulario/animal-formulario.component';
import { Animal } from '../../models/animal';
import { AnimalService } from '../../services/animal/animal.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-animal-cadastro',
  imports: [AnimalFormularioComponent],
  templateUrl: './animal-cadastro.component.html',
  styleUrl: './animal-cadastro.component.css'
})
export class AnimalCadastroComponent {

  btnAction: string = 'Cadastrar';
  title: string = 'Cadastrar';
  constructor(private animalService: AnimalService, private router: Router) { }

  adicionarAnimal(animal: Animal) {
    this.animalService.create(animal).subscribe(response => {
      this.router.navigate(['/animais']);
    });
  }
}
