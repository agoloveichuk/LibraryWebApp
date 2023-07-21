import { Component } from '@angular/core';
import { ApiService } from '../../../shared/api.service';
import { Author } from '../../../shared/models/author.model';

@Component({
    selector: 'app-author-list',
    templateUrl: './author-list.component.html',
    styleUrls: ['./author-list.component.scss']
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
