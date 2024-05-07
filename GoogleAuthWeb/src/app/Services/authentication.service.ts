import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private apiUrl = 'https://localhost:7002'; // Replace with your backend API URL

  constructor(private http:HttpClient) {}

  loginWithUsernameAndPassword(username: string, password: string){
    // Assuming your backend API endpoint for username/password login is '/login'

  }

  loginWithGoogle(data:any){
    // Implement Google OAuth login logic here
    return this.http.post(`${this.apiUrl}/identity/google-login`, data);
  }
}
