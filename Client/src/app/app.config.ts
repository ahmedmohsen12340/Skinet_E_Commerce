import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideAnimations } from '@angular/platform-browser/animations';
import { routes } from './app.routes';
import { provideHttpClient, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';
import { errorInterceptor } from '../Core/Interceptors/error.interceptor';
import { provideToastr } from 'ngx-toastr';
import { provideSpinnerConfig } from 'ngx-spinner';
import { loadingInterceptor } from '../Core/Interceptors/loading.interceptor';

export const appConfig: ApplicationConfig = {
  providers:
    [
    provideRouter(routes),
    provideHttpClient(withInterceptors([errorInterceptor,loadingInterceptor])),
    provideAnimations(),
    provideToastr({positionClass: "toast-bottom-right",preventDuplicates:true}),
    provideSpinnerConfig({ type: 'fire' }),
  ]
};
