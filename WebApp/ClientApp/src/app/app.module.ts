import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { BookComponent } from './components/book/book.component';
import { BookDetailsComponent } from './components/book-details/book-details.component';
import { AddBookComponent } from './components/add-book/add-book.component';
import { EditBookComponent } from './components/edit-book/edit-book.component';
import { BookService } from './services/book.service';
import { FilterPipe } from './Utils/filter.pipe';

const appRoutes: Routes = [
  {
    path: 'details/:BookID',
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
    path: 'edit/:BookID',
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
    FilterPipe
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    RouterModule.forRoot(
      appRoutes
    )
  ],
  providers: [BookService],
  bootstrap: [AppComponent]
})

export class AppModule { }
