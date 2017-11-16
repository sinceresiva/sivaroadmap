import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { CompletedFilterPipe, TodolistComponent } from './index';
// ag-grid
import { AgGridModule } from 'ag-grid-ng2/main';

@NgModule({
    declarations: [
        CompletedFilterPipe,
        TodolistComponent
    ],
    imports: [
        FormsModule,
        BrowserModule,
        AgGridModule.withComponents(
            [ TodolistComponent ]
        )
    ],
    exports: [
        CompletedFilterPipe,
        TodolistComponent
    ]
})
export class TodolistModule {
}
