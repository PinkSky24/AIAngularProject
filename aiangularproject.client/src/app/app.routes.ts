import { Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'HomePage',
    pathMatch: 'full'
  },
  {
    path: 'HomePage',
    component: HomePageComponent
  }
]; 