import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/temp-user/osoba';
import { Observable } from 'rxjs';
import { API_ADDRESS } from 'src/environments/appconfig';
import { AuthData } from 'src/environments/auth-data.model';


@Injectable()
export class AuthHttpService{

    private logOutAddress: string = `${API_ADDRESS}/Account/Logout`;
        base_url = "http://localhost:52295"

        user: string

        constructor(private http: HttpClient){

        }

        isLoggedIn(): boolean {
            if(!localStorage.getItem('token'))
                return false;
            else
                return true;
        }
        
        // logIn(username: string, password: string){

        //     let data = `username=${username}&password=${password}&grant_type=password`;
        //     let httpOptions = {
        //         headers:{
        //             "Content-type": "application/x-www-form-urlencoded"
        //         }
        //     }
        //    // return this.http.get<any>(this.base_url + "/api/Account/GetTipKorisnika/" + username)
        //     this.http.post<any>(this.base_url + "/oauth/token",data, httpOptions )
        //     .subscribe(data => {
        //     localStorage.jwt = data.access_token;
        //     let jwtData = localStorage.jwt.split('.')[1]
        //     let decodedJwtJsonData = window.atob(jwtData)
        //     let decodedJwtData = JSON.parse(decodedJwtJsonData)

  
        //     let role = decodedJwtData.role
        //     this.user = decodedJwtData.unique_name;
            
        //     });
        //     //return this.http.get<any>(this.base_url + "/api/Account/GetTipKorisnika/" + username);
        // }
        
        // logIn2(username: string, password: string){

        //      this.http.get<any>(this.base_url + "/api/Account/GetTipKorisnika/" + username).subscribe();
        // }

        logIn(response: Response) : void {

            let responseJson = response.json();
            //let accessToken = responseJson.access_token;
            let role = response.headers.get('Role');
            let id = response.headers.get('UserId');
    
            //let authdata = new AuthData(accessToken, role, id);
            //localStorage.setItem('token', JSON.stringify(authdata));
            //console.log(authdata);
        }

        logOut(): Observable<any> {       
            if(this.isLoggedIn() === true) {
                let token = localStorage.getItem("token");
    
                let headers = new Headers();
                headers.append('Content-type', 'application/x-www-form-urlencoded');
                headers.append('Authorization', 'Bearer ' + JSON.parse(token).token);
    
                localStorage.removeItem('token');
    
                return this.http.post(this.logOutAddress, "", /*{ headers: headers }*/);
            }
        }

        isUser(): boolean {
            if(!this.isLoggedIn()) {
                return false;
            }
    
            let token = localStorage.getItem('token');
            let role = JSON.parse(token).role;
    
            if (role=="User") {
                return true;
            } else {
                return false;
            }
        }

        registration(data:User)
        {
             return this.http.post<any>(this.base_url + "/api/Account/Register", data).subscribe();
            
        }

        GetCenaKarte(tip: string): Observable<any>{
            return this.http.get<any>(this.base_url + "/api/PriceOfTickets/GetKarta/" + tip);
        }
        GetKupiKartu(tipKarte: string, tipKorisnika: string, user : string): Observable<any>{
           
            return this.http.get<any>(this.base_url + "/api/PriceOfTickets/GetKartaKupi2/" + tipKarte + "/" + tipKorisnika + "/" + user);
        }
        GetAllLines() : Observable<any>{
            return Observable.create((observer) => {
                this.http.get<any>(this.base_url + "/api/Lines/GetLinije").subscribe(data =>{
                    observer.next(data);
                    observer.complete();
                }) 
            });
        }
        GetTipKorisnika(user : string): Observable<any>{
           
            return this.http.get<any>(this.base_url + "/api/Account/GetTipKorisnika/" + user);
        }
}