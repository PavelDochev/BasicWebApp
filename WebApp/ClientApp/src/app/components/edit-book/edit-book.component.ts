import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BookService } from '../../services/book.service';
import { ServerUtil } from '../../Utils/ServerUtil';
import { Book } from '../../models/book';

@Component({
  selector: 'app-edit-book',
  templateUrl: './edit-book.component.html',
  styleUrls: ['./edit-book.component.css'],
})
export class EditBookComponent implements OnInit {
  book : Book = new Book;
  constructor(private bookService:BookService,
      private http:HttpClient,
      private router: Router,
      private route: ActivatedRoute) { }

  ngOnInit() {
    this.getBookDetail(this.route.snapshot.params['BookID']);
  }

  getBookDetail(id) {
    this.bookService.getBook(id).subscribe(data => {
      this.book = data;
    });
  }
  updateBook(id) {
    this.http.put(ServerUtil.SERVER_URL()+'api/books/' + id, this.book)
      .subscribe(res => {
        let id = res['BookID'];
        this.router.navigate(['/details', id]);
      }, (err) => {
        console.log(err);
      }
      );
  }
  deleteBook(id) {
    this.bookService.deleteBook(id).subscribe();
    this.router.navigate(['/books']);
  }
}
