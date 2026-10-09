namespace FintechBank.App
{
    public class ContaCorrenteService
    {
        public decimal CalcularTaxaManutencao(decimal saldo, bool clienteEspecial)
        {
            if (saldo >= 5000.00m || clienteEspecial)
            {
                return 0.00m;
            }
            if (saldo >= 1000.00m && saldo <= 4999.99m)
            {
                return 12.50m;
            }
            
            // Saldo menor que R$ 1.000,00 (e não especial)
            return 25.00m; 
        }

        public bool PodeRealizarSaque(decimal saldo, decimal limiteChequeEspecial, decimal valorSaque)
        {
            return valorSaque <= (saldo + limiteChequeEspecial);
        }
    }
}