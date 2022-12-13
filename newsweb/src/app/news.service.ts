import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  constructor(private http:HttpClient) { }
  public search(term:string)
  {
    return this.http.get('https://newsapi.org/v2/top-headlines',
    {
      params:{
        q:term,
        language:"en",
        pageSize:40,
        apiKey:'a18c0e64f70341399388843ad9d7722d'
      }
    })
  }
  defaultnews()
  {
    return this.http.get('https://newsapi.org/v2/top-headlines',
    {
      params:{
        language:"en",
        pageSize:40,
        apiKey:'a18c0e64f70341399388843ad9d7722d'
      }
    })
  }
}
