import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPaginate } from '../Models/ipaginate';
import { IProduct } from '../Models/iproduct';
import { ApiParams } from '../Models/api-params';
import { IBrand } from '../Models/ibrand';
import { IType } from '../Models/itype';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = "https://localhost:5001/api/"

  constructor(private http: HttpClient) { }
  getProducts(apiParams: ApiParams) {
    let params = new HttpParams()
    if(apiParams.search)
      params = params.append("Search", apiParams.search);
    if(apiParams.BrandId)
      params = params.append("BrandId", apiParams.BrandId);
    if(apiParams.TypeId)
      params = params.append("TypeId", apiParams.TypeId);
    params = params.append("Sort", apiParams.Sort);
    params = params.append("PageSize", apiParams.PageSize);
    params = params.append("PageIndex", apiParams.PageIndex);

    return this.http.get<IPaginate<IProduct>>(this.baseUrl + "products",{params : params})
  }

  getBrands(){
    return this.http.get<IBrand[]>(this.baseUrl+"products/brands")
  }

  getTypes(){
    return this.http.get<IType[]>(this.baseUrl+"products/Types")
  }
}
