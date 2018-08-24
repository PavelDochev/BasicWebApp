import { Injectable} from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs/Observable';  
import 'rxjs/add/operator/map';  
import 'rxjs/add/operator/catch';  
import 'rxjs/add/observable/throw';  

@Injectable()
export class BookService {
    // books:any;

    constructor(private http: HttpClient) { }

    public getBooks(){
        return this.http.get('api/books')  
            .map((response: Response) => response.json())  
            .catch(this.errorHandler); 
    }

    
    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }
}