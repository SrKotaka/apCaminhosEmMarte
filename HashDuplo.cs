using System;
using System.Collections.Generic;

public class HashDuplo<Tipo> : ITabelaDeHash<Tipo>
    where Tipo : IRegistro<Tipo>, IComparable<Tipo>
{
    private const int TABLE_SIZE = 131;
    private Tipo[] tabela;
    private bool[] ocupado;

    public HashDuplo()
    {
        tabela = new Tipo[TABLE_SIZE];
        ocupado = new bool[TABLE_SIZE];
    }

    public int Hash(string chave)
    {
        long hash = 5381;
        foreach (char c in chave)
        {
            hash = ((hash << 5) + hash) + c; // hash * 33 + c
        }
        return (int)(hash % TABLE_SIZE);
    }

    public void Inserir(Tipo item)
    {
        int indice = Hash(item.Chave);
        int passo = 1;
        while (ocupado[indice])
        {
            indice = (indice + passo) % TABLE_SIZE;
            passo++;
        }
        tabela[indice] = item;
        ocupado[indice] = true;
    }

    public bool Remover(Tipo item)
    {
        int indice = Hash(item.Chave);
        int passo = 1;
        while (ocupado[indice])
        {
            if (tabela[indice].Equals(item))
            {
                tabela[indice] = default(Tipo);
                ocupado[indice] = false;
                return true;
            }
            indice = (indice + passo) % TABLE_SIZE;
            passo++;
        }
        return false;
    }

    public bool Existe(Tipo item, out int onde)
    {
        int indice = Hash(item.Chave);
        int passo = 1;
        while (ocupado[indice])
        {
            if (tabela[indice].Equals(item))
            {
                onde = indice;
                return true;
            }
            indice = (indice + passo) % TABLE_SIZE;
            passo++;
        }
        onde = -1;
        return false;
    }

    public List<string> Conteudo()
    {
        List<string> conteudo = new List<string>();
        for (int i = 0; i < TABLE_SIZE; i++)
        {
            if (ocupado[i])
            {
                conteudo.Add($"{i}: {tabela[i].Chave}");
            }
        }
        return conteudo;
    }
}