import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SocialAuthService, GoogleSigninButtonModule } from '@abacritt/angularx-social-login';
import { SignInComponent } from './sign-in/sign-in.component';
import { HttpClientModule } from '@angular/common/http';
import { AuthenticationService } from './Services/authentication.service';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,GoogleSigninButtonModule, SignInComponent, HttpClientModule],
  providers: [AuthenticationService],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  constructor( private authService:SocialAuthService) {}

  ngOnInit(): void {
    this.authService.authState.subscribe((user) => {
      console.log(user)
      //perform further logics
    });
  }

  
}
