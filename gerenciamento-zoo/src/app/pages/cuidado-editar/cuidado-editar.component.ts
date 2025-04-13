import { Component, OnInit } from '@angular/core';
import { Cuidado } from '../../models/cuidado';
import { CuidadoService } from '../../services/cuidado/cuidado.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CuidadoFormularioComponent } from '../../components/cuidado-formulario/cuidado-formulario.component';

@Component({
  selector: 'app-cuidado-editar',
  imports: [CommonModule, CuidadoFormularioComponent],
  templateUrl: './cuidado-editar.component.html',
  styleUrl: './cuidado-editar.component.css'
})
export class CuidadoEditarComponent implements OnInit {

  btnAction: string = 'Salvar';
  title: string = 'Atualizar';
  cuidado!: Cuidado;

  constructor(
    private cuidadoService: CuidadoService,
    private route: Router,
    private activatedRoute: ActivatedRoute) {

  }

  ngOnInit() {
    const id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.cuidadoService.getById(id).subscribe(response => {
      this.cuidado = response;
    })
  }

  editarCuidado(cuidado: Cuidado) {
    const id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.cuidadoService.update(id, cuidado).subscribe(() => {
      this.route.navigate(['cuidados']);
    });
  }

}
