import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Component({
    selector: 'app-users',
    templateUrl: './users.component.html',
    styleUrls: ['./users.component.scss']
})

export class UsersComponent {
  public systemUsers: SystemUser[];
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

    http.get<SystemUser[]>(baseUrl + 'systemusers')
      .subscribe(result => { this.systemUsers = result; }, error => console.error(error));
  }

  public addSystemProfile(email: string, username: string, password: string) {
    this.Http.post(this.BaseUrl + 'systemusers', new String("Email:" + email + ",Username:" + username + ",Password:" + password), this.HttpOptions)
      .subscribe(result => { alert("Posted" + JSON.stringify(result)); }, error => console.error(error));
  }
}

interface SystemUser {
  email: string;
  username: string;
  password: string;
}
