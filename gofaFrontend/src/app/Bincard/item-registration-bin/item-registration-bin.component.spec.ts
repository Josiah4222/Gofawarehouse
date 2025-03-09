import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemRegistrationBinComponent } from './item-registration-bin.component';

describe('ItemRegistrationBinComponent', () => {
  let component: ItemRegistrationBinComponent;
  let fixture: ComponentFixture<ItemRegistrationBinComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ItemRegistrationBinComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ItemRegistrationBinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
