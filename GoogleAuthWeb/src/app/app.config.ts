import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { SocialAuthServiceConfig } from '@abacritt/angularx-social-login';
import {
  GoogleLoginProvider,
} from '@abacritt/angularx-social-login';

import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes),
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              '783760968818-8om12a8q53aumhau5922g82glsla23kf.apps.googleusercontent.com'
            )
          }
        ],
        onError: (error) => {
          console.error(error);
        }
      } as SocialAuthServiceConfig,
    }
  ]
};
