import { Component, OnInit,OnChanges,Input } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-commonform',
  templateUrl: './commonform.component.html',
  styleUrls: ['./commonform.component.css']
})
export class CommonformComponent implements OnInit,OnChanges {

//private comm:HttpClient
  constructor(private route:ActivatedRoute,private router: Router) {

   }

  isPopupOpen = false;
  chapterpopup = false;
  SubjectName = '';
  SubjectId = null;
  showValues = false;
  showdata = false;
  BookName = '';
  chanpterName = '';
  chapterId = '';
  bookidval = 0; 
  booklist:any[];
  chapterlist:any[];
  booklistBeforeLS:any[];
  subject="";
  @Input() tab

  ngOnChanges(){
    this.showValues = false;
    this.showdata = false;
    this.subject=this.router.url.split('/')[1];
    this.route.params.subscribe(params=>{
      console.log(params);
    })
    console.log(JSON.parse(localStorage.getItem('Booklistkey')));
    if(localStorage.getItem('Booklistkey')!=""){
    this.booklist=JSON.parse(localStorage.getItem('Booklistkey'))
    
    }

  }
  ngOnInit(): void {
    this.showValues = false;
    this.showdata = false;
    this.subject=this.router.url.split('/')[1];
    this.route.params.subscribe(params=>{
      console.log(params);
    })
  }

  GetSubject(bookID:number){
    this.router.navigate(['/Chem-book',bookID]);
  }

  openBookPopup(){
    this.isPopupOpen = !this.isPopupOpen;
    this.BookName = '';

  }

  //  void {
  //   this.isPopupOpen = !this.isPopupOpen;
  //   if (!this.isPopupOpen) {
  //     this.showValues = false;
  //     this.chanpterName=(this.chanpterName);
  //     this.chapterId=(this.chapterId);
  //   }


  addBooks(bookname, bookid) {
    console.log(bookname.value);
    this.bookidval = bookid.value;
    this.showValues = true;
    if (bookname.value.length > 0){
      // this.comm.post("http://172.16.16.27:4040/api/CommonCalls/GetLocations?CompanyID=1","").subscribe(response=>{

      //   console.log(response);
      //   this.userlist=response;
      //   })

      debugger;
    this.booklistBeforeLS.push({bookName: bookname.value, bookID: bookid.value, ChapterName: [],Subject:this.subject});
    const jsondata=JSON.stringify(this.booklistBeforeLS);
    localStorage.setItem('Booklistkey',jsondata);
    const responsejsondata=JSON.parse(localStorage.getItem('Booklistkey'));
    this.booklist=responsejsondata;
    bookname.value = '';

    }

  }
  onfiltersubject(){
    return this.booklist.filter(book=>{return book.Subject===this.subject});
  }
  ondeleteBook(bookno){
    this.booklist.splice(bookno, 1);
  }




  openChapterPopup(){
    this.chapterpopup = !this.chapterpopup;
    this.chanpterName = '';
    this.chapterId = '';

  }
  addChapters(chapter, bookid) {
    // console.log(bookid.value);
    this.showdata = true;
    if (chapter.value.length > 0){
    // this.chapterlist.push([{chapterName: chapter.value, bookid: this.bookidval}]);
    const length = this.booklist.length;

    this.booklist[length - 1].ChapterName.push({chapterName: chapter.value, bookid: this.bookidval});
    chapter.value = '';
  }
  }
}
