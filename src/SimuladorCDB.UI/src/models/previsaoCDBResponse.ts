export class PrevisaoCDBResponse {
  valorTotalInvestimentoBruto: number
  valorRendimentoBruto: number
  valorRendimentoLiquido: number
  valorTotalInvestimentoLiquido: number
  valorIRDebitar: number
  valorAporteInicial: number
  prazoParaResgate: number

  constructor(
    valorTotalInvestimentoBruto: number,
    valorRendimentoBruto: number,
    valorRendimentoLiquido: number,
    valorTotalInvestimentoLiquido: number,
    valorIRDebitar: number,
    valorAporteInicial: number,
    prazoParaResgate: number
  ) {
    this.valorTotalInvestimentoBruto = valorTotalInvestimentoBruto;
    this.valorRendimentoBruto = valorRendimentoBruto;
    this.valorRendimentoLiquido = valorRendimentoLiquido;
    this.valorTotalInvestimentoLiquido = valorTotalInvestimentoLiquido;
    this.valorIRDebitar = valorIRDebitar;
    this.valorAporteInicial = valorAporteInicial;
    this.prazoParaResgate = prazoParaResgate
  }
}
