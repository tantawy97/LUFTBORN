import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ItemDto } from '../../DTOs/item-dto';
import { ItemService } from '../../Service/item.service';
import { AddItemDto } from '../../DTOs/add-item-dto';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-dialog',
  templateUrl: './edit-dialog.component.html',
  styleUrl: './edit-dialog.component.css'
})
export class EditDialogComponent implements OnInit {
  form: any;
  dataSource: MatTableDataSource<ItemDto> | undefined;

  constructor(
    public dialogRef: MatDialogRef<EditDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private formBuilder: FormBuilder,
    private itemService: ItemService,
    private _toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.dataSource = this.data.dataSource;

    this.form = this.formBuilder.group({
      id: [this.data.item?.id],
      name: [this.data.item?.name, Validators.required],
      price: [this.data.item?.price, Validators.required],
      quantity: [this.data.item?.quantity, Validators.required]
    });
  }

  onOkClick(): void {
    if (this.form.valid) {
      const updatedData: AddItemDto = this.form.value;
      if (this.data.item === null) {
        this.itemService.add(updatedData)
          .subscribe(
            response => {
                this.updateDataSourceRow(response.data, 0);
                this._toastr.success(response.message, '', { timeOut: 3000 });
                this.dialogRef.close();
            },
            error => {
              this._toastr.error(error.message, '', { timeOut: 3000 });
            }
          )
      }
      else {
        this.itemService.update(this.data.item.id, updatedData)
          .subscribe(
            response => {
              this.updateDataSourceRow(this.form.value, 1);
              this._toastr.success(response.message, '', { timeOut: 3000 });
              this.dialogRef.close();
            },
            error => {
              this._toastr.error(error.message, '', { timeOut: 3000 });
            }
          )
      }
    }
  }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  updateDataSourceRow(formData: any, type: number): void {
    if (type === 0) {
      this.addNewRow(formData)
    }
    else {
      const index = this.dataSource!.data.findIndex(item => item.id === formData.id);
      if (index !== -1) {
        this.dataSource!.data[index] = formData;
      }
    }
  }
  addNewRow(formData: any): void {
    const newRow: ItemDto = formData
    this.dataSource!.data.splice(0, 0, newRow);
    this.dataSource!._updateChangeSubscription();

  }
}
