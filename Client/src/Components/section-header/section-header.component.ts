import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { BreadcrumbComponent, BreadcrumbItemDirective, BreadcrumbService } from 'xng-breadcrumb';
@Component({
  selector: 'app-section-header',
  standalone: true,
  imports: [CommonModule,BreadcrumbComponent, BreadcrumbItemDirective],
  templateUrl: './section-header.component.html',
  styleUrl: './section-header.component.css'
})
export class SectionHeaderComponent {
constructor(public bcService: BreadcrumbService){}
}
