import { AuthModule } from './auth/auth.module';
import { RegisterModule } from './register/register.module';
import { BrowseModule } from './browse/browse.module';
import { AppRoutes } from './app.routing';
import { HomeModule } from './home/home.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { TabMenuModule } from 'primeng/primeng';
import { AppComponent } from './app.component';


@NgModule({
  declarations: [
    AppComponent
    ],
  imports: [
    BrowserModule,
    TabMenuModule,
    FormsModule,
    HttpModule,
    AppRoutes,
    HomeModule,
    AuthModule,
    BrowseModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
