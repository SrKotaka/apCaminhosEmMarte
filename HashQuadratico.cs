using System;
using System.Collections.Generic;

public class HashQuadratico<Tipo> : ITabelaDeHash<Tipo>
  where Tipo : IComparable<Tipo>, IRegistro<Tipo>
{
    private Tipo[] tabela;
    private int tamanho;
    private int quantidade;

    public HashQuadratico(int tamanhoInicial)
    {
        tabela = new Tipo[tamanhoInicial];
        tamanho = tamanhoInicial;
        quantidade = 0;
    }

    public List<string> Conteudo()
    {
        List<string> conteudo = new List<string>();
        for (int i = 0; i < tamanho; i++)
        {
            if (tabela[i] != null)
            {
                conteudo.Add(tabela[i].ToString());
            }
        }
        return conteudo;
    }

    public bool Existe(Tipo item, out int onde)
    {
        int posicao = Hash(item.Chave);
        int tentativas = 0;
        while (tabela[posicao] != null && !tabela[posicao].Equals(item) && tentativas < tamanho)
        {
            tentativas++;
            posicao = (posicao + (tentativas * tentativas)) % tamanho;
        }
        onde = posicao;
        return tabela[posicao] != null && tabela[posicao].Equals(item);
    }

    public int Hash(string chave)
    {
        int hash = 0;
        foreach (char c in chave)
        {
            hash += (int)c;
        }
        return hash % tamanho;
    }

    public void Inserir(Tipo item)
    {
        if (quantidade >= tamanho / 2)
        {
            Rehash();
        }
        int posicao = Hash(item.Chave);
        int tentativas = 0;
        while (tabela[posicao] != null && !tabela[posicao].Equals(item) && tentativas < tamanho)
        {
            tentativas++;
            posicao = (posicao + (tentativas * tentativas)) % tamanho;
        }
        if (tabela[posicao] == null)
        {
            tabela[posicao] = item;
            quantidade++;
        }
    }

    public bool Remover(Tipo item)
    {
        int posicao = Hash(item.Chave);
        int tentativas = 0;
        while (tabela[posicao] != null && !tabela[posicao].Equals(item) && tentativas < tamanho)
        {
            tentativas++;
            posicao = (posicao + (tentativas * tentativas)) % tamanho;
        }
        if (tabela[posicao] != null && tabela[posicao].Equals(item))
        {
            tabela[posicao] = default(Tipo);
            quantidade--;
            return true;
        }
        return false;
    }

    private void Rehash()
    {
        int novoTamanho = tamanho * 2;
        Tipo[] novaTabela = new Tipo[novoTamanho];
        for (int i = 0; i < tamanho; i++)
        {
            if (tabela[i] != null)
            {
                int posicao = Hash(tabela[i].Chave);
                int tentativas = 0;
                while (novaTabela[posicao] != null && !novaTabela[posicao].Equals(tabela[i]) && tentativas < novoTamanho)
                {
                    tentativas++;
                    posicao = (posicao + (tentativas * tentativas)) % novoTamanho;
                }
                if (novaTabela[posicao] == null)
                {
                    novaTabela[posicao] = tabela[i];
                }
            }
        }
        tabela = novaTabela;
        tamanho = novoTamanho;
    }
}

