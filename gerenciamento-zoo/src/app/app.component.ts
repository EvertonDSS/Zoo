import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AnimalListComponent } from './pages/animal-list/animal-list.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'gerenciamento-zoo';
}
