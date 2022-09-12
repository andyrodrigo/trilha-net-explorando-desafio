namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite( int id , string tipoSuite, int capacidade, decimal valorDiaria)
        {
            Id = id;
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
            Ocupada = false;
        }

        public int Id { get; set; }
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
        public bool Ocupada { get; set; }
    }
}