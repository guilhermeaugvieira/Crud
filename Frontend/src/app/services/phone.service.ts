import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnumTipoTelefone } from '../app.component';

export interface IGetPhoneResponses{
  id: number,
  name: string,
  phones: {
    businessEntityId: number,
    phoneNumber: string,
    phoneNumberTypeId: EnumTipoTelefone
  }[]
}

@Injectable({
  providedIn: 'root'
})
export class PhoneService {

  urlApi: string = "http://localhost:5000/"

  constructor(private _http : HttpClient) { }

  getPhonesByPersonId(id: number){
    return this._http.get<IGetPhoneResponses>(`${this.urlApi}api/phone/${id}`).toPromise();
  }

  savePhonesByPersonId(params: IGetPhoneResponses){
    return this._http.put(`${this.urlApi}api/phone`, params).toPromise();
  }
}
