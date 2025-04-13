import { Component } from '@angular/core';
import { CuidadoFormularioComponent } from "../../components/cuidado-formulario/cuidado-formulario.component";
import { Cuidado } from '../../models/cuidado';
import { CuidadoService } from '../../services/cuidado/cuidado.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cuidado-cadastro',
  imports: [CuidadoFormularioComponent],
  templateUrl: './cuidado-cadastro.component.html',
  styleUrl: './cuidado-cadastro.component.css'
})
export class CuidadoCadastroComponent {
  btnAction: string = 'Cadastrar';
  title: string = 'Cadastrar';

  constructor(private cuidadosService: CuidadoService, private router: Router) { }

  adicionarCuidado(cuidado: Cuidado) {
    this.cuidadosService.create(cuidado).subscribe(response => {
      this.router.navigate(['/cuidados']);
    });
  }

}
