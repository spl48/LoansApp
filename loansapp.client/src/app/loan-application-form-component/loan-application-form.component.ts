import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  standalone: true,
  selector: 'app-loan-application-form',
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './loan-application-form.component.html',
  styleUrl: './loan-application-form.component.less'
})
export class LoanApplicationFormComponent {
  loanForm!: FormGroup;
  errorMessage = '';

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.createForm();
  }

  createForm() {
    this.loanForm = this.fb.group({
      title: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      address: ['', Validators.required],
      mobileNumber: ['', [Validators.required, Validators.pattern('[0-9]{10}')]],
      email: ['', [Validators.required, Validators.email]],
      annualIncome: ['', Validators.required],
      isHomeOwner: [false],
      carRegistration: ['']
    });
  }

  onSubmit() {
    let formObj = this.loanForm.getRawValue();
    let serializedForm = JSON.stringify(formObj);

    this.http.post('http://localhost:5250/api/customer', serializedForm).subscribe(
      data => console.log("success!", data),
      error => console.error("couldn't post because", error)
    );
    if (this.loanForm.valid) {
      this.errorMessage = ''; // Clear any previous error message

      // Send form data to the backend
      this.http.post<any>('http://localhost:5250/api/customer', this.loanForm.value)
        .subscribe(
          response => {
            console.log('Form submitted successfully:', response);
            this.loanForm.reset();
          },
          error => {
            console.error('Error:', error);
          }
        );
    } else {
      this.errorMessage = 'Fix the validation error.';
    }
  }
}
