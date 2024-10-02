namespace apiservicosadm.tests;

public class BlitzInteligenteQueryBuilderTests
{

    [Fact]
    public void Criar_RetornaQueryComPlacaParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (
                                        SELECT distinct
                                            m.idVeiculo as IdDetranMonitor,
                                            m.Placa AS Placa,
                                            m.Marca AS Marca,
                                            m.Cor AS Cor,
                                            m.DataInclusao AS DataHora,
                                            CASE
                                                WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                        WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                        WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                        WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                        WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                        WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                        ELSE 'Regular'
                                            END AS Situacao,
                                            codfaixa,
                                            0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m 
                                             inner join fur_ocorrencia f
                                             on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (placa= @placa)";

        ParametrosBlitzInteligente parametros = new("1133-abc", "abc1bcd");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComPlacaParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (placa= @placa)";

        ParametrosBlitzInteligente parametros = new("01-abc", "abc1bcd");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComPlacaESituacaoInadimplenteParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (placa= @placa)
                                        and (situacao='inadimplente')";

        ParametrosBlitzInteligente parametros = new("1133-abc", "abc1bcd", "inadimplente");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComPlacaESituacaoInadimplenteParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (placa= @placa)
                                        and (situacao='inadimplente')";

        ParametrosBlitzInteligente parametros = new("01-abc", "abc1bcd", "inadimplente");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComPlacaESituacaoFurtadosParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (placa= @placa)
                                        and (situacao='furto/roubo')";

        ParametrosBlitzInteligente parametros = new("1133-abc", "abc1bcd", "furtado");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComPlacaESituacaoFurtadosParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (placa= @placa)
                                        and (situacao='furto/roubo')";

        ParametrosBlitzInteligente parametros = new("01-abc", "abc1bcd", "furtado");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComPlacaESituacaoRegularParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (placa= @placa)
                                        and (situacao='regular')";

        ParametrosBlitzInteligente parametros = new("1133-abc", "abc1bcd", "regular");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComPlacaESituacaoRegularParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (placa= @placa)
                                        and (situacao='regular')";

        ParametrosBlitzInteligente parametros = new("01-abc", "abc1bcd", "regular");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComPlacaESituacaoTodasParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (placa= @placa)
                                        ";

        ParametrosBlitzInteligente parametros = new("1133-abc", "abc1bcd", "todas");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComPlacaESituacaoTodasParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (placa= @placa)
                                        ";

        ParametrosBlitzInteligente parametros = new("01-abc", "abc1bcd", "todas");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComSituacaoRegularParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (situacao='regular')";

        ParametrosBlitzInteligente parametros = new("1133-abc", null!, "regular");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComSituacaoRegularParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (situacao='regular')";


        ParametrosBlitzInteligente parametros = new("01 -abc", null!, "regular");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComStatusAbordadoParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                                                on m.idVeiculo = f.idVeiculo) as a
                                                                where 1 = 1
                                                                and (abordagem = 1)";

        ParametrosBlitzInteligente parametros = new("1133-abc", null!, null!, "abordado");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComStatusAbordadoParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (abordagem = 1)";

        ParametrosBlitzInteligente parametros = new("01-abc", null!, null!, "abordado");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComStatusNaoAbordadoParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                                                on m.idVeiculo = f.idVeiculo) as a
                                                                where 1 = 1
                                                                and (abordagem = 0)";

        ParametrosBlitzInteligente parametros = new("1133-abc", null!, null!, "naoabordado");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComStatusNaoAbordadoParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (abordagem = 0)";

        ParametrosBlitzInteligente parametros = new("01-abc", null!, null!, "naoabordado");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComStatusAbordadoENaoAbordadoParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                                                on m.idVeiculo = f.idVeiculo) as a
                                                                where 1 = 1";

        ParametrosBlitzInteligente parametros = new("1133-abc", null!, null!, "abordado,naoabordado");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComStatusAbordadoENaoAbordadoParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1";

        ParametrosBlitzInteligente parametros = new("01-abc", null!, null!, "abordado,naoabordado");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComSituacaoRegularEStatusAbordadoParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (situacao='regular')
                                        and (abordagem = 1)";

        ParametrosBlitzInteligente parametros = new("1133-abc", null!, "regular", "abordado");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComSituacaoRegularEStatusAbordadoParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a 
                                        where 1 = 1
                                        and (situacao='regular')
                                        and (abordagem = 1)";

        ParametrosBlitzInteligente parametros = new("01-abc", null!, "regular", "abordado");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComStatusNaoAbordadoEPlacaParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                                                on m.idVeiculo = f.idVeiculo) as a
                                                                where 1 = 1
                                                                and (placa= @placa)
                                                                and (abordagem = 0)";

        ParametrosBlitzInteligente parametros = new("1133-abc", "abc1bcd", null!, "naoabordado");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComStatusNaoAbordadoEPlacaParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a 
                                        where 1 = 1
                                        and (placa= @placa)
                                        and (abordagem = 0)";

        ParametrosBlitzInteligente parametros = new("01-abc", "abc1bcd", null!, "naoabordado");

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComCodigoFaixaParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                                                on m.idVeiculo = f.idVeiculo) as a
                                                                where 1 = 1
                                                                and (codfaixa = @codigoFaixa)";

        ParametrosBlitzInteligente parametros = new("1133-abc", null!, null!, null!, 2);

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComCodigoFaixaParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (codfaixa = @codigoFaixa)";

        ParametrosBlitzInteligente parametros = new("01-abc", null!, null!, null!, 1);

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComDataInicioParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (DataHora >= @dataInicio)";

        ParametrosBlitzInteligente parametros = new("1133-abc", null!, null!, null!, null!, DateTime.Now);

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComDataInicioParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (DataHora >= @dataInicio)";

        ParametrosBlitzInteligente parametros = new("01-abc", null!, null!, null!, null!, DateTime.Now);

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComDataInicioEDataFimParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (DataHora BETWEEN @dataInicio AND @dataFim)";

        ParametrosBlitzInteligente parametros = new("1133-abc", null!, null!, null!, null!, DateTime.Now, DateTime.Now);

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComDataInicioEDataFimParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (DataHora BETWEEN @dataInicio AND @dataFim)";

        ParametrosBlitzInteligente parametros = new("01-abc", null!, null!, null!, null!, DateTime.Now, DateTime.Now);

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComPaginacaoParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        order by DataHora
                                        offset @qtdRegistrosParaPular ROWS
                                        FETCH next @qtdDeRegistroParaRetornar ROW Only;";

        ParametrosBlitzInteligente parametros = new("1133-abc", null!, null!, null!, null!, null!, null!, 2, 5);

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryComPaginacaoParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        order by DataHora
                                        offset @qtdRegistrosParaPular ROWS
                                        FETCH next @qtdDeRegistroParaRetornar ROW Only;";

        ParametrosBlitzInteligente parametros = new("01-abc", null!, null!, null!, null!, null!, null!, 1, 10);

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryCompletaParaSesdecLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        0 as Abordagem
                                        FROM Sesdec_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (placa= @placa)
                                        and (situacao='regular')
                                        and (abordagem = 1)
                                        and (codfaixa = @codigoFaixa)
                                        and (DataHora BETWEEN @dataInicio AND @dataFim)
                                        order by DataHora
                                        offset @qtdRegistrosParaPular ROWS
                                        FETCH next @qtdDeRegistroParaRetornar ROW Only;";

        ParametrosBlitzInteligente parametros = new("1133-abc", "abc1234", "regular", "abordado", 1, DateTime.Now, DateTime.Now, 2, 5);

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryCompletaParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select * from (SELECT distinct
                                        m.idVeiculo as IdDetranMonitor,
                                        m.Placa AS Placa,
                                        m.Marca AS Marca,
                                        m.Cor AS Cor,
                                        m.DataInclusao AS DataHora,
                                        CASE
                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                    ELSE 'Regular'
                                        END AS Situacao,
                                        codfaixa,
                                        m.abordagem as Abordagem
                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (placa= @placa)
                                        and (situacao='regular')
                                        and (abordagem = 1)
                                        and (codfaixa = @codigoFaixa)
                                        and (DataHora BETWEEN @dataInicio AND @dataFim)
                                        order by DataHora
                                        offset @qtdRegistrosParaPular ROWS
                                        FETCH next @qtdDeRegistroParaRetornar ROW Only;";

        ParametrosBlitzInteligente parametros = new("01-abc", "abc1234", "regular", "abordado", 1, DateTime.Now, DateTime.Now, 2, 5);

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().Build(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void RetornaParametrosParaPesquisa_CalculaPaginacao()
    {
        //arrange
        ParametrosBlitzInteligente parametros = new("01-abc", "abc1234", "regular", "abordado", 1, DateTime.Now, DateTime.Now, 10, 2);
        const int QTD_REGISTROS_PARA_PULAR_EXPERADO = 10;
        const int QTD_REGISTROS_PARA_RETORNAR_EXPERADO = 10;

        //act
        var retorno = parametros.BuildParametros();
        var propQtdRegistrosParaPular = retorno.GetType().GetProperty("QtdRegistrosParaPular");
        var propQtdRegistrosParaRetornar = retorno.GetType().GetProperty("QtdDeRegistroParaRetornar");

        //assert
        Assert.NotNull(retorno);
        Assert.Equal(QTD_REGISTROS_PARA_PULAR_EXPERADO, (int)propQtdRegistrosParaPular!.GetValue(retorno)!);
        Assert.Equal(QTD_REGISTROS_PARA_RETORNAR_EXPERADO, (int)propQtdRegistrosParaRetornar!.GetValue(retorno)!);
    }

    [Fact]
    public void RetornaParametrosParaPesquisa_Retorna0RegistrosParaPular()
    {
        //arrange
        ParametrosBlitzInteligente parametros = new(null!, null!, null!, null!, null!, null!, null!, 10, 1);
        const int QTD_REGISTROS_PARA_PULAR_EXPERADO = 0;
        const int QTD_REGISTROS_PARA_RETORNAR_EXPERADO = 10;

        //act
        var retorno = parametros.BuildParametros();
        var propQtdRegistrosParaPular = retorno.GetType().GetProperty("QtdRegistrosParaPular");
        var propQtdRegistrosParaRetornar = retorno.GetType().GetProperty("QtdDeRegistroParaRetornar");

        //assert
        Assert.Equal(QTD_REGISTROS_PARA_PULAR_EXPERADO, (int)propQtdRegistrosParaPular!.GetValue(retorno)!);
        Assert.Equal(QTD_REGISTROS_PARA_RETORNAR_EXPERADO, (int)propQtdRegistrosParaRetornar!.GetValue(retorno)!);
    }

    [Fact]
    public void RetornaParametrosParaPesquisa_RetornaCamposNulosParaParametrosNulos()
    {
        //arrange
        ParametrosBlitzInteligente parametros = new(null!, null!, null!, null!, null!, null!, null!, 10, 1);
        const int QTD_REGISTROS_PARA_PULAR_EXPERADO = 0;
        const int QTD_REGISTROS_PARA_RETORNAR_EXPERADO = 10;

        //act
        var retorno = parametros.BuildParametros();
        var propQtdRegistrosParaPular = retorno.GetType().GetProperty("QtdRegistrosParaPular");
        var propQtdRegistrosParaRetornar = retorno.GetType().GetProperty("QtdDeRegistroParaRetornar");

        //assert
        Assert.NotNull(retorno);
        Assert.Null(retorno.GetType().GetProperty("CampoQueNaoExiste")?.GetValue(retorno));
        Assert.Null(retorno.GetType().GetProperty("Placa")?.GetValue(retorno));
        Assert.Null(retorno.GetType().GetProperty("Situacao")?.GetValue(retorno));
        Assert.Null(retorno.GetType().GetProperty("DataInicio")?.GetValue(retorno));
        Assert.Null(retorno.GetType().GetProperty("DataFim")?.GetValue(retorno));
        Assert.Null(retorno.GetType().GetProperty("CodigoFaixa")?.GetValue(retorno));
        Assert.Null(retorno.GetType().GetProperty("NomeCamera")?.GetValue(retorno));
        Assert.Null(retorno.GetType().GetProperty("Status")?.GetValue(retorno));
        Assert.Equal(QTD_REGISTROS_PARA_PULAR_EXPERADO, (int)propQtdRegistrosParaPular!.GetValue(retorno)!);
        Assert.Equal(QTD_REGISTROS_PARA_RETORNAR_EXPERADO, (int)propQtdRegistrosParaRetornar!.GetValue(retorno)!);
    }

    [Fact]
    public void RetornaParametrosParaPesquisa_RetornaTodosCampos()
    {
        //arrange
        ParametrosBlitzInteligente parametros = new("01-abc", "abc1234", "regular", "abordado", 1, DateTime.Now, DateTime.Now, 10, 1);
        const int QTD_REGISTROS_PARA_PULAR_EXPERADO = 0;
        const int QTD_REGISTROS_PARA_RETORNAR_EXPERADO = 10;

        //act
        var retorno = parametros.BuildParametros();
        var propQtdRegistrosParaPular = retorno.GetType().GetProperty("QtdRegistrosParaPular");
        var propQtdRegistrosParaRetornar = retorno.GetType().GetProperty("QtdDeRegistroParaRetornar");

        //assert
        Assert.NotNull(retorno);
        Assert.Equal(parametros.Placa, retorno.GetType().GetProperty("Placa")?.GetValue(retorno));
        Assert.Equal(parametros.Situacao, retorno.GetType().GetProperty("Situacao")?.GetValue(retorno));
        Assert.Equal(parametros.DataInicio, retorno.GetType().GetProperty("DataInicio")?.GetValue(retorno));
        Assert.Equal(parametros.DataFim, retorno.GetType().GetProperty("DataFim")?.GetValue(retorno));
        Assert.Equal(parametros.CodigoFaixa, retorno.GetType().GetProperty("CodigoFaixa")?.GetValue(retorno));
        Assert.Equal(parametros.NomeCamera, retorno.GetType().GetProperty("NomeCamera")?.GetValue(retorno));
        Assert.Equal(parametros.Status, retorno.GetType().GetProperty("Status")?.GetValue(retorno));
        Assert.Equal(QTD_REGISTROS_PARA_PULAR_EXPERADO, (int)propQtdRegistrosParaPular!.GetValue(retorno)!);
        Assert.Equal(QTD_REGISTROS_PARA_RETORNAR_EXPERADO, (int)propQtdRegistrosParaRetornar!.GetValue(retorno)!);
    }

    [Fact]
    public void Criar_RetornaQueryCountCompletaParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select count(*) as total from (

                                    select * from (

                                                    SELECT distinct
                                                        m.idVeiculo as IdDetranMonitor,
                                                        m.Placa AS Placa,
                                                        m.Marca AS Marca,
                                                        m.Cor AS Cor,
                                                        m.DataInclusao AS DataHora,
                                                        CASE
                                                            WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                                    WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                                    WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                                    WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                                    WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                                    WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                                    ELSE 'Regular'
                                                        END AS Situacao,
                                                        codfaixa,
                                                        m.abordagem as Abordagem
                                                        FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                                        on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (placa= @placa)
                                        and (situacao='regular')
                                        and (abordagem = 1)
                                        and (codfaixa = @codigoFaixa)
                                        and (DataHora BETWEEN @dataInicio AND @dataFim)
                                        ) as a";

        ParametrosBlitzInteligente parametros = new("01-abc", "abc1234", "regular", "abordado", 1, DateTime.Now, DateTime.Now, 2, 5);

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().BuildCount(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

    [Fact]
    public void Criar_RetornaQueryCountCompletaComTodasSituacoesParaDetranLog()
    {
        //arrange
        string queryEsperada = @"select count(*) as total from (
    
                                select * from (
                                                        SELECT distinct
                                                            m.idVeiculo as IdDetranMonitor,
                                                            m.Placa AS Placa,
                                                            m.Marca AS Marca,
                                                            m.Cor AS Cor,
                                                            m.DataInclusao AS DataHora,
                                                            CASE
                                                                WHEN FLG_RouboFurto = 'S' THEN 'Furto/Roubo'
		                                                        WHEN inadimplencia = 'S' THEN 'Inadimplente'
		                                                        WHEN FLG_Judicial = 'S' THEN 'Judicial'
		                                                        WHEN FLG_Renajud = 'S' THEN 'Judicial'
		                                                        WHEN FLG_AdComunicadoVenda = 'S' THEN 'Comunicado de Venda'
		                                                        WHEN FLG_Administrativa = 'S' THEN 'Administrativa'
		                                                        ELSE 'Regular'
                                                            END AS Situacao,
                                                            codfaixa,
                                                            m.abordagem as Abordagem
                                                            FROM Detran_Log_CercoMonitoramento m inner join fur_ocorrencia f
                                                            on m.idVeiculo = f.idVeiculo) as a
                                        where 1 = 1
                                        and (placa= @placa)
                                        and (situacao='regular' or situacao='inadimplente' or situacao = 'Furto/Roubo')
                                        and (abordagem = 1)
                                        and (codfaixa = @codigoFaixa)
                                        and (DataHora BETWEEN @dataInicio AND @dataFim)
                                        ) as a";

        ParametrosBlitzInteligente parametros = new("01-abc", "abc1234", "regular,inadimplente,furtado", "abordado", 1, DateTime.Now, DateTime.Now, 2, 5);

        //act
        string queryGerada = new BlitzInteligenteQueryBuilder().BuildCount(parametros);

        //assert
        Assert.Equal(queryEsperada.NormalizarString(), queryGerada.NormalizarString());
    }

}