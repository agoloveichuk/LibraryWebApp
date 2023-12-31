import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/layout/navbar/navbar.component';
import { FooterComponent } from './components/layout/footer/footer.component';
import { AuthorListComponent } from './components/authors/author-list/author-list.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { LoginFormComponent } from './components/auth/login-form/login-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterFormComponent } from './components/auth/register-form/register-form.component';
import { AuthInterceptor } from './shared/auth-interceptor';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    AuthorListComponent,
    LoginFormComponent,
    RegisterFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatButtonModule,
    MatInputModule,
    ReactiveFormsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
