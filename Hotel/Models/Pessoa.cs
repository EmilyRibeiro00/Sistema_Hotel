using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Pessoa
    {
        // Atributos da classe
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

    // Construtor para inicializar os atributos
    public Pessoa(string nome, string sobrenome) {
        Nome = nome;
        Sobrenome = sobrenome;
    }

    // Método para exibir o nome completo
    public string NomeCompleto() {
        return $"{Nome} {Sobrenome}";
    }
    }
}