import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { GoogleLoginProvider, GoogleSigninButtonModule, SocialAuthService } from '@abacritt/angularx-social-login';
import { Subscription } from 'rxjs';
import { AuthenticationService } from '../Services/authentication.service';

@Component({
  selector: 'app-sign-in',
  standalone: true,
  imports: [FormsModule,GoogleSigninButtonModule],
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.scss'
})
export class SignInComponent {

  private socialAuthSubscription: Subscription | undefined;
  username: string = '';
  password: string = '';
 
  constructor(private socialAuthService: SocialAuthService, 
    private authService:AuthenticationService
  ) {
    this.socialAuthService.authState.subscribe((user) => {
      console.log(user)
      this.loginWithGoogle(user.idToken);
      //perform further logics
    });
  }

  login() {
    // Call your authentication service to perform username/password login
    
  }


  loginWithGoogle(idToken:string): void {
    this.authService.loginWithGoogle({idToken:idToken}).subscribe({
      next:(accessToken) => {
        localStorage.setItem('AccessToken', accessToken.toString());
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

  ngOnDestroy(): void {
    if (this.socialAuthSubscription) {
      this.socialAuthSubscription.unsubscribe();
    }
  }

  register(){

  }
}
