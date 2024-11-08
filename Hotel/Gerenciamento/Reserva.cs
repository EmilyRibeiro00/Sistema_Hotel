using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.Gerenciamento
{
    public class Reserva
    {
        // Atributos da classe
    public List<Pessoa> Hospedes { get; set; } = new List<Pessoa>();
    public Suite Suite { get; set; }
    public int DiasReservados { get; set; }

    // Construtor para inicializar o número de dias reservados
    public Reserva(int diasReservados) {
        DiasReservados = diasReservados;
    }

    // Método para cadastrar um hóspede
    public void CadastrarHospede(Pessoa hospede) {
        Hospedes.Add(hospede);
    }

    // Método para cadastrar uma suíte
    public void CadastrarSuite(Suite suite) {
        Suite = suite;
    }

    // Método para obter a quantidade de hóspedes
    public int ObterQuantHospedes() {
        return Hospedes.Count;
    }

    // Método para calcular o valor total da diária com desconto para reservas longas
    public decimal CalcularValorDiaria() {
        decimal valorTotal = Suite.ValorDiaria * DiasReservados;

        // Desconto de 10% para reservas de 10 dias ou mais
        if (DiasReservados >= 10) {
            valorTotal *= 0.9m;
        }

        return valorTotal;
    }
    
    }
}