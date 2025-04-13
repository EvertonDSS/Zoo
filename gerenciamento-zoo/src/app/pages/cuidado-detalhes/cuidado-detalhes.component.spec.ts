import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CuidadoDetalhesComponent } from './cuidado-detalhes.component';

describe('CuidadoDetalhesComponent', () => {
  let component: CuidadoDetalhesComponent;
  let fixture: ComponentFixture<CuidadoDetalhesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CuidadoDetalhesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CuidadoDetalhesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
