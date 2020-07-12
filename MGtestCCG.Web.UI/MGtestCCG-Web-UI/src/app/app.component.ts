import { Component } from '@angular/core';

@Component({
  selector: 'pm-root',
  template: `
            <div class='container'>
              <router-outlet></router-outlet>
            </div>
  `,
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  pageTitle: string = 'Acme Product Management';
}
