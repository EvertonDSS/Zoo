import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CuidadoEditarComponent } from './cuidado-editar.component';

describe('CuidadoEditarComponent', () => {
  let component: CuidadoEditarComponent;
  let fixture: ComponentFixture<CuidadoEditarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CuidadoEditarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CuidadoEditarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
