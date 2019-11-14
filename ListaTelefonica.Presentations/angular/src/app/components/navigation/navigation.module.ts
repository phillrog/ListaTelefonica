import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NavigationRoutingModule } from './navigation-routing.module';
import { NavigationComponent } from './navigation.component';
import { MaterialModule } from 'src/app/material.module';
import { HttpClientModule } from '@angular/common/http';
import { NgProgressModule } from '@ngx-progressbar/core';
import { NgProgressHttpModule } from '@ngx-progressbar/http';

@NgModule({
  declarations: [NavigationComponent],
  imports: [
    CommonModule,
    NavigationRoutingModule,
    MaterialModule,
    HttpClientModule,
    NgProgressModule.withConfig({
      spinnerPosition: 'left',
      color: 'red',
      thick: true
    }),
    NgProgressHttpModule
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
