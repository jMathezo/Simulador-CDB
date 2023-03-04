import { Observable } from "rxjs";
import { PrevisaoCDBRequest } from "../models/previsaoCDBRequest";
import { PrevisaoCDBResponse } from "../models/previsaoCDBResponse";

export interface ICDBService {
  obterPrevisaoCDB(request: PrevisaoCDBRequest): Observable<PrevisaoCDBResponse>;
}
