import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {

  title: string = 'Welcome to Smart Certify';
  subtitle: string = 'Your gateway to certifications and skill growth';

  features = [
    { title: 'Test your knowledge', description: 'Test your knowledge with our interactive quizzes.' },
    { title: 'Earn Certifications', description: 'Earn recognized certifications to advance your career.' },
    { title: 'Resume Anytime', description: 'Learn at your own pace and resume where you left off.' },
    { title: 'Interactive Courses', description: 'Engage with our interactive learning modules.' },
    { title: 'Expert Mentors', description: 'Get guidance from industry professionals.' },
    { title: 'Global Certificates', description: 'Earn credentials recognized worldwide.' }
  ];
  techStacks = [
    { name: "Angular" },
    { name: "ASP.NET Core" },
    { name: "Entity Framework Core" },
    { name: "SQL Server" },
    { name: "Docker" },
    { name: "Kubernetes" },
    { name: "Azure" },
    { name: "AWS" },
    { name: "Git" },
    { name: "CI/CD" },
    { name: "Microservices" },
    { name: "RESTful APIs" },
    { name: "Blazor" },
    { name: "OAuth2" },
  ];

}
