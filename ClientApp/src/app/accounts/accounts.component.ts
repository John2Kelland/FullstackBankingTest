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

  public addAccount(accId: string, accName: string, initBal: string) {
    this.Http.post(this.BaseUrl + 'useraccounts', new String("AccountID:" + accId + ",AccountName:" + accName + ",InitialBalance:" + initBal), this.HttpOptions)
      .subscribe(result => { alert("User account successfully added!"); }, error => {
        alert("There was an error adding the account.");
        console.error(error);
      }
    );

    this.clearFields();
  }

  public updateAccount(accId: string, accName: string) {
    this.Http.put(this.BaseUrl + 'useraccounts', new String("AccountID:" + accId + ",AccountName:" + accName), this.HttpOptions)
      .subscribe(result => { alert("User account successfully updated!") }, error => {
        alert("There was an error updating the account.");
        console.error(error);
      }
    );

    this.clearFields();
  }

  public deleteAccount(accId: string) {
    this.Http.delete(this.BaseUrl + 'useraccounts', { headers: new HttpHeaders({ 'Content-Type': 'application/json', 'body': accId }) })
      .subscribe(result => { alert("User account successfully deleted!") }, error => {
        alert("There was an error deleting the account.");
        console.error(error);
      }
    );

    this.clearFields();
  }

  public clearFields() {
    (document.getElementById('accId') as HTMLInputElement).value = "";
    (document.getElementById('accName') as HTMLInputElement).value = "";
    (document.getElementById('initBal') as HTMLInputElement).value = "";
  }
}

interface UserAccount {
  username: string
  accountId: number;
  accountName: string;
  balance: number;
}
