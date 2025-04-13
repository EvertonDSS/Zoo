import { Component, OnInit } from '@angular/core';
import { Cuidado } from '../../models/cuidado';
import { CuidadoService } from '../../services/cuidado/cuidado.service';
import { UnidadeFrequenciaEnum } from '../../models/enum/UnidadeFrequenciaEnum';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-cuidado-list',
  imports: [RouterModule],
  templateUrl: './cuidado-list.component.html',
  styleUrl: './cuidado-list.component.css'
})
export class CuidadoListComponent implements OnInit {
  cuidados: Cuidado[] = [];
  UnidadeFrequencia = UnidadeFrequenciaEnum

  constructor(private cuidadoService: CuidadoService) { }

  ngOnInit(): void {
    this.cuidadoService.getAll().subscribe((response: Cuidado[]) => {
      this.cuidados = response;
      console.log(response);
    });
  }

  deletar(id: number | undefined) {
    this.cuidadoService.delete(id).subscribe(response => {
      //console.log(response);
      window.location.reload();
    });
  }
}
