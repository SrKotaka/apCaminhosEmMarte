using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace apCaminhosEmMarte
{
    public class Cidade : IRegistro<Cidade>, IComparable<Cidade>
    {
        // atributos que formam uma linha do arquivo de cidades
        public string nome; 
        public double x,y;
        public Cidade() { }  // construtor default
        public Cidade LerRegistro(StreamReader arquivo)
        {
            if (arquivo != null)  // está aberto
            {
                string linha = arquivo.ReadLine(); // lê uma linha
                nome = linha.Substring(0, 15);  // (inicio, quantos)
                nome = nome.Trim(); //retirar os espaços do nome
                x = double.Parse(linha.Substring(15, 7));
                y = double.Parse(linha.Substring(22, 7));
                return this;
            }
            return default(Cidade);  // para arquivo não aberto
        }
        public void EscreverRegistro(StreamWriter arquivo)
        {
            if (arquivo != null)
            {
                arquivo.WriteLine($"{nome.PadRight(15)}{x:0.00000}{y:0.00000}");
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Cidade)) return false;

            Cidade aCidade = (Cidade)obj;
            if (nome != aCidade.nome)
                return false;

            return true;

        }
        public int CompareTo(Cidade outra)  // <0, ==0, >0
        {
            return this.nome.CompareTo(outra.nome);
        }
        public string Chave => this.nome;
    }
}