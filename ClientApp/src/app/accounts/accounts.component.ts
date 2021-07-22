import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

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
      .subscribe(result => { alert("Account successfully added!"); }, error => {
        alert(error.error);
        console.error(error);
      }
    );

    this.clearFields();
  }

  public updateAccount(accId: string, accName: string) {
    this.Http.put(this.BaseUrl + 'useraccounts', new String("AccountID:" + accId + ",AccountName:" + accName), this.HttpOptions)
      .subscribe(result => { alert("Account successfully updated!") }, error => {
        alert(error.error);
        console.error(error);
      }
    );

    this.clearFields();
  }

  public deleteAccount(accId: string) {
    this.Http.delete(this.BaseUrl + 'useraccounts/' + accId)
      .subscribe(result => { alert("Account successfully deleted!") }, error => {
        alert(error.error);
        console.error(error);
      }
    );

    this.clearFields();
  }

  public clearFields() {
    (document.getElementById('accId') as HTMLInputElement).value = "";
    (document.getElementById('accName') as HTMLInputElement).value = "";
    (document.getElementById('initBal') as HTMLInputElement).value = "";
    location.reload();
  }
}

interface UserAccount {
  username: string
  accountId: string;
  accountName: string;
  balance: number;
}
