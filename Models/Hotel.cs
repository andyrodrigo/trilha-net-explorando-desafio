using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DesafioProjetoHospedagem.Models
{
    public class Hotel
    {
        public List<Pessoa> Hospedes { get; set; }
        public List<Suite> Suites { get; set; }

        public Hotel(){
            Hospedes =  new List<Pessoa>();
            Suites = new List<Suite>();
            string recebidos = File.ReadAllText("arquivos/suites.json");
            Suites = JsonConvert.DeserializeObject< List<Suite> >( recebidos );
        }

        public void FazerReserva(){

            Console.WriteLine("Digite quantos dias de reserva.");
            string dias = Console.ReadLine();
            int numeroDeDias;
            try{
                numeroDeDias = Int32.Parse(dias);
            } catch (FormatException) {
                Console.WriteLine("Não é um número");
                return;
            }
            if( numeroDeDias < 1 ){
                Console.WriteLine("Número inválido, o mínimo de dias é 1");
                return;
            }

            List<Pessoa> hospedesNovos = new List<Pessoa>();
            Console.WriteLine("Digite a quantidade de Hospedes.");
            string quantidade = Console.ReadLine();
            int numero;
            try{
                numero = Int32.Parse(quantidade);
            } catch (FormatException) {
                Console.WriteLine("Não é um número");
                return;
            }
            if( numero < 1 || numero > 5 ){
                Console.WriteLine("Número inválido, aceito apenas 1 a 5 hospedes");
                return;
            } else {
                for(int i=1 ; i <= numero ; i++){
                    Console.WriteLine( $"Digite o nome do Hospede { i }: ");
                    string nomeHospede = Console.ReadLine();
                    if( nomeHospede == "")
                        throw new Exception( "Nome não pode ser vazio." ); 

                    Pessoa p = new Pessoa( nomeHospede );
                    hospedesNovos.Add(p);
                    Hospedes.Add(p);
                }
            }

            bool reservando = true;

            while( reservando ){
                Console.WriteLine( $"Digite o número da suíte: ");
                string numeroDaSuite = Console.ReadLine();
                int intSuite;
                try{
                    intSuite = Int32.Parse(numeroDaSuite);
                    if( intSuite < 1 || intSuite > 10 ){
                        Console.WriteLine("Número inválido, aceito apenas suítes 1 a 10");
                    } else {
                        try{
                            Reserva reserva = new Reserva( diasReservados: numeroDeDias );
                            reserva.CadastrarSuite( this.GetSuite( intSuite ) );
                            reserva.CadastrarHospedes( hospedesNovos );
                            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
                            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
                            this.GetSuite( intSuite ).Ocupada = true;
                            reservando = false;
                        } catch ( Exception e){
                            Console.WriteLine( $"Erro: { e.Message }" );
                        }
                    }
                } catch (FormatException) {
                    Console.WriteLine("Não é um número");
                }
            }
        }

        public void ListarHospedesHotel(){
            Console.WriteLine("Lista de Hóspedes do Hotel:");
            foreach( Pessoa hospede in Hospedes ){
                Console.WriteLine( hospede.Nome );
            }
        }
        
        public void ListarSuitessHotel(){
            Console.WriteLine("Lista de Suítes:");
            foreach( Suite suite in Suites ){
                string estado = suite.Ocupada? "ocupada": "livre";
                Console.WriteLine( $" Suíte {suite.Id} - Tipo: {suite.TipoSuite}, Capacidade: {suite.Capacidade}, Valor da Diária: {suite.ValorDiaria}, status: {estado} ");
            }
        }

        public Suite GetSuite( int id ){
           foreach( Suite suite in Suites ){
            if( suite.Id == id)
               return suite;
            }
            return new Suite(id: 0 ,tipoSuite: "Desconhecida", capacidade: 5, valorDiaria: 0 );
        }
    }
}
