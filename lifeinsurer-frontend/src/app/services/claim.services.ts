import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClaimService {

  private apiUrl = 'http://localhost:5197/api/Claims';

  constructor(private http: HttpClient) {}

  createClaim(claimData: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, claimData);
  }

  getClaims(): Observable<any[]> {
  return this.http.get<any[]>(this.apiUrl);
}

}
