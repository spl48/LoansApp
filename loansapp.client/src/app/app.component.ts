import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { LoanApplicationFormComponent } from './loan-application-form-component/loan-application-form.component';

@Component({
  standalone: true,
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [LoanApplicationFormComponent]
})
export class AppComponent implements OnInit {

  constructor(private http: HttpClient) {}

  ngOnInit() {
  }
  
}
