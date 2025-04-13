import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { AnimalService } from '../../services/animal/animal.service';
import { Animal } from '../../models/animal';
import { UnidadeFrequenciaEnum } from '../../models/enum/UnidadeFrequenciaEnum';
import { Cuidado } from '../../models/cuidado';
import { CuidadoService } from '../../services/cuidado/cuidado.service';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-animal-detalhes',
  imports: [RouterModule, CommonModule, ReactiveFormsModule],
  templateUrl: './animal-detalhes.component.html',
  styleUrl: './animal-detalhes.component.css'
})
export class AnimalDetalhesComponent implements OnInit {


  animal!: Animal;
  cuidados!: Cuidado[];
  formulario!: FormGroup;

  UnidadeFrequencia = UnidadeFrequenciaEnum

  constructor(private fb: FormBuilder,
    private animalService: AnimalService, private cuidadosService: CuidadoService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    const id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.animalService.getById(id).subscribe((animal) => {
      this.animal = animal;
    })

    this.formulario = this.fb.group({
      cuidado: ['']
    });

    this.cuidadosService.getAll().subscribe((cuidados) => {
      this.cuidados = cuidados;
    })
  };

  removerCuidado(cuidadoId: number) {
    if (!this.animal?.id) {
      return;
    }

    this.animalService.removerCuidadoAoAnimal(this.animal.id, cuidadoId).subscribe(() => {
      window.location.reload();
    }, (error) => {
      alert(error.error.message)
    })
  }

  adicionarCuidado() {
    const cuidadoId = this.formulario.value.cuidado;
    if (!cuidadoId || !this.animal?.id) {
      return;
    }

    this.animalService.adicionarCuidadoAoAnimal(this.animal.id, cuidadoId).subscribe(() => {
      window.location.reload();
    }, (error) => {
      alert(error.error.message)
    })
  }

}
