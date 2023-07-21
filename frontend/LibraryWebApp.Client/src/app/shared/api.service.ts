import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { environment } from '../../environments/environment';
import { Author } from './models/author.model';

@Injectable({
    providedIn: 'root'
})
export class ApiService {
    private apiUrl = environment.apiUrl;

    constructor(private http: HttpClient) {}

    public getAuthors(): Observable<Author[]> {
        return this.http.get<Author[]>(`${this.apiUrl}/authors`);
    }
}