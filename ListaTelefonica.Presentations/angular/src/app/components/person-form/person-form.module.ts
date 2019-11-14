import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonFormRoutingModule } from './person-form-routing.module';
import { PersonFormComponent } from './person-form.component';
import { MaterialModule } from 'src/app/material.module';

@NgModule({
  declarations: [PersonFormComponent],
  imports: [
    CommonModule,
    PersonFormRoutingModule,
    MaterialModule
  ],
  exports: [PersonFormComponent]
})
export class PersonFormModule { }
