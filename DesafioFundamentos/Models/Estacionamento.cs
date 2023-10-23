namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
             while (true) // Loop infinito para permitir a adição de vários veículos
             {
                Console.WriteLine("Digite a placa do veículo para estacionar (ou digite 'sair' para parar):");
                string input = Console.ReadLine();

                if (input.ToLower() == "sair")
                {
                    break; // Se o usuário digitar 'sair', saímos do loop
                }

                // Caso contrário, o que foi digitado é tratado como uma placa e adicionado à lista
                veiculos.Add(input);
                Console.WriteLine($"Veículo com a placa {input} foi estacionado com sucesso.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

             string placa = Console.ReadLine(); // Lê a placa digitada pelo usuário
            

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                
                if (int.TryParse(Console.ReadLine(), out int horas)) // Lê e converte a quantidade de horas
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas; // Calcula o valor total
                    
                    // Remove a placa digitada da lista de veículos
                    veiculos.Remove(placa);
                    
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                foreach (var placa in veiculos)
                {
                     Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
