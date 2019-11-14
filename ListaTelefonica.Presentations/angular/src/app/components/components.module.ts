import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonFormComponent } from './person-form/person-form.component';
import { PersonFormDialogComponent } from './person-form-dialog/person-form-dialog.component';
import { MaterialModule } from '../material.module';

@NgModule({
  declarations: [PersonFormComponent, PersonFormDialogComponent],
  imports: [
    CommonModule ,
    MaterialModule 
  ],
  
  entryComponents: [ PersonFormDialogComponent]
})
export class ComponentsModule { }
