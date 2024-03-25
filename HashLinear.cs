using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HashLinear<Tipo> : ITabelaDeHash<Tipo>
      where Tipo : IRegistro<Tipo>, IComparable<Tipo>
{
    private List<Tipo> tabela;
    private int tamanho;
    private int quantidade;

    public HashLinear(int tamanho)
    {
        this.tamanho = tamanho;
        tabela = new List<Tipo>(tamanho);
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

    public int Hash(string chave)
    {
        int hash = 0;
        foreach (char c in chave)
        {
            hash += (int)c;
        }
        return hash % tamanho;
    }

    bool ITabelaDeHash<Tipo>.Existe(Tipo item, out int onde)
    {
        onde = Hash(item.Chave);
        int i = onde;
        int tentativas = 0;
        while (tabela[i] != null && tentativas < tamanho)
        {
            if (tabela[i].Equals(item))
            {
                return true;
            }
            i = (i + 1) % tamanho;
            tentativas++;
        }
        return false;
    }

    void ITabelaDeHash<Tipo>.Inserir(Tipo item)
    {
        int onde;
        if (!((ITabelaDeHash<Tipo>)this).Existe(item, out onde))
        {
            if (quantidade < tamanho)
            {
                tabela[onde] = item;
                quantidade++;
            }
            else
            {
                throw new Exception("Tabela de hash cheia");
            }
        }
    }

    bool ITabelaDeHash<Tipo>.Remover(Tipo item)
    {
        int onde;
        if (((ITabelaDeHash<Tipo>)this).Existe(item, out onde))
        {
            tabela[onde] = default(Tipo);
            quantidade--;
            return true;
        }
        return false;
    }
}

