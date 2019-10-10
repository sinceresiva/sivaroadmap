import { Component } from '@angular/core';

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styles: [`
        #navbarNav > li > a.active {color: #F97924;}
    `
    ]
})
export class NavBarComponent {
    searchTerm: String = '';
    searchSessions = (searchTerm) => {
        console.log('Search');
    }
}

