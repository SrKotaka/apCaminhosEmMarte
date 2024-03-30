using System;
using System.Collections;
using System.Collections.Generic;

public class HashDuplo<Tipo> : ITabelaDeHash<Tipo>
    where Tipo : IRegistro<Tipo>, IComparable<Tipo>
{
    private const int tamanhoDaTabela = 131;
    private Tipo[] dados; // Usaremos uma matriz de Tipo
    public HashDuplo()
    {
        dados = new Tipo[tamanhoDaTabela];
    }// para gerar mais colisões; o ideal é primo > 100
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


    public int Hash(string chave)
    {
        int hash1 = Math.Abs(chave.GetHashCode());
        int hash2 = 7 - (Math.Abs(chave.GetHashCode()) % 7); // Escolha uma função de hash secundária adequada

        return (hash1 + hash2) % tamanhoDaTabela; // Escolha uma função de hash adequada
    }

    public void Inserir(Tipo item)
    {
        int indice = Hash(item.Chave);
        int hashSecundario = 7 - (Math.Abs(item.Chave.GetHashCode()) % 7); // Função de hash secundária

        while (dados[indice] != null)
        {
            indice = (indice + hashSecundario) % tamanhoDaTabela;
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