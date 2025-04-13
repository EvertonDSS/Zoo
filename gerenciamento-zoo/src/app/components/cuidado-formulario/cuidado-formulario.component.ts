import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { Cuidado } from '../../models/cuidado';
import { UnidadeFrequenciaEnum } from '../../models/enum/UnidadeFrequenciaEnum';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cuidado-formulario',
  imports: [CommonModule, RouterModule, FormsModule, ReactiveFormsModule],
  templateUrl: './cuidado-formulario.component.html',
  styleUrl: './cuidado-formulario.component.css'
})
export class CuidadoFormularioComponent implements OnInit {


  unidadesFrequencia = Object.keys(UnidadeFrequenciaEnum)
    .filter(key => !isNaN(Number(UnidadeFrequenciaEnum[key as any])))
    .map(key => ({
      nome: key,
      valor: UnidadeFrequenciaEnum[key as keyof typeof UnidadeFrequenciaEnum]
    }));

  cuidadoForm!: FormGroup;
  @Output() onSubmit = new EventEmitter<Cuidado>();
  @Input() cuidado: Cuidado | null = null;
  @Input() btnAction !: string;
  @Input() title !: string;

  ngOnInit(): void {


    console.log(this.cuidado)
    this.cuidadoForm = new FormGroup({
      nomeCuidado: new FormControl(this.cuidado?.nomeCuidado),
      descricao: new FormControl(this.cuidado?.descricao),
      frequencia: new FormControl(this.cuidado?.frequencia),
      unidadeFrequencia: new FormControl(this.cuidado?.unidadeFrequencia),
    });
  }

  submit() {
    this.onSubmit.emit(this.cuidadoForm.value);
  }

}
