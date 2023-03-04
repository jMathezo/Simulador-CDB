import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { PrevisaoCDBRequest } from '../models/previsaoCDBRequest';
import { PrevisaoCDBResponse } from '../models/previsaoCDBResponse';
import { ICDBService } from './cdb.interface';

@Injectable({
  providedIn: 'root'
})
export class MockCDBService implements ICDBService {
  obterPrevisaoCDB(request: PrevisaoCDBRequest): Observable<PrevisaoCDBResponse> {
    return of(new PrevisaoCDBResponse(
      1019.5344783999999, 19.534478399999898, 15.139220759999944,
      1015.13922076, 4.395257639999977, 1000, 2))
  }
}
