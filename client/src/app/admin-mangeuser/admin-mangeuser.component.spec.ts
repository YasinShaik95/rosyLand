import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminMangeuserComponent } from './admin-mangeuser.component';

describe('AdminMangeuserComponent', () => {
  let component: AdminMangeuserComponent;
  let fixture: ComponentFixture<AdminMangeuserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdminMangeuserComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdminMangeuserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
