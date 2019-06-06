import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { RegisterComponent } from './register/register.component';
import { LogInComponent } from './log-in/log-in.component';


const routes: Routes = [
  { 
    path: '', 
    redirectTo: '/home', 
    pathMatch: 'full' 
  },

  { 
    path: 'register', 
    component: RegisterComponent 
  },
  { 
    path: 'log-in', 
    component: LogInComponent 
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
