import { Component } from '@angular/core';

@Component({
  selector: 'app-button',
  template: `<button (click)="handleClick()">Click me</button>`,
  styles: [`button { font-size: 16px; padding: 10px; }`]
})
export class ButtonComponent {
  handleClick() {
    console.log('Button clicked!');
  }
}