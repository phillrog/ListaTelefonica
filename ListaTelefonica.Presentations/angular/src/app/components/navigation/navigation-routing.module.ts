import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NavigationComponent } from './navigation.component';

const routes: Routes = [{
  path: '', component: NavigationComponent, children: [{
    path: '', loadChildren: '../list-person/list-person.module#ListPersonModule'
  }]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NavigationRoutingModule { }
