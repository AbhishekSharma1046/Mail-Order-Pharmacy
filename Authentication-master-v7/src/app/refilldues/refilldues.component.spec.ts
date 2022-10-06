import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RefillduesComponent } from './refilldues.component';

describe('RefillduesComponent', () => {
  let component: RefillduesComponent;
  let fixture: ComponentFixture<RefillduesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RefillduesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RefillduesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
