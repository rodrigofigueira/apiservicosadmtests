//namespace apiservicosadm.tests;

//public class BlitzInteligenteFactoryCreate
//{
//    [Theory]
//    [InlineData("BlitzInteligenteServicePorId", 1, "abc1acd")]
//    [InlineData("BlitzInteligenteServicePorPlaca", null, "abc1acd")]
//    public void RetornaInstanciaCorretaParaParametrosDeEntrada(string nomeTipoEsperado,
//                                                               int? id = null,
//                                                               string? placa = null)
//    {
//        //arrange
//        ParametrosBlitzInteligente parametros = new(Id: id, Placa: placa);

//        //act
//        var serviceRetornada = new BlitzInteligenteFactory(null, null).Create(parametros);

//        //assert
//        Assert.Equal(nomeTipoEsperado, serviceRetornada.GetType().Name);
//    }

//    [Fact]
//    public void RetornaArgumentExceptionParaParametrosInvalidosDeEntrada()
//    {
//        //arrange
//        ParametrosBlitzInteligente parametros = new();

//        //act & assert
//        var retorno = Assert.Throws<ArgumentException>(
//                      () => new BlitzInteligenteFactory(null, null).Create(parametros));
//    }
//}
