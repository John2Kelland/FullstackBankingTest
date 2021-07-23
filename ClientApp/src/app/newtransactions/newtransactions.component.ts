import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-newtransactions',
  templateUrl: './newtransactions.component.html',
  styleUrls: ['./newtransactions.component.scss']
})

export class NewTransactionsComponent {
  public accounts: Account[];
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

    http.get<Account[]>(baseUrl + 'useraccounts')
      .subscribe(result => { this.accounts = result; }, error => { console.error(error); alert(error.error); });
  }

  public processTransaction(accId: string, transAmt: string, transType: string) {
    this.Http.put(this.BaseUrl + 'transactions', new String("AccountID:" + accId + ",TransactionAmount:" + transAmt + ",TransactionType:" + transType), this.HttpOptions)
      .subscribe(result => { alert("Transaction successfully processed!"); }, error => {
        alert(error.error);
        console.error(error);
      }
    );
  }
}
interface Account {
  username: string
  accountId: string;
  accountName: string;
  balance: number;
}
