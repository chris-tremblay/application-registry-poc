import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class SampleDataService {
  constructor(private httpClient: HttpClient) { }

  getSampleList(){
    return this.httpClient.get(`https://localhost:7099/Note/List`);
  }
}
