import { LoginComponent } from './auth/login/login.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  { path: 'home', redirectTo: '/home', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'browse', redirectTo: '/browse', pathMatch: 'full' },
  { path: 'upload', redirectTo: '/upload', pathMatch: 'full' }
];

export const AppRoutes = RouterModule.forRoot(routes);
