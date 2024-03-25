using System;
using System.Collections.Generic;

public class HashDuplo<Tipo> : ITabelaDeHash<Tipo>
  where Tipo : IRegistro<Tipo>, IComparable<Tipo>
{
    private List<Tipo> tabela;
    private int tamanho;
    private int quantidade;

    public HashDuplo(int tamanhoInicial)
    {
        tabela = new List<Tipo>(tamanhoInicial);
        tamanho = tamanhoInicial;
        quantidade = 0;
    }

    public List<string> Conteudo()
    {
        List<string> conteudo = new List<string>();
        foreach (Tipo item in tabela)
        {
            conteudo.Add(item.ToString());
        }
        return conteudo;
    }

    public bool Existe(Tipo item, out int onde)
    {
        onde = -1;
        int posicao = Hash(item.Chave);
        int incremento = Hash2(item.Chave);
        int tentativas = 0;

        while (tentativas < tamanho)
        {
            if (tabela[posicao] == null)
            {
                return false;
            }
            else if (tabela[posicao].Equals(item))
            {
                onde = posicao;
                return true;
            }
            else
            {
                posicao = (posicao + incremento) % tamanho;
                tentativas++;
            }
        }

        return false;
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

    public int Hash2(string chave)
    {
        int hash = 0;
        foreach (char c in chave)
        {
            hash += (int)c;
        }
        return (hash % (tamanho - 1)) + 1;
    }

    public void Inserir(Tipo item)
    {
        if (quantidade >= tamanho / 2)
        {
            Rehash();
        }

        int posicao = Hash(item.Chave);
        int incremento = Hash2(item.Chave);
        int tentativas = 0;

        while (tentativas < tamanho)
        {
            if (tabela[posicao] == null)
            {
                tabela[posicao] = item;
                quantidade++;
                return;
            }
            else
            {
                posicao = (posicao + incremento) % tamanho;
                tentativas++;
            }
        }

        throw new Exception("Tabela de hash cheia.");
    }

    public bool Remover(Tipo item)
    {
        int posicao;
        if (Existe(item, out posicao))
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
        List<Tipo> novaTabela = new List<Tipo>(novoTamanho);

        for (int i = 0; i < tamanho; i++)
        {
            if (tabela[i] != null)
            {
                int posicao = Hash(tabela[i].Chave);
                int incremento = Hash2(tabela[i].Chave);
                int tentativas = 0;

                while (tentativas < novoTamanho)
                {
                    if (novaTabela[posicao] == null)
                    {
                        novaTabela[posicao] = tabela[i];
                        break;
                    }
                    else
                    {
                        posicao = (posicao + incremento) % novoTamanho;
                        tentativas++;
                    }
                }
            }
        }

        tabela = novaTabela;
        tamanho = novoTamanho;
    }
}
