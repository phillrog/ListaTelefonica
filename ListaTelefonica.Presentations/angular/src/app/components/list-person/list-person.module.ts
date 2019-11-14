import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ListPersonRoutingModule } from './list-person-routing.module';
import { ListPersonComponent } from './list-person.component';
import { MaterialModule } from 'src/app/material.module';
import { SidenavPersonFormService } from 'src/app/services/sidenav-person-form.service';
import { PersonFormComponent } from '../person-form/person-form.component';

@NgModule({
  declarations: [ListPersonComponent],
  imports: [
    CommonModule,
    ListPersonRoutingModule,
    MaterialModule
  ],
  exports: [
    ListPersonComponent
  ]
})
export class ListPersonModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: ListPersonModule,
      providers: [SidenavPersonFormService]
    };
  }

}
