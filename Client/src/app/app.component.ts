import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { NavBarComponent } from "../Components/nav-bar/nav-bar.component";
import { ShopComponent } from "../Components/shop/shop.component";
import { SectionHeaderComponent } from "../Components/section-header/section-header.component";
import { NgxSpinnerModule } from "ngx-spinner";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [CommonModule, RouterOutlet, NavBarComponent, ShopComponent, SectionHeaderComponent,NgxSpinnerModule]
})
export class AppComponent {

}
