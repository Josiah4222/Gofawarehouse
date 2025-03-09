
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';


import { CommonModule } from '@angular/common';

import { ReactiveFormsModule } from '@angular/forms';
import { EditModel19Component } from './components/edit-model19/edit-model19.component';
import { ViewModel19Component } from './components/view-model19/view-model19.component';
import { Model19EditComponent } from './components/model19-edit/model19-edit.component';
@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  declarations: [
    EditModel19Component,
    ViewModel19Component,
    Model19EditComponent
  ],
})
export class TransitModule { }

