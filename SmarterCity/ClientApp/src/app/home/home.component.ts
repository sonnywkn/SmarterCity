import { Component, Directive, Inject, Input, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  public clients: Client[] = [];
  public selectedClient!: Client;
  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;

    this.http.get<Client[]>(this.baseUrl + 'client')
      .subscribe(result => {
        this.clients = result;
      }, error => console.error(error));   
  }

  onSubmit(f: NgForm) {
    this.http.post<Client>(this.baseUrl + 'client', f.value)
      .subscribe(result => {
        this.clients.push(result)
      }, error => console.error(error));
  }

  onClientClick(client: Client) {
    this.selectedClient = client;
  }
}

export interface Client {
  firstName?: string;
  lastName?: string;
  email?: string;
  mobileNumber?: string;
  address?: string;
}
