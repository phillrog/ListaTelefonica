import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ListPersonRoutingModule } from './list-person-routing.module';
import { ListPersonComponent } from './list-person.component';
import { MaterialModule } from 'src/app/material.module';
import { PersonCrudService } from 'src/app/services/person-crud.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [ListPersonComponent],
  imports: [
    CommonModule,
    ListPersonRoutingModule,
    MaterialModule,
    FormsModule
  ],
  exports: [
    ListPersonComponent
  ]
})
export class ListPersonModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: ListPersonModule,
      providers: [PersonCrudService]
    };
  }

}
