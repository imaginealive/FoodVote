import { NgModule, ErrorHandler } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { MyApp } from './app.component';
import { HttpClientModule } from '@angular/common/http';

import { AboutPage } from '../pages/about/about';
import { ContactPage } from '../pages/contact/contact';
import { HomePage } from '../pages/home/home';
import { TabsPage } from '../pages/tabs/tabs';

import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { ShopPage } from '../pages/shop/shop';
import { LoginPage } from '../pages/login/login';
import { UserserviceProvider } from '../providers/userservice';
import { SharedserviceProvider } from '../providers/sharedservice';
import { CreatshopPage } from '../pages/creatshop/creatshop';
import { Home2Page } from '../pages/home2/home2';

@NgModule({
  declarations: [
    MyApp,
    AboutPage,
    ContactPage,
    HomePage,
    TabsPage,
    ShopPage,
    LoginPage,
    CreatshopPage,
    Home2Page
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(MyApp),
    HttpClientModule
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    AboutPage,
    ContactPage,
    HomePage,
    TabsPage,
    ShopPage,
    LoginPage,
    CreatshopPage,
    Home2Page
    
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler}, 
    UserserviceProvider,
    SharedserviceProvider
  ]
})
export class AppModule {}
