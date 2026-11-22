import { Component } from '@angular/core';
import { DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ClaimService } from './services/claim.services';

@Component({
  selector: 'app-root',
  imports: [FormsModule, DatePipe],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  showSubmissionForm = false;

  successMessage = '';
  errorMessage = '';

  claims: any[] = [];
  showClaims = false;

  loadClaims() {
  this.errorMessage = '';
  this.showClaims = true;

  this.claimService.getClaims().subscribe({
    next: (response) => {
      this.claims = response;
    },
    error: (error) => {
      console.error('Failed to retrieve claims:', error);
      this.errorMessage = 'Unable to retrieve claims.';
    }
  });
}

  claimData = {
    claimantId: 1,
    policyNumber: '',
    marketCode: 'MY',
    claimType: 'Motor',
    incidentDescription: '',
    incidentDate: '',
    estimatedLiability: 0
  };

  constructor(private claimService: ClaimService) {}

  submitClaim() {
    this.successMessage = '';
    this.errorMessage = '';

    this.claimService.createClaim(this.claimData).subscribe({
    next: (response) => {
      this.successMessage =
        `Claim submitted successfully! Claim Number: ${response.claimNumber}`;

      alert(this.successMessage);

        this.claimData = {
          claimantId: 1,
          policyNumber: '',
          marketCode: 'MY',
          claimType: 'Motor',
          incidentDescription: '',
          incidentDate: '',
          estimatedLiability: 0
        };

        this.showSubmissionForm = false;
      },
      error: (error) => {
        console.error('Claim submission failed:', error);
        this.errorMessage =
          error.error?.message || 'Unable to submit claim. Please try again.';
      }
    });
  }
}
