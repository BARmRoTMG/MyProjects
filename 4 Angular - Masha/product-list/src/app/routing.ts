import {Routes, RouterModule} from '@angular/router';
import { CreateNewComponent } from './components/create-new/create-new.component';
import { HomeComponent } from './components/home/home.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { ProductListComponent } from './components/product-list/product-list.component';


const appRoutes: Routes = [
    {path: 'list', component: ProductListComponent},
    {path: 'product/:id', component: ProductDetailsComponent},
    {path: 'create', component: CreateNewComponent},
    {path: '', component: HomeComponent}
]

export const routing = RouterModule.forRoot(appRoutes);

