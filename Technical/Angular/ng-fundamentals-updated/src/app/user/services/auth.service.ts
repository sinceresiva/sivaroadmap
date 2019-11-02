
import { Injectable } from '@angular/core';
import { IUser } from '../models/IUser';
import { last } from 'rxjs/operators';

@Injectable()
export class AuthService {
    currentUser: IUser;
    loginUser(userName: string, password: string) {
        this.currentUser = {
            id: 1,
            // tslint:disable-next-line: object-literal-key-quotes
            'userName': userName,
            firstName: 'John',
            lastName: 'Papa'
        }
    }

    isAuthenticated() {
        return !!this.currentUser;
    }

    updateCurrentUser(firstName, lastName) {
        this.currentUser.firstName = firstName;
        this.currentUser.lastName = lastName;
    }

}

