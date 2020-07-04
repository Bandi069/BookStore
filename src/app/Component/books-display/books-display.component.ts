import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { BookServiceService } from 'src/app/Service/book-service.service';

export interface PriceOrder {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-books-display',
  templateUrl: './books-display.component.html',
  styleUrls: ['./books-display.component.scss']
})

export class BooksDisplayComponent implements OnInit {
  totalBooksCount: any;
  p: number = 1;
  addedbgg: boolean = false;
  allBooks: any[];
  allimage: any;
  @Input() bookCount;
  @Output() pageChange: EventEmitter<number>;
  text: any;
  @Input() id: any;
  listOfBooks: any;
  numberOfBooks:any;
  constructor(
    private bookService: BookServiceService,
  ) { }

  ngOnInit() {
    this.getbookcount();
  }

  price: PriceOrder[] = [
    { value: 'LH', viewValue: 'Price:Low to High' },
    { value: 'HL', viewValue: 'Price:High to Low' },
    { value: 'NA', viewValue: 'New arrivals' }
  ];
  getbookcount() {
   // debugger;
    this.bookService.bookCount().subscribe(
      Response => {
        this.totalBooksCount = Response;
      })
  }
  getAllBooks()
  {
    this.bookService.getAllBooks().subscribe(
      Response=>{
      this.listOfBooks=Response;
      this.numberOfBooks=Response['length'];
      });
  }
}
