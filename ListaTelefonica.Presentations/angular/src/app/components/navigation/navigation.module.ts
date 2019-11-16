import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NavigationRoutingModule } from './navigation-routing.module';
import { NavigationComponent } from './navigation.component';
import { MaterialModule } from 'src/app/material.module';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [NavigationComponent],
  imports: [
    CommonModule,
    NavigationRoutingModule,
    MaterialModule,
    HttpClientModule,

  ],
  exports: [NavigationComponent]
})
export class NavigationModule {
  static forRoot(): ModuleWithProviders {
    return {   ngModule:NavigationModule,
      providers: []
    };
  }
}
