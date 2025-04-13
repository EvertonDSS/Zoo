import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Cuidado } from '../../models/cuidado';
import { CuidadoService } from '../../services/cuidado/cuidado.service';
import { EnumStringPipe } from '../../pipes/enum-string.pipe';

@Component({
  selector: 'app-cuidado-detalhes',
  imports: [RouterModule, EnumStringPipe],
  templateUrl: './cuidado-detalhes.component.html',
  styleUrl: './cuidado-detalhes.component.css'
})
export class CuidadoDetalhesComponent implements OnInit {

  cuidado!: Cuidado;

  constructor(private cuidadoService: CuidadoService, private activatedRoute: ActivatedRoute) {

  }
  ngOnInit(): void {
    const id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.cuidadoService.getById(id).subscribe((cuidado) => {
      this.cuidado = cuidado;
    })
  };



}
