// import { NgModule } from '@angular/core';
// import { RouterModule, Routes } from '@angular/router';
// import { AddnewComponent } from './addnew/addnew.component';
// import { CustomerComponent } from './customer/customer.component';
// import { HomeComponent } from './home/home.component';
// import { ListingComponent } from './listing/listing.component';
// import { LoginComponent } from './login/login.component';
// import { RefillduesComponent } from './refilldues/refilldues.component';
// import { RefillstatusComponent } from './refillstatus/refillstatus.component';
// import { SearchdrugComponent } from './searchdrug/searchdrug.component';
// import { SearchdrugidComponent } from './searchdrugid/searchdrugid.component';
// import { AuthGuard } from './shared/auth.guard';
// import { RoleGuard } from './shared/role.guard';
// import { SubscribeComponent } from './subscribe/subscribe.component';

// const routes: Routes = [
//   { path: '', component: LoginComponent, canActivate: [AuthGuard] },
//   {
//     path: 'customer',
//     component: CustomerComponent,
//     children: [
//       {
//         path: '',
//         component: ListingComponent,
//       },
//       { path: 'create', component: AddnewComponent },
//       { path: 'Edit/:id', component: AddnewComponent },
//     ],
//     canActivate: [RoleGuard],
//   },
//   { path: 'login', component: LoginComponent },
//   { path: 'searchdrug', component: SearchdrugComponent },
//   { path: 'searchdrugid', component: SearchdrugidComponent },
//   { path: 'subscribe', component: SubscribeComponent },
//   { path: 'refillstatus', component: RefillstatusComponent },
//   { path: 'home', component: HomeComponent },
//   { path: 'refilldues', component: RefillduesComponent },
// ];

// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })
// export class AppRoutingModule { }
//Added this code

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddnewComponent } from './addnew/addnew.component';
import { CustomerComponent } from './customer/customer.component';
import { HomeComponent } from './home/home.component';
import { ListingComponent } from './listing/listing.component';
import { LoginComponent } from './login/login.component';
import { RefillduesComponent } from './refilldues/refilldues.component';
import { RefillstatusComponent } from './refillstatus/refillstatus.component';
import { SearchdrugComponent } from './searchdrug/searchdrug.component';
import { SearchdrugidComponent } from './searchdrugid/searchdrugid.component';
import { ViewComponent } from './view/view.component';
import { AuthGuard } from './shared/auth.guard';
import { RoleGuard } from './shared/role.guard';
import { SubscribeComponent } from './subscribe/subscribe.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  {
    path: 'customer',
    component: CustomerComponent,
    children: [
      {
        path: '',
        component: ListingComponent,
      },
      { path: 'create', component: AddnewComponent },
      { path: 'Edit/:id', component: AddnewComponent },
    ],
    canActivate: [RoleGuard],
  },
  { path: 'login', component: LoginComponent },
  {
    path: 'searchdrug',
    component: SearchdrugComponent,
    canActivate: [RoleGuard],
  },
  {
    path: 'searchdrugid',
    component: SearchdrugidComponent,
    canActivate: [RoleGuard],
  },
  {
    path: 'subscribe',
    component: SubscribeComponent,
    canActivate: [RoleGuard],
  },
  {
    path: 'refillstatus',
    component: RefillstatusComponent,
    canActivate: [RoleGuard],
  },
  { path: 'home', component: HomeComponent, canActivate: [RoleGuard] },
  {
    path: 'refilldues',
    component: RefillduesComponent,
    canActivate: [RoleGuard],
  },
  {
    path: 'view',
    component: ViewComponent,
    canActivate: [RoleGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
