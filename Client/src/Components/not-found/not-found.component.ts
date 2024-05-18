import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-not-found',
  standalone: true,
  imports: [],
  templateUrl: './not-found.component.html',
  styleUrl: './not-found.component.css'
})
export class NotFoundComponent {
  error!: any;
  constructor(private router: Router)
  {
    let navExtras = this.router.getCurrentNavigation()
    this.error = navExtras?.extras?.state?.['error']
  }

}
