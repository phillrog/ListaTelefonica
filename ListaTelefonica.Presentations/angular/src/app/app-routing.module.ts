import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', loadChildren: './components/navigation/navigation.module#NavigationModule'},
  { path: 'personform', loadChildren: './components/person-form/person-form.module#PersonFormModule'}  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
