import { Component } from '@angular/core';
import { ApiService } from '../../../shared/api.service';
import { Author } from '../../../shared/models/author.model';

@Component({
  selector: 'app-author-list',
  template: `
    <h2>Authors List</h2>
    <button (click)="onFetchAuthors()">Fetch Authors</button>
    <ul>
      <li *ngFor="let author of authors">
        {{ author.name }} (ID: {{ author.id }}) - Date of Birth: {{ author.dateOfBirth | date }}
      </li>
    </ul>
  `
})
export class AuthorListComponent {
  authors: Author[] = [];

  constructor(private apiService: ApiService) {}

  onFetchAuthors(): void {
    this.apiService.getAuthors().subscribe((authors : Author[]) => {
      this.authors = authors;
    });
  }
}
