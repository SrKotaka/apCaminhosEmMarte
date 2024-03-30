using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HashLinear<Tipo> : ITabelaDeHash<Tipo>
    where Tipo : IRegistro<Tipo>, IComparable<Tipo>
{
    private const int tamanhoDaTabela = 131; 
    private Tipo[] dados; // Usaremos uma matriz de Tipo

    public HashLinear()
    {
        dados = new Tipo[tamanhoDaTabela];
    }
    public List<string> Conteudo()
    {
        List<string> conteudo = new List<string>();

        foreach (var item in dados)
        {
            if (item != null)
            {
                conteudo.Add(item.ToString());
            }
        }

        return conteudo;
    }

    public int Hash(string chave)
    {
        return Math.Abs(chave.GetHashCode()) % tamanhoDaTabela;
    }

    public bool Existe(Tipo item, out int onde)
    {
        onde = -1;
        int indice = Hash(item.Chave);

        while (dados[indice] != null)
        {
            if (dados[indice].Equals(item))
            {
                onde = indice;
                return true;
            }

            indice = (indice + 1) % tamanhoDaTabela;
        }

        return false;
    }


    void ITabelaDeHash<Tipo>.Inserir(Tipo item)
    {
        int indice = Hash(item.Chave);

        while (dados[indice] != null)
        {
            indice = (indice + 1) % tamanhoDaTabela;
        }

        dados[indice] = item;
    }

    public bool Remover(Tipo item)
    {
        int indice = -1;
        if (Existe(item, out indice))
        {
            dados[indice] = default(Tipo);
            return true;
        }

        return false;
    }

}