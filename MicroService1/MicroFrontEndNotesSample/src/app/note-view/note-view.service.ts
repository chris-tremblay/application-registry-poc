import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NoteViewService {
  constructor(private httpClient: HttpClient) { }

  getNoteById(id: number){
    return this.httpClient.get(`https://localhost:7099/Note/${id}`);
  }
}
