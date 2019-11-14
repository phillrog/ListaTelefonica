import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PersonFormComponent } from './person-form.component';

const routes: Routes = [
  { path: '', component: PersonFormComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonFormRoutingModule { }
