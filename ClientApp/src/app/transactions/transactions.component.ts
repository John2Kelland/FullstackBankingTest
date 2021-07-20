import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-transactions',
    templateUrl: './transactions.component.html',
    styleUrls: ['./transactions.component.scss']
})

export class TransactionsComponent {
  public accounts: UserAccount[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<UserAccount[]>(baseUrl + 'useraccounts').subscribe(result => {
      this.accounts = result;
    }, error => console.error(error));
  }
}

interface UserAccount {
  username: string
  accountId: number;
  accountName: string;
  balance: number;
}
