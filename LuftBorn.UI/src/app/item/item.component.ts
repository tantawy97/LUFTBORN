import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ItemService } from '../../Service/item.service';
import { PaginatorDto } from '../../DTOs/paginator-dto';
import { MatDialog } from '@angular/material/dialog';
import { ItemDto } from '../../DTOs/item-dto';
import { EditDialogComponent } from '../edit-dialog/edit-dialog.component';
@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrl: './item.component.css'
})

export class ItemComponent implements AfterViewInit {
  constructor(private itemService: ItemService,
    public dialog: MatDialog
  ) { }

  displayedColumns: string[] = ['#', 'name', 'price', 'quantity', 'id'];
  dataSource = new MatTableDataSource<ItemDto>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;


  ngAfterViewInit() {
    this.paginator.page.subscribe(() => {

      this.loadData();
    });
    this.loadData();
  }

  loadData() {
    const paginatorDto: PaginatorDto = {
      pageIndex: this.paginator.pageIndex,
      pageSize: this.paginator.pageSize
    };
    this.itemService.get(paginatorDto)
      .subscribe(data => {
        this.dataSource.data = data.data!;
        this.paginator.length = data.count;

      });
  }
  deleteRow(id: string) {
    this.itemService.delete(id).subscribe(
      data => {
        const index = this.dataSource!.data.findIndex(item => item.id === id);
      if (index !== -1) {
        this.dataSource.data.splice(index,1)
      }
        if(this.dataSource!.data.length === 0)
          {
            this.paginator.pageIndex!==0?this.paginator.pageIndex-=1:this.paginator.pageIndex;
        }   
        this.loadData();
      }
    )
  }
  openEditDialog(data: ItemDto|null): void {
    const dialogRef = this.dialog.open(EditDialogComponent, {
      width: '350px',
      data: { item: data, dataSource: this.dataSource }
    });

    dialogRef.afterClosed().subscribe(result => {
      if(this.paginator.pageSize < this.dataSource!.data.length){
      this.dataSource!.data.pop();
      }
      this.paginator.length +=1;
      this.dataSource!._updateChangeSubscription();

    });

  }
}