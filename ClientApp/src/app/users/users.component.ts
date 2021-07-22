import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Component({
    selector: 'app-users',
    templateUrl: './users.component.html',
    styleUrls: ['./users.component.scss']
})

export class UsersComponent {
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
    const headers = new HttpHeaders().set('Content-Type', 'text/plain; charset=utf-8');

    http.get<string>(baseUrl + 'systemusers', { headers, responseType: 'text' as 'json' })
      .subscribe(result => {
        (document.getElementById('activeUserMsg') as HTMLInputElement).value = result;
      }, error => console.error(error));
  }

  public addSystemProfile(email: string, username: string, password: string) {
    this.Http.post(this.BaseUrl + 'systemusers', new String("Email:" + email + ",Username:" + username + ",Password:" + password), this.HttpOptions)
      .subscribe(result => {
        alert("Profile successfully added!");
      }, error => {
        alert("There was a problem registering this user information.");
        console.error(error);
      }
     );

    (document.getElementById('email') as HTMLInputElement).value = "";
    (document.getElementById('usernm') as HTMLInputElement).value = "";
    (document.getElementById('passwd') as HTMLInputElement).value = "";
  }

  public accessSystemProfile(username: string, password: string) {
    this.Http.put(this.BaseUrl + 'systemusers', new String("Username:" + username + ",Password:" + password), this.HttpOptions)
      .subscribe(result => {
        if (username == "signoutrequest") {
          alert("Sign-out was successful!");
        } else {
          alert("Access successfully granted!");
        }
      }, error => {
        alert("The provided credentials were not recognized.");
        console.error(error);
      }
    );

    (document.getElementById('sgnusernm') as HTMLInputElement).value = "";
    (document.getElementById('sgnpasswd') as HTMLInputElement).value = "";
  }
}

interface SystemUser {
  email: string;
  username: string;
  password: string;
}
