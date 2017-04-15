import { Component, Optional } from '@angular/core';
import { Auth } from './auth/auth.service';
import { MenubarModule, MenuItem } from 'primeng/primeng';

@Component({
  selector: 'app-playground',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
    private items: MenuItem[];
    constructor(private auth: Auth) {
        this.auth.handleAuthentication();
    }
    ngOnInit() {
        this.items = [
            { label: 'Home', icon: 'fa-bar-chart' },
            { label: 'Reports', icon: 'fa-book' },
            { label: 'Browse', icon: 'fa-calendar' },
            { label: 'Upload', icon: 'fa-twitter', routerLink:['upload'] },
            { label: 'Login', icon: 'fa-support', routerLink:['login'] }
            
        ];
    }
}

