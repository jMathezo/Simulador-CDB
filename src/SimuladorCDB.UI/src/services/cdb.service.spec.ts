import { TestBed, } from '@angular/core/testing';
import { MockCDBService } from './cdb.moq.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { PrevisaoCDBRequest } from '../models/previsaoCDBRequest';

describe('CdbService', () => {
  let service: MockCDBService;
  const request = new PrevisaoCDBRequest(1000, 2);

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MockCDBService],
      imports: [HttpClientTestingModule]
    });

    service = TestBed.inject(MockCDBService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('dado um request válido retorna a previsão do CDB', () => {
    service.obterPrevisaoCDB(request).subscribe(response => {
      expect(response.valorTotalInvestimentoBruto).toEqual(1019.5344783999999);
      expect(response.valorRendimentoBruto).toEqual(19.534478399999898);
      expect(response.valorRendimentoLiquido).toEqual(15.139220759999944);
      expect(response.valorTotalInvestimentoLiquido).toEqual(1015.13922076);
      expect(response.valorIRDebitar).toEqual(4.395257639999977);
      expect(response.valorAporteInicial).toEqual(1000);
      expect(response.prazoParaResgate).toEqual(2);
    });
  });

});
