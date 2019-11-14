import { NgModule } from '@angular/core';
import { ModuleWithProviders } from '@angular/compiler/src/core';
import { ComponentsModule } from './components/components.module';
import { MaterialModule } from './material.module';

@NgModule({
  imports: [MaterialModule, ComponentsModule]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: []
    }
  }
}
