import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponseDto } from '../DTOs/api-response';
import { ItemDto } from '../DTOs/item-dto';
import { environment } from '../enviroment/enviroment';
import { PaginatorDto } from '../DTOs/paginator-dto';
import { AddItemDto } from '../DTOs/add-item-dto';
@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor( private http: HttpClient) { }
  get(paginator:PaginatorDto): Observable<ApiResponseDto<ItemDto[]>> {
    return this.http.get<ApiResponseDto<ItemDto[]>>(`${environment.apiUrl}?pageSize=${paginator.pageSize}&pageIndex=${paginator.pageIndex}`)
  }
  getById(id:string): Observable<ApiResponseDto<ItemDto>> {
    return this.http.get<ApiResponseDto<ItemDto>>(`${environment.apiUrl}/${id}`)
  }
  add(obj:AddItemDto): Observable<ApiResponseDto<boolean>> {
    return this.http.post<ApiResponseDto<boolean>>(`${environment.apiUrl}`,obj)
  }
  update(id:string,obj: AddItemDto): Observable<ApiResponseDto<boolean>> {
    return this.http.put<ApiResponseDto<boolean>>(`${environment.apiUrl}/${id}`,obj)
  }
  delete(id:string): Observable<ApiResponseDto<boolean>> {
    return this.http.delete<ApiResponseDto<boolean>>(`${environment.apiUrl}/${id}`)
  }
 
}
