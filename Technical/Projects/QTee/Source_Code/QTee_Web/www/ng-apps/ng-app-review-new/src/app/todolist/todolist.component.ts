import { Component } from '@angular/core';

import { Todo } from './todo.model';

@Component({
    moduleId: module.id,
    selector: 'as-todolist',
    templateUrl: 'todolist.html'
})
export class TodolistComponent {
    public todo: Todo;
    private list: Todo[];
    private showCompleted: Boolean;
    private myGridOptions: any = {};

    constructor() {
        this.showCompleted = true;
        this.todo = new Todo('Add me to list!', false);
        this.list = [
            new Todo('Its cool'),
            new Todo('Hello', true)
        ];

        this.myGridOptions.columnDefs = [
            {headerName: 'Make', field: 'make', width: 300},
            {headerName: 'Model', field: 'model', width: 300},
            {headerName: 'Price', field: 'price', width: 300}
        ];

        this.myGridOptions.rowData = [
            {make: 'Toyota', model: 'Celica', price: 35000},
            {make: 'Ford', model: 'Mondeo', price: 32000},
            {make: 'Porsche', model: 'Boxter', price: 72000}
        ];
    }

    addTodo() {
        this.list = this.list.concat(Todo.clone(this.todo));
        this.todo.clear();
    }

    delTodo(todoIndex: number) {
        this.list = this.list.filter(
            (todo, index) => index !== todoIndex);
    }
}
