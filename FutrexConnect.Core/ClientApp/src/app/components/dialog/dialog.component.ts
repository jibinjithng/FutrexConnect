import { DialogTypes } from './../../models/enums/dialogTypes';
import { Component, Inject, Input, OnInit } from '@angular/core';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { IDialogData } from 'src/app/models/dialogData';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css'],
})
export class DialogComponent implements OnInit {
  isAlertDialog: Boolean;
  isConfirmDialog: Boolean;

  constructor(
    public dialogRef: MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IDialogData
  ) {
    this.isAlertDialog = data.dialogType === DialogTypes.Alert;
    this.isConfirmDialog = data.dialogType === DialogTypes.Confirm;
  }

  ngOnInit(): void {}

  onClose(dialogResult: string): void {
    this.dialogRef.close(dialogResult);
  }
}
