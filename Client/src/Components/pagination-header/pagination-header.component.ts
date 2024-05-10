import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-pagination-header',
  standalone: true,
  imports: [],
  templateUrl: './pagination-header.component.html',
  styleUrl: './pagination-header.component.css'
})
export class PaginationHeaderComponent {
@Input() pageIndex! : number;
@Input() pageSize! : number;
@Input() count! : number;
}
