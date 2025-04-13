import { Routes } from '@angular/router';
import { AnimalListComponent } from './pages/animal-list/animal-list.component';
import { CuidadoListComponent } from './pages/cuidado-list/cuidado-list.component';
import { AnimalCadastroComponent } from './pages/animal-cadastro/animal-cadastro.component';
import { AnimalEditarComponent } from './pages/animal-editar/animal-editar.component';
import { AnimalDetalhesComponent } from './pages/animal-detalhes/animal-detalhes.component';


export const routes: Routes = [
  { path: '', redirectTo: 'animais', pathMatch: 'full' },
  { path: 'animais', component: AnimalListComponent },
  { path: 'cuidados', component: CuidadoListComponent },
  { path: 'animal/cadastro', component: AnimalCadastroComponent },
  { path: 'animal/editar/:id', component: AnimalEditarComponent },
  { path: 'animal/detalhes/:id', component: AnimalDetalhesComponent },

];
