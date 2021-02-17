import { Component, OnInit } from '@angular/core';
import { PhoneService, IGetPhoneResponses } from './services/phone.service';

interface ITable {
  id: number;
  nome: string;
  telefone: string;
  tipoTelefone: EnumTipoTelefone;
}

export enum EnumTipoTelefone {
  LocalPhone = 1,
  CellPhone = 2,
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'Frontend';

  telefones: ITable[] = [];

  id: number = 0;
  iptNome: string = "User One";
  iptTelefone: string = ""
  slcTipoTelefone: EnumTipoTelefone = EnumTipoTelefone.CellPhone;

  constructor(private _phoneService: PhoneService){
  }

  listagem() {
    this._phoneService.getPhonesByPersonId(1).then(resposta=>{
      this.telefones = resposta.phones.map((elemento, index) => {
        return {
          id: Date.now() + index,
          nome: resposta.name,
          telefone: elemento.phoneNumber,
          tipoTelefone: elemento.phoneNumberTypeId
        }
      });
    })
  
  }

  clickTable(telefone: ITable){
    this.id = telefone.id;
    this.iptNome = telefone.nome;
    this.iptTelefone = telefone.telefone;
    this.slcTipoTelefone = telefone.tipoTelefone;
    console.log(telefone);
    
  }

  salvarDados(){
    if(this.id === 0){
      this.telefones.push({
        id: Date.now() * -1,
        nome: this.iptNome,
        telefone: this.iptTelefone,
        tipoTelefone: this.slcTipoTelefone,
      })
    }else{
      const tel = this.telefones.find(x=>x.id === this.id);

      if (!tel) return;

      tel.nome = this.iptNome;
      tel.telefone = this.iptTelefone;
      tel.tipoTelefone = this.slcTipoTelefone;
    }

    console.log(this.telefones);
    
    this.limparCampos()
  }

  limparCampos(){
    this.id=0,
    this.iptNome="User One",
    this.iptTelefone="",
    this.slcTipoTelefone=EnumTipoTelefone.CellPhone
  }

  salvarDadosNoBanco(){
    const params: IGetPhoneResponses = {
      id: 1,
      name: "User One",
      phones: this.telefones.map(elemento=>{
        return {
          businessEntityId: 1,
          phoneNumber: elemento.telefone,
          phoneNumberTypeId: elemento.tipoTelefone
        }
      })
    }

    this._phoneService.savePhonesByPersonId(params).then(resposta=>{
      this.listagem();
    })
  }

  ngOnInit(): void {
    this.listagem();
  }

  deletar(){
    this.telefones = this.telefones.filter(el => el.id !== this.id);
  }


}
