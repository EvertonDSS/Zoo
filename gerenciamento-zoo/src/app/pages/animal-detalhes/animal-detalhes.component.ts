import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { AnimalService } from '../../services/animal/animal.service';
import { Animal } from '../../models/animal';
import { UnidadeFrequenciaEnum } from '../../models/enum/UnidadeFrequenciaEnum';

@Component({
  selector: 'app-animal-detalhes',
  imports: [RouterModule],
  templateUrl: './animal-detalhes.component.html',
  styleUrl: './animal-detalhes.component.css'
})
export class AnimalDetalhesComponent implements OnInit {

  animal!: Animal;
  UnidadeFrequencia = UnidadeFrequenciaEnum

  constructor(private animalService: AnimalService, private activatedRoute: ActivatedRoute) {

  }
  ngOnInit(): void {
    const id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.animalService.getById(id).subscribe((animal) => {
      this.animal = animal;
    })
  };
}
