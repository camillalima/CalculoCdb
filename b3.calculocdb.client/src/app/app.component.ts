import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

export interface CalculoResponse {
  valorBruto: number;
  valorLiquido: number;
}
export interface ErroResponse {
  erro: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  public calculoResponse: CalculoResponse = {
    valorBruto: 0,
    valorLiquido: 0
  };

  public erroResponse: ErroResponse = {
    erro: '',
  };

  errorInputValorInvestidoMessage: string | null = null;
  errorInputPrazoMessage: string | null = null;

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  validateValorInvestido(input: HTMLInputElement) {
    const value = parseFloat(input.value);
    if (isNaN(value) || value <= 0) {
      this.errorInputValorInvestidoMessage = 'O valor investido deve ser positivo';
    } else {
      this.errorInputValorInvestidoMessage = null;
      this.calculoResponse.valorBruto = 0;
      this.calculoResponse.valorLiquido = 0;
    }
  }

  removeCaracterEspecial(input: HTMLInputElement) {
    const specialCharPattern = /[^0-9]/g;

    const cleanedValue = input.value.replace(specialCharPattern, '');

    input.value = cleanedValue;
  }

  validatePrazo(input: HTMLInputElement) {
    const value = parseFloat(input.value);
    if (isNaN(value) || value <= 1) {
      this.errorInputPrazoMessage = 'Os meses investindo deve ser maior que 1';
    } else {
      this.errorInputPrazoMessage = null;
      this.calculoResponse.valorBruto = 0;
      this.calculoResponse.valorLiquido = 0;
    }
  }

  getCalculoCdb() {
    this.erroResponse.erro = "";
    const inputValorInvestido = (document.getElementById('inputValorInvestido') as HTMLInputElement).value;
    const inputPrazo = (document.getElementById('inputPrazo') as HTMLInputElement).value;

    let params = new HttpParams()
      .set('valorInvestido', inputValorInvestido.toString())
      .set('prazo', inputPrazo.toString());

    this.http.get<any>('/api/calculo-cdb', {params}).subscribe(
      (result) => {
        this.calculoResponse = result;
      },
      (error) => {
        this.erroResponse.erro = error.error;
      }
    );
  }

  title = 'b3.calculocdb.client';
}
