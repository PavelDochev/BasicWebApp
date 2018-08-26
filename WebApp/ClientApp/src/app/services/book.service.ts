import { Injectable} from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs/Observable';  
import 'rxjs/add/operator/map';  
import 'rxjs/add/operator/catch';  
import 'rxjs/add/observable/throw';  
import { ServerUtil } from "../Utils/ServerUtil";

@Injectable()
export class BookService {
    
    constructor(private http: HttpClient) { }

    public getBooks(){
        return this.http.get(ServerUtil.SERVER_URL()+'api/Books')  
            .map((response: Response) => response)  
            .catch(this.errorHandler); 
    }
    public getBook(id) {
        return this.http.get(ServerUtil.SERVER_URL()+'api/books/' + id)
        .map((response: Response) => response)  
        .catch(this.errorHandler); 
    }
    public deleteBook(id) {
        return this.http.delete(ServerUtil.SERVER_URL()+'api/books/' + id)
        .map((response: Response) => response)  
        .catch(this.errorHandler);
    }
    public getBookTypes(){
        return this.http.get(ServerUtil.SERVER_URL()+'api/booktypes')  
            .map((response: Response) => response)  
            .catch(this.errorHandler); 
    }

    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }
}