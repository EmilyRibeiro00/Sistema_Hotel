using System;
using System.Collections.Generic;

using Hotel.Models;
using Hotel.Gerenciamento;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Reserva reserva = new Reserva(0);
bool sair = false;

while (!sair) {
    Console.WriteLine("\nMenu de Reservas");
    Console.WriteLine("1 - Cadastrar Suíte");
    Console.WriteLine("2 - Cadastrar Hóspede");
    Console.WriteLine("3 - Visualizar Quantidade de Hóspedes");
    Console.WriteLine("4 - Calcular Valor da Diária");
    Console.WriteLine("5 - Sair");
    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine();

    switch (opcao) {
        case "1":
            Console.Write("Digite o tipo de suíte: ");
            string tipoSuite = Console.ReadLine();

            int capacidade;
            while (true)
            {
                try
                {
                    Console.Write("Digite a capacidade da suíte: ");
                    capacidade = int.Parse(Console.ReadLine());
                    break; // Sai do loop se a conversão foi bem-sucedida
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nPor favor, insira um número inteiro válido para a capacidade.");
                }
            }

            decimal valorDiaria;
            while (true)
            {
                try
                {
                    Console.Write("Digite o valor da diária: ");
                    valorDiaria = decimal.Parse(Console.ReadLine());
                    break; // Sai do loop se a conversão foi bem-sucedida
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nPor favor, insira um valor numérico válido para o valor da diária.");
                }
            }

            Suite suite = new Suite(tipoSuite, capacidade, valorDiaria);

            int diasReservados;
            while (true)
            {
                try
                {
                    Console.Write("Digite a quantidade de dias reservados: ");
                    diasReservados = int.Parse(Console.ReadLine());
                    break; // Sai do loop se a conversão foi bem-sucedida
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nPor favor, insira um número inteiro válido para a quantidade de dias reservados.");
                }
            }

            reserva = new Reserva(diasReservados);
            reserva.CadastrarSuite(suite);

            Console.WriteLine("Suíte cadastrada com sucesso!");
            break;

        case "2":
            if (reserva == null || reserva.Suite == null) {
                Console.WriteLine("\nPrimeiro, cadastre uma suíte antes de adicionar hóspedes.");
            } else {
                Console.Write("Digite o nome do hóspede: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o sobrenome do hóspede: ");
                string sobrenome = Console.ReadLine();

                Pessoa hospede = new Pessoa(nome, sobrenome);

                if (reserva.Hospedes.Count < reserva.Suite.Capacidade) {
                    reserva.CadastrarHospede(hospede);
                    Console.WriteLine("Hóspede cadastrado com sucesso!");
                } else {
                    Console.WriteLine("A capacidade máxima da suíte foi atingida.");
                }
            }
            break;

        case "3":
            if (reserva != null) {
                Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantHospedes()}");
            } else {
                Console.WriteLine("Nenhuma reserva foi cadastrada ainda.");
            }
            break;

        case "4":
            if (reserva != null && reserva.Suite != null) {
                decimal valorTotal = reserva.CalcularValorDiaria();
                Console.WriteLine($"Valor total da reserva: {valorTotal:C}");
            } else {
                Console.WriteLine("Primeiro, cadastre uma suíte para calcular o valor da diária.");
            }
            break;

        case "5":
            sair = true;
            Console.WriteLine("\nSaindo do programa...");
            break;

        default:
            Console.WriteLine("\nOpção inválida! Tente novamente.");
            break;
    }
}
