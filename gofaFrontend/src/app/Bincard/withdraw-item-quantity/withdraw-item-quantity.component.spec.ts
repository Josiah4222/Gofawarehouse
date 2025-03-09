import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WithdrawItemQuantityComponent } from './withdraw-item-quantity.component';

describe('WithdrawItemQuantityComponent', () => {
  let component: WithdrawItemQuantityComponent;
  let fixture: ComponentFixture<WithdrawItemQuantityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WithdrawItemQuantityComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WithdrawItemQuantityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
