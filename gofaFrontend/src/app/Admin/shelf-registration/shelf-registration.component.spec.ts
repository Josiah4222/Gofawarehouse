import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShelfRegistrationComponent } from './shelf-registration.component';

describe('ShelfRegistrationComponent', () => {
  let component: ShelfRegistrationComponent;
  let fixture: ComponentFixture<ShelfRegistrationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShelfRegistrationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShelfRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
