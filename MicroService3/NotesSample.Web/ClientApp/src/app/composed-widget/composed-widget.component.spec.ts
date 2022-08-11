import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComposedWidgetComponent } from './composed-widget.component';

describe('ComposedWidgetComponent', () => {
  let component: ComposedWidgetComponent;
  let fixture: ComponentFixture<ComposedWidgetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComposedWidgetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComposedWidgetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
