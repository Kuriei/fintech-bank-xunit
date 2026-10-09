namespace FintechBank.App
{
    public class EmprestimoService
    {
        public decimal CalcularValorParcela(decimal valorTotal, int parcelas, int scoreCredito)
        {
            decimal valorComJuros;

            if (scoreCredito >= 700)
            {
                valorComJuros = valorTotal * 1.05m;
            }
            else if (scoreCredito >= 500 && scoreCredito <= 699)
            {
                valorComJuros = valorTotal * 1.12m;
            }
            else // scoreCredito < 500
            {
                valorComJuros = valorTotal * 1.20m;
            }

            return valorComJuros / parcelas;
        }

        public bool AprovarEmprestimo(decimal rendaMensal, decimal valorParcela)
        {
            // O empréstimo só é aprovado se a parcela for menor ou igual a 30% da renda mensal
            decimal limiteComprometimento = rendaMensal * 0.30m;
            return valorParcela <= limiteComprometimento;
        }
    }
}