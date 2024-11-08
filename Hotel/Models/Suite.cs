using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Suite
    {
        // Atributos da classe
    public string TipoSuite { get; set; }
    public int Capacidade { get; set; }
    public decimal ValorDiaria { get; set; }

    // Construtor para inicializar os atributos
    public Suite(string tipoSuite, int capacidade, decimal valorDiaria) {
        TipoSuite = tipoSuite;
        Capacidade = capacidade;
        ValorDiaria = valorDiaria;
    }
    }
}