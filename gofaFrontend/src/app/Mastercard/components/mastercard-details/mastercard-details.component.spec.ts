import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MastercardDetailsComponent } from './mastercard-details.component';

describe('MastercardDetailsComponent', () => {
  let component: MastercardDetailsComponent;
  let fixture: ComponentFixture<MastercardDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MastercardDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MastercardDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
