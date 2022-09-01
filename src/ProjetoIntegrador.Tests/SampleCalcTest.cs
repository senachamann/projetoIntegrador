namespace ProjetoIntegrador.Tests
{
    public class SampleCalcTest
    {
        [Fact]
        public void Deve_Somar_Dois_Resultados()
        {
            //Arranje. prepara os dados
            var calculadora = new Calculadora();
            var resultadoSoma = 20;
            var resultadoEsperado = 0;

            //Act - ação para ser testado
            resultadoEsperado = calculadora.Soma(10, 10);

            //Assert - validar os dados e as ações
            Assert.Equal(resultadoSoma, resultadoEsperado);
        }
    }

    public class Calculadora
    {
        public int Soma(int a, int b)
        {
            return a + b;
        }
    }
}