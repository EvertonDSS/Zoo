import { Routes } from '@angular/router';
import { AnimalListComponent } from './pages/animal-list/animal-list.component';
import { CuidadoListComponent } from './pages/cuidado-list/cuidado-list.component';
import { AnimalCadastroComponent } from './pages/animal-cadastro/animal-cadastro.component';
import { AnimalEditarComponent } from './pages/animal-editar/animal-editar.component';
import { AnimalDetalhesComponent } from './pages/animal-detalhes/animal-detalhes.component';
import { CuidadoFormularioComponent } from './components/cuidado-formulario/cuidado-formulario.component';
import { CuidadoCadastroComponent } from './pages/cuidado-cadastro/cuidado-cadastro.component';
import { CuidadoEditarComponent } from './pages/cuidado-editar/cuidado-editar.component';
import { CuidadoDetalhesComponent } from './pages/cuidado-detalhes/cuidado-detalhes.component';


export const routes: Routes = [
  { path: '', redirectTo: 'animais', pathMatch: 'full' },
  { path: 'animais', component: AnimalListComponent },
  { path: 'cuidados', component: CuidadoListComponent },
  { path: 'animal/cadastro', component: AnimalCadastroComponent },
  { path: 'animal/editar/:id', component: AnimalEditarComponent },
  { path: 'animal/detalhes/:id', component: AnimalDetalhesComponent },
  { path: 'cuidados/cadastro', component: CuidadoCadastroComponent },
  { path: 'cuidados/editar/:id', component: CuidadoEditarComponent },
  { path: 'cuidados/detalhes/:id', component: CuidadoDetalhesComponent },


];
