import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-table-actions',
  templateUrl: './table-actions.component.html',
  styleUrls: ['./table-actions.component.css'],
})
export class TableActionsComponent implements OnInit {
  @Output('onEdit')
  editEventEmitter: EventEmitter<number> = new EventEmitter<number>();

  @Output('onDelete')
  deleteEventEmitter: EventEmitter<number> = new EventEmitter<number>();

  @Input()
  rowId: number;
  constructor() {}

  ngOnInit(): void {}

  editRow() {
    this.editEventEmitter.emit(this.rowId);
  }
  deleteRow() {
    this.deleteEventEmitter.emit(this.rowId);
  }
}
