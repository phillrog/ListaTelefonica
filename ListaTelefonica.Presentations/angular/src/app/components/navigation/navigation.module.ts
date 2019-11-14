import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NavigationRoutingModule } from './navigation-routing.module';
import { NavigationComponent } from './navigation.component';
import { MaterialModule } from 'src/app/material.module';
import { SidenavPersonFormService } from 'src/app/services/sidenav-person-form.service';

@NgModule({
  declarations: [NavigationComponent],
  imports: [
    CommonModule,
    NavigationRoutingModule,
    MaterialModule
  ],
  exports: [NavigationComponent]
})
export class NavigationModule {
  static forRoot(): ModuleWithProviders {
    return {   ngModule:NavigationModule,
      providers: [SidenavPersonFormService]
    };
  }
}
