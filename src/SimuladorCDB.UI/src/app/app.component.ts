import { Component } from '@angular/core';
import { CDBService } from '../services/cdb.service';
import { PrevisaoCDBRequest } from '../models/previsaoCDBRequest';
import { PrevisaoCDBResponse } from '../models/previsaoCDBResponse';
import { ApiError } from '../models/apiError';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Simulador de investimento em CDB';
  displayMes = "Meses";
  displayMesResult = 2;
  displayMesExtensoResult = "Meses";

  request = new PrevisaoCDBRequest(1000, 2);
  response = new PrevisaoCDBResponse(0, 0, 0, 0, 0, 0, 0);
  apiError : Array<ApiError> = [];
  error = '';

  constructor(private cdbService: CDBService) {
    this.initialize();
  }

  initialize(): void {
    this.error = '';
    this.obterPrevisaoCDB();
  }

  atualizaValorAporte(operacao: string) {
    if (operacao == "adiciona") {
      this.request.aporteInicial += 250;
    } else if (operacao == "subtrai") {
      if (this.request.aporteInicial != 0) {
        this.request.aporteInicial -= 250;
      }
    }
    this.obterPrevisaoCDB();
  }

  atualizaValoresPrazos() {
    this.error = '';

    if (this.request.prazoParaResgate == 1) {
      this.displayMes = "Mês";
      this.displayMesResult = this.request.prazoParaResgate;
      this.displayMesExtensoResult = "Mês";
    }
    else if (this.request.prazoParaResgate == 12) {
      this.displayMesResult = this.returnAno(this.request.prazoParaResgate);
      this.displayMesExtensoResult = "Ano";
    }
    else if (this.request.prazoParaResgate > 12) {
      this.displayMesResult = this.returnAno(this.request.prazoParaResgate);
      this.displayMesExtensoResult = "Anos";
    }
    else {
      this.displayMes = "Meses";
      this.displayMesResult = this.request.prazoParaResgate;
      this.displayMesExtensoResult = "Meses";
    }
    this.obterPrevisaoCDB();
  }

  setPrazoResgate(e: string) {
    switch (e) {
      case '4':
        this.request.prazoParaResgate = 6;
        this.atualizaValoresPrazos();
        break;
      case '5':
        this.request.prazoParaResgate = 12;
        this.atualizaValoresPrazos();
        break;
      case '6':
        this.request.prazoParaResgate = 24;
        this.atualizaValoresPrazos();
        break;
      case '7':
        this.request.prazoParaResgate = 60;
        this.atualizaValoresPrazos();
        break;
      case '8':
        this.request.prazoParaResgate = 360;
        this.atualizaValoresPrazos();
        break;
      default:
        this.request.prazoParaResgate = +e;
        this.atualizaValoresPrazos();
    }
  }

  returnAno(mes: number) {
    return (mes / 12);
  }

  obterPrevisaoCDB() {
    if (this.request.aporteInicial != null && this.request.aporteInicial >= 1) {
      this.cdbService.obterPrevisaoCDB(this.request).subscribe(
        {
          next: (data) => {
            this.response = data
          },
          error: (erro) => {
            switch (erro.status) {
              case 400:
                this.apiError = erro.error;
                this.apiError.forEach((error) => {
                  this.error = error.errorMesage;
                });
            }
          }
        }
      );
    } else {
      this.response.valorTotalInvestimentoLiquido = 0;
      this.response.valorAporteInicial = 0;
      this.response.valorIRDebitar = 0;
    }
  }

}
