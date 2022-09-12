using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

Hotel hotel = new Hotel();

bool programa = true;

Console.WriteLine("Bem vindo ao Programa do Hotel!");
while( programa ){
    Console.WriteLine("Escolha uma das opções: ");
    Console.WriteLine("1 - Fazer Reserva");
    Console.WriteLine("2 - Listar Suítes");
    Console.WriteLine("3 - Listar Hospedes");
    Console.WriteLine("5 - Encerrar Programa");

    string opcao = Console.ReadLine();
    switch(opcao){
        case "1":
            hotel.FazerReserva();
            break;
        case "2":
        hotel.ListarSuitessHotel();   
            break;
        case "3":
        hotel.ListarHospedesHotel();   
            break;
        case "5":
            programa = false;
            break;        
        default:
        Console.WriteLine("Opção não existente.");
            break;
    }
}
Console.WriteLine("Programa Finalizado");

/*
// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
*/