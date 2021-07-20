import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Component({
    selector: 'app-accounts',
    templateUrl: './accounts.component.html',
    styleUrls: ['./accounts.component.scss']
})

export class AccountsComponent {
  public accounts: UserAccount[];
  public Http: HttpClient;
  public BaseUrl: string;
  public HttpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.Http = http;
    this.BaseUrl = baseUrl;

    http.get<UserAccount[]>(baseUrl + 'useraccounts')
      .subscribe(result => { this.accounts = result; }, error => console.error(error));
  }

  public addAccount(accId: string, accName: string) {
    this.Http.post(this.BaseUrl + 'useraccounts', new String("AccountID:"+accId+",AccountName:"+accName), this.HttpOptions)
      .subscribe(result => { alert("Posted" + JSON.stringify(result)); }, error => console.error(error));
  }
}

interface UserAccount {
  username: string
  accountId: number;
  accountName: string;
  balance: number;
}
