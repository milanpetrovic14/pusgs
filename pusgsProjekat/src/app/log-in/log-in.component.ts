 import { Component, OnInit } from '@angular/core';
 import { NgForm } from '@angular/forms';
 import { Router } from '@angular/router';
import { User } from 'src/app/temp-user/osoba';
import { AuthHttpService } from 'src/app/services/http/auth.service';
import { LoginService } from '../services/login.service';


@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})

export class LogInComponent implements OnInit {
  private submitted: boolean = false;
  constructor(private authService: AuthHttpService, private loginService: LoginService, private router: Router) { }

  ngOnInit() {
    if(this.authService.isLoggedIn()) {
      this.router.navigate(['/']);  // vrati korisnika na pocetnu stranu 
    }
  }

 

  onLogin(f: NgForm): void {
    this.submitted = true;  // animation 
    
    this.loginService.logIn(`${f.value.email}`,`${f.value.password}`).subscribe( 
      (response) => { 
        this.authService.logIn(response);
       
        this.router.navigate(['/']);
      },

      // (error) => {
      //   this.submitted = false;  // animation 
      //   this.notificationService.notifyEvent.emit('An error ocurred while trying to log in. The server is probably down.');
      //   console.log(error);
      //   if(error.status !== 0){
      //     let errorBody = JSON.parse(error._body);
      //     this.notificationService.notifyEvent.emit(errorBody.error_description);
      //   }        
      // }
    );
  }
}