import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class StateSelectorService {

  private baseUrl = 'http://localhost:45265'

  constructor(private http: HttpClient) {
      
  }

  public loadStates(): Promise<string[]> {
    return this.http.get<string[]>(`${this.baseUrl}/states`).toPromise();
  }
}
