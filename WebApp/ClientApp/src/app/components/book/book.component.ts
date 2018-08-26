import { Component, OnInit } from '@angular/core';
import { BookService } from '../../services/book.service';
import { Book } from '../../models/book';
import { Router } from '@angular/router';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {
  books: Book[];
  constructor(private bookService:BookService) { }

  ngOnInit() {
    this.bookService.getBooks().subscribe(data=>{
      this.books = data as Book[];
    });
  }

}
