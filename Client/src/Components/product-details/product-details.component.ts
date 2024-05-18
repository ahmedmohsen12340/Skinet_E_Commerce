import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShopService } from '../../Services/shop.service';
import { HttpClientModule } from '@angular/common/http';
import { IProduct } from '../../Models/iproduct';
import { CommonModule } from '@angular/common';

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
  constructor(private route: ActivatedRoute, private shopService: ShopService) {
    this.id = this.route.snapshot.params['id'];
  }
  ngOnInit(): void {
    this.shopService.getProduct(this.id).subscribe({
      next: res => {
        // console.log(res);
        this.product = res
      },
      error: err => console.log(err)
    })
  }
}
