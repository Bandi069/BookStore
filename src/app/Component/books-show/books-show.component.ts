import { Component, OnInit } from '@angular/core';
import { BookServiceService } from 'src/app/Service/book-service.service';

@Component({
  selector: 'app-books-show',
  templateUrl: './books-show.component.html',
  styleUrls: ['./books-show.component.scss']
})
export class BooksShowComponent implements OnInit {
  listOfBooks: any;
  numberOfBooks:any;
  constructor(
    private bookService:BookServiceService
    ) { }

  ngOnInit() {
  }

  displayAllBooks(){
    this.bookService.getAllBooks();
  }
}
