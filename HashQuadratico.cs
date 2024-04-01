using System;
using System.Collections;
using System.Collections.Generic;

public class HashQuadratico<Tipo> : ITabelaDeHash<Tipo>
    where Tipo : IComparable<Tipo>, IRegistro<Tipo>
{
    private const int tamanhoDaTabela = 131;
    private Tipo[] dados;

    public HashQuadratico()
    {
        dados = new Tipo[tamanhoDaTabela];
    }

    public List<string> Conteudo()
    {
        List<string> conteudo = new List<string>();

        for (int i = 0; i < dados.Length; i++)
            if (dados[i] != null)
                conteudo.Add(i + ": " + dados[i].Chave);

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
        int hash = Math.Abs(chave.GetHashCode());
        int indice = hash % tamanhoDaTabela;

        for (int i = 1; dados[indice] != null; i++)
        {
            indice = (hash + i * i) % tamanhoDaTabela;
        }

        return indice;
    }

    public void Inserir(Tipo item)
    {
        int indice = Hash(item.Chave);
        int i = 1;

        while (dados[indice] != null)
        {
            indice = (indice + i * i) % tamanhoDaTabela;
            i++;
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
