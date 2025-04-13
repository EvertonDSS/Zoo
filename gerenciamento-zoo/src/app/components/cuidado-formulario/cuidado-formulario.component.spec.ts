import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CuidadoFormularioComponent } from './cuidado-formulario.component';

describe('CuidadoFormularioComponent', () => {
  let component: CuidadoFormularioComponent;
  let fixture: ComponentFixture<CuidadoFormularioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CuidadoFormularioComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CuidadoFormularioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
