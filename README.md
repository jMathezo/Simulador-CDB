<h1 align="center">Simulador de investimento em CDB</h1>

## :memo: Problema apresentado
 Criação de uma tela web onde possa ser informado um valor monetário positivo, e um prazo em meses maior que1(um) para resgate da  aplicação. Após  solicitar  o  cálculo  do  investimento,  a  tela  deve apresentar o resultado bruto e o resultado líquido do investimento

Implementar soluções fundamentadas pelos princípios do SOLID, Testes unitários e performance.

[x] Ambos os projetos devem estar numa única solução do Visual Studio para facilitar a avaliação.
[x] A solução deve ter um arquivo readme.mk com instruções para execução e testes da solução.
[x] O projeto Web deve ser feito em AngularCLI.
[x] A WebApi deve ser desenvolvida em .NET Framework 4.7.2 ou superior.
[x] A WebApi deve possuir cobertura de teste acima de 90 % na camada lógica.
[x] Teste unitário no Angular é um Stretch Go
[x] Os projetos não devem possuir alertas de análise de código nativa do Visual Studio, tão pouco de regras padrão do Sonar. Recomendamos a extensão do SonarLint
[x] O teste deve ser versionado em repositório público no GitHub e e o link deve ser enviado juntamente com o currículo do desenvolvedo

## :computer: Tecnologias utilizadas
* Visual Studio 2022;
* .NET Core 6;
* Angular CLI;
* XUnit;
* SonarLint;

## :cd: Rodando o projeto

* Abrir a solução no visual studio;
* Startar o projeto SimuladorCDB.WebAPI
* navegar até a pasta do projeto src\SimuladorCDB.UI e executar os comandos abaixo

Para atualizar os pacotes do projeto:
> npm install

Para executar a aplicação:
>ng serve

obs.:
A WebAPI será iniciada na url https://localhost:7074
A aplicação será iniciada na url http://localhost:4200