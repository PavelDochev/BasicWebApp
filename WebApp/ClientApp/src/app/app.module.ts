import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { BookComponent } from './components/book/book.component';
import { BookDetailsComponent } from './components/book-details/book-details.component';
import { AddBookComponent } from './components/add-book/add-book.component';
import { EditBookComponent } from './components/edit-book/edit-book.component';

const appRoutes: Routes = [
  {
    path: 'details/:id',
    component: BookDetailsComponent,
    data: { title: 'Book Details' }
  },
  {
    path: '',
    component: BookComponent,
    data: { title: 'Book List' }
  },
  {
    path: 'books',
    component: BookComponent,
    data: { title: 'Book List' }
  },
  {
    path: 'create',
    component: AddBookComponent,
    data: { title: 'Add Book' }
  },
  {
    path: 'edit/:id',
    component: EditBookComponent,
    data: { title: 'Edit Book' }
  }
];

@NgModule({
  declarations: [
    AppComponent,
    BookComponent,
    BookDetailsComponent,
    AddBookComponent,
    EditBookComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(
      appRoutes
    )
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
