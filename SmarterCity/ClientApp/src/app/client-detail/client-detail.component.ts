import { Component, Input } from '@angular/core';
import { Client } from '../home/home.component';

@Component({
  selector: 'client-detail',
  templateUrl: './client-detail.component.html',
})

export class ClientDetailComponent {
  @Input() client!: Client;
}
