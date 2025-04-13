import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { Animal } from '../../models/animal';

@Component({
  selector: 'app-animal-formulario',
  imports: [RouterModule, FormsModule, ReactiveFormsModule],
  templateUrl: './animal-formulario.component.html',
  styleUrl: './animal-formulario.component.css'
})
export class AnimalFormularioComponent implements OnInit {
  animalForm!: FormGroup;
  @Output() onSubmit = new EventEmitter<Animal>();
  @Input() animal: Animal | null = null;
  @Input() btnAction !: string;
  @Input() title !: string;

  ngOnInit(): void {
    console.log(this.animal);
    this.animalForm = new FormGroup({
      nome: new FormControl(this.animal?.nome),
      descricao: new FormControl(this.animal?.descricao),
      dataNascimento: new FormControl(this.animal?.dataNascimento),
      especie: new FormControl(this.animal?.especie),
      habitat: new FormControl(this.animal?.habitat),
      paisOrigem: new FormControl(this.animal?.paisOrigem),
    });
  }

  submit() {
    this.onSubmit.emit(this.animalForm.value);
  }

}
