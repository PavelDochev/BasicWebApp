import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from '../../services/book.service';
import { Book } from '../../models/book';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css'],
})
export class BookDetailsComponent implements OnInit {
  book:Book = new Book;
  constructor(private router: Router, private route: ActivatedRoute, private bookService:BookService) { }

  ngOnInit() {
    this.getBookDetail(this.route.snapshot.params['BookID']);
  }

  getBookDetail(id) {
    this.bookService.getBook(id).subscribe(data=>{
      this.book = data as Book;
    });
  }

  deleteBook(id) {
    this.bookService.deleteBook(id).subscribe();
    this.router.navigate(['/books']);
  }
}
