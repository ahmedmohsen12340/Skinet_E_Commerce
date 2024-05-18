import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IProduct } from '../../Models/iproduct';
import { ShopService } from '../../Services/shop.service';
import { ApiParams } from '../../Models/api-params';
import { CommonModule } from '@angular/common';
import { ProductCardComponent } from "../product-card/product-card.component";
import { IBrand } from '../../Models/ibrand';
import { IType } from '../../Models/itype';
import { IPaginate } from '../../Models/ipaginate';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { PaginationHeaderComponent } from "../pagination-header/pagination-header.component";

@Component({
  selector: 'app-shop',
  standalone: true,
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.css',
  imports: [CommonModule, NgbPaginationModule, ProductCardComponent, PaginationHeaderComponent]
})
export class ShopComponent implements OnInit {
  paginate: IPaginate<IProduct> = <IPaginate<IProduct>>{};
  products: IProduct[] = [];
  productParams = new ApiParams();
  brands: IBrand[] = [];
  types: IType[] = [];
  countOFproducts!: number;
  @ViewChild("search") search! : ElementRef;
  constructor(private shopService: ShopService) {
    this.productParams.PageIndex = 1;
    this.productParams.PageSize = 6;
  }

  ngOnInit(): void {
    this.getProducts()
    this.getBrands()
    this.getTypes()
  }

  getProducts() {
    this.shopService.getProducts(this.productParams).subscribe(
      {
        next: (res) => {
          // console.log(res);
          this.paginate = res;
          this.products = res.data;
          this.countOFproducts = res.count;
        },
        error: (e) => console.log("Error", e)
      }
    )
  }

  getBrands() {
    this.shopService.getBrands().subscribe({
      next: res => this.brands = [{ id: 0, name: "All" }, ...res],
      error: err => console.log(err)
    })
  }

  getTypes() {
    this.shopService.getTypes().subscribe({
      next: res => {
        // console.log(res)
        this.types = [{ id: 0, name: "All" }, ...res]
      },
      error: err => console.log(err)
    })
  }

  onBrandSelect(BrandId: number) {
    this.productParams.BrandId = BrandId;
    this.getProducts();
  }
  onTypeSelect(TypeId: number) {
    this.productParams.TypeId = TypeId;
    this.getProducts();
  }


  onSortSelect(event: any) {
    // console.log(event.target.value)
    this.productParams.Sort = event.target.value;
    this.getProducts()
  }

  onPageChange(event: any) {
    // this.productParams.PageIndex = this.page;
    this.productParams.PageIndex = event;
    this.getProducts();
  }

  onSearch(search: string) {
    this.productParams.search = search;
    this.getProducts()
  }

  onReset() {
    this.search.nativeElement.value = ""
    this.productParams.search = "";
    this.getProducts()
  }

}
