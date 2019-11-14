import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonFormComponent } from './person-form/person-form.component';
import { PersonFormDialogComponent } from './person-form-dialog/person-form-dialog.component';
import { MaterialModule } from '../material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule } from '@angular/common/http';
import { NgProgressModule } from '@ngx-progressbar/core';
import { NgProgressHttpModule } from '@ngx-progressbar/http';

@NgModule({
  declarations: [PersonFormComponent, PersonFormDialogComponent],
  imports: [
    CommonModule ,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    MaterialModule ,
    NgProgressModule.withConfig({
      spinnerPosition: 'left',
      color: 'red',
      thick: true
    }),
    NgProgressHttpModule
  ],
  
  entryComponents: [ PersonFormDialogComponent]
})
export class ComponentsModule { }
