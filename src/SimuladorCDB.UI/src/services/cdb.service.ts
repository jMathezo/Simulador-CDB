import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { API_PATH } from '../environments/environment';
import { PrevisaoCDBRequest } from '../models/previsaoCDBRequest';
import { PrevisaoCDBResponse } from '../models/previsaoCDBResponse';
import { ICDBService } from './cdb.interface';

@Injectable({
  providedIn: 'root'
})
export class CDBService implements ICDBService {

  constructor(private httpClient: HttpClient) {
  }

  obterPrevisaoCDB(request: PrevisaoCDBRequest): Observable<PrevisaoCDBResponse> {
    let params = new HttpParams()
      .append('ValorAporteInicial', request.aporteInicial)
      .append('PrazoParaResgate', request.prazoParaResgate);

    return this.httpClient.get<PrevisaoCDBResponse>(`${API_PATH}CalcularCDB`, { params: params }).pipe(take(1));
  }

}
