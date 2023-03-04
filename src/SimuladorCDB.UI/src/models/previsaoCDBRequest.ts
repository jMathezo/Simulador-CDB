export class PrevisaoCDBRequest {
  aporteInicial: number
  prazoParaResgate: number

  constructor(aporteInicial: number, prazoParaResgate: number) {
    this.aporteInicial = aporteInicial;
    this.prazoParaResgate = prazoParaResgate;
  }
}
