import { Component } from '@angular/core';
import { AuthService } from '../user/services/auth.service'
@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styles: [`
        #navbarNav > li > a.active {color: #F97924;}
    `
    ]
})
export class NavBarComponent {
    searchTerm = '';
    constructor(public authSvc: AuthService) {

    }
    searchSessions = (searchTerm) => {
        console.log('Search');
    }
}

