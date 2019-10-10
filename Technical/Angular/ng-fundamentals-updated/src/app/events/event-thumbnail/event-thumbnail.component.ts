import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { IEvent } from '../../shared/event.model';

@Component({
    selector: 'app-event-thumbnail',
    templateUrl: './event-thumbnail.component.html',
    styles: ['#thumbnailContainer > h2 {color: #ff8999}']
})
export class EventThumbnailComponent {
    @Input() event: IEvent;
    @Output() thumbnailButtonClicked = new EventEmitter<any>();
    handleButtonClicked(event) {
        this.thumbnailButtonClicked.emit({'date': this.event.date, 'price': this.event.price });
    }
    foo = () => {
        console.log('foo called');
    }
    checkPeakPrice = () => {
        if (this.event.price && this.event.price >= 800.00) {
            return {color: 'red', 'font-weight': 'bold'};
        }
        return {color: 'blue', 'font-weight': 'bold'};
    }
}
