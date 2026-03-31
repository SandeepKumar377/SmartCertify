import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header } from "./pages/header/header";
import { Footer } from "./pages/footer/footer";
import { Home } from "./components/home/home";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Header, Footer, Home],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('smartcertify.client');
}
