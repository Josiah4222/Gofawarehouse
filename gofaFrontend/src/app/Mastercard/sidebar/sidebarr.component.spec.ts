import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MSidebarComponent } from './sidebarr.component';

describe('SidebarComponent', () => {
  let component: MSidebarComponent;
  let fixture: ComponentFixture<MSidebarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MSidebarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MSidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
