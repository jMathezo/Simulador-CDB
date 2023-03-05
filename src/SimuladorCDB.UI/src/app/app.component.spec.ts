import { TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';

describe('AppComponent', () => {

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [
        AppComponent
      ],
      imports: [
        HttpClientTestingModule,
        FormsModule
      ],
    }).compileComponents();
  });

  it('deve criar o app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it('atualizaValorAporte passando adiciona deve adicionar valoraporte', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    fixture.detectChanges();

    app.atualizaValorAporte('adiciona');
    expect(app.request.aporteInicial).toEqual(1250);

    app.atualizaValorAporte('subtrai');
    expect(app.request.aporteInicial).toEqual(1000);
  });

  it('dado prazoResgate deve retornar valores compatíveis', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    fixture.detectChanges();

    app.request.prazoParaResgate = 1;
    app.atualizaValoresPrazos();

    expect(app.displayMes).toEqual('Mês');
    expect(app.displayMesResult).toEqual(app.request.prazoParaResgate);
    expect(app.displayMesExtensoResult).toEqual("Mês");

    app.request.prazoParaResgate = 3;
    app.atualizaValoresPrazos();

    expect(app.displayMes).toEqual('Meses');
    expect(app.displayMesResult).toEqual(app.request.prazoParaResgate);
    expect(app.displayMesExtensoResult).toEqual("Meses");

    app.request.prazoParaResgate = 12;
    app.atualizaValoresPrazos();

    expect(app.displayMes).toEqual('Meses');
    expect(app.displayMesResult).toEqual(1);
    expect(app.displayMesExtensoResult).toEqual("Ano");

    app.request.prazoParaResgate = 24;
    app.atualizaValoresPrazos();

    expect(app.displayMes).toEqual('Meses');
    expect(app.displayMesResult).toEqual(2);
    expect(app.displayMesExtensoResult).toEqual("Anos");
  });

  it('dado prazoResgate deve alterar o valor request.prazoParaResgate', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    fixture.detectChanges();

    app.setPrazoResgate('1');
    expect(app.request.prazoParaResgate).toEqual(1);

    app.setPrazoResgate('4');
    expect(app.request.prazoParaResgate).toEqual(6);

    app.setPrazoResgate('5');
    expect(app.request.prazoParaResgate).toEqual(12);

    app.setPrazoResgate('6');
    expect(app.request.prazoParaResgate).toEqual(24);

    app.setPrazoResgate('7');
    expect(app.request.prazoParaResgate).toEqual(60);

    app.setPrazoResgate('8');
    expect(app.request.prazoParaResgate).toEqual(360);
  });

});
