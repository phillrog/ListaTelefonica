import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListPersonComponent } from './list-person.component';

const routes: Routes = [
  { path:'', component: ListPersonComponent },
  
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ListPersonRoutingModule { }
