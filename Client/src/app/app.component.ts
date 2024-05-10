import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { NavBarComponent } from "../Components/nav-bar/nav-bar.component";
import { ShopComponent } from "../Components/shop/shop.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [CommonModule, RouterOutlet, NavBarComponent, ShopComponent]
})
export class AppComponent {
  title = 'Client';
}
