import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnimalEditarComponent } from './animal-editar.component';

describe('AnimalEditarComponent', () => {
  let component: AnimalEditarComponent;
  let fixture: ComponentFixture<AnimalEditarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AnimalEditarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AnimalEditarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
