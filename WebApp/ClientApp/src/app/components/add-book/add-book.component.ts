import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http'
import { Book } from '../../models/book';
import { ServerUtil } from '../../Utils/ServerUtil';
import { BookService } from '../../services/book.service';
import { BookType } from '../../models/bookTypes';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css'],
})
export class AddBookComponent implements OnInit {
  book : Book = new Book;
  selectedValue:number;
  bookTypes:BookType[];

  constructor(private http: HttpClient, private router: Router,private bookService:BookService) { }

  ngOnInit() {
    this.bookService.getBookTypes().subscribe(data=>{
      this.bookTypes = data as BookType[];
    });
  }

  createBook() {
    this.http.post(ServerUtil.SERVER_URL()+'api/books', this.book)
        .subscribe(res => {
          this.router.navigate(['/details', res]);
        }, (err) => {
          console.log(err);
        }
      );
  }

}
