using atividadeAv;
using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

Academia academia = new Academia();

academia.AdicionaCliente();
academia.AdicionaTreinadores();
academia.AdicionaExercicio();
academia.AdicionaTreinos();

academia.RelatorioTreinadoresIntevaloIdades(40, 60);
academia.RelatorioClientesIntevaloIdades(23, 50);
academia.RelatorioClientesIMCMaior(21);
academia.RelatorioClientesOrdemAlfabetica();
academia.RelatorioClientesOrdemIdade();
academia.RelatorioAniversariantesDoMes(10);
academia.RelatorioTreinadoresOrdemDecrescente();
academia.RelatorioTreinosOrdemCrescenteQtdVencimento();