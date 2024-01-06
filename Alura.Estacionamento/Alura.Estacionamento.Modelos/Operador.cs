using System;
using System.Text;

namespace Alura.Estacionamento.Alura.Estacionamento.Modelos
{
    public class Operador
    {
        public Operador(string nome)
        {
            Matricula = Guid.NewGuid().ToString().Substring(0, 8);
            Nome = nome;
        }

        public string Matricula { get; private set; }
        public string Nome { get; private set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Operador: {Nome}");
            stringBuilder.AppendLine($"Matricula: {Matricula}");

            return stringBuilder.ToString();
        }
    }
}
