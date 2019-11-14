import { NgModule } from '@angular/core';
import { ModuleWithProviders } from '@angular/compiler/src/core';
import { SidenavPersonFormService } from './services/sidenav-person-form.service';
import { ComponentsModule } from './components/components.module';
import { MaterialModule } from './material.module';

@NgModule({
  imports: [MaterialModule, ComponentsModule]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [SidenavPersonFormService]
    }
  }
}
