import { Component } from '@angular/core';
import * as Constants from './constants';
@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css'
})
export class FooterComponent {
  instaURL = Constants.Constants._instaURL;
}
