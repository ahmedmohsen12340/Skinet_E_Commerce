import { Routes } from '@angular/router';

export const routes: Routes =
  [
    { path: "", loadComponent: () => import("../Components/home/home.component").then(c => c.HomeComponent),data:{breadcrumb: "home"} },
    { path: "shop", loadComponent: () => import("../Components/shop/shop.component").then(c => c.ShopComponent) },
    { path: "shop/:id", loadComponent: () => import("../Components/product-details/product-details.component").then(c => c.ProductDetailsComponent),data:{breadcrumb : {alias:"productDetails"}} },
    { path: "errors", loadComponent: () => import("../Components/buggy/buggy.component").then(c => c.BuggyComponent) },
    { path: "notFound", loadComponent: () => import("../Components/not-found/not-found.component").then(c => c.NotFoundComponent) },
    { path: "serverError", loadComponent: () => import("../Components/server-error/server-error.component").then(c => c.ServerErrorComponent) },
    { path: "**", redirectTo: "", pathMatch: 'full' }
  ];
