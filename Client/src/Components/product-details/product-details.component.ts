import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShopService } from '../../Services/shop.service';
import { HttpClientModule } from '@angular/common/http';
import { IProduct } from '../../Models/iproduct';
import { CommonModule } from '@angular/common';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [HttpClientModule, CommonModule],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent implements OnInit {
  id!: number
  product!: IProduct
  constructor(private route: ActivatedRoute, private shopService: ShopService, private bcService: BreadcrumbService) {
    this.id = this.route.snapshot.params['id'];
    this.bcService.set("@productDetails", " ")
  }
  ngOnInit(): void {
    this.shopService.getProduct(this.id).subscribe({
      next: res => {
        // console.log(res);
        this.product = res;
        this.bcService.set("@productDetails", res.name)
      },
      error: err => console.log(err)
    })
  }
}
