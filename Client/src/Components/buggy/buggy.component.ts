import { Component } from '@angular/core';
import { BuggyService } from '../../Services/buggy.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-buggy',
  standalone: true,
  imports: [HttpClientModule],
  templateUrl: './buggy.component.html',
  styleUrl: './buggy.component.css'
})
export class BuggyComponent {
  validationErrors: string[] = [];
  constructor(private buggyService: BuggyService) { }
  getNotfound() {
    this.buggyService.getErrorNotFound().subscribe({
      next: res => console.log(res),
      error: err => console.log(err)
    });
  }
  getServerError() {
    this.buggyService.getServerError().subscribe({
      next: res => console.log(res),
      error: err => console.log(err)
    });
  }
  getBadRequest() {
    this.buggyService.getBadRequest().subscribe({
      next: res => console.log(res),
      error: err => console.log(err)
    });
  }
  getvalidationError() {
    this.buggyService.getvalidationError().subscribe({
      next: res => console.log(res),
      error: err => {
        console.log(err)
        this.validationErrors=err.errors;
      }
    });
  }
}
