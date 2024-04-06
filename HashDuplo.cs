﻿// Felipe Luzivotto de Castro          22129
// Felipe Antônio de Oliveira Almeida  22130

using System;
using System.Collections;
using System.Collections.Generic;

public class HashDuplo<Tipo> : ITabelaDeHash<Tipo>
    where Tipo : IRegistro<Tipo>, IComparable<Tipo>
{
    private const int tamanhoDaTabela = 131;
    private Tipo[] dados;
    
    private List<string> chaves;

    public List<string> Chaves => chaves;

    public HashDuplo()
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

    public int Hash(string chave)
    {
        int hash1 = Math.Abs(chave.GetHashCode());

        return hash1 % tamanhoDaTabela; // Escolha uma função de hash adequada
    }
    
    private int Hash2(string chave)
    {
        return 7 - (Hash(chave) % 7);
    }

    public void Inserir(Tipo item)
    {
        int indice = Hash(item.Chave);

        while (dados[indice] != null)
        {
            indice = (indice + Hash2(item.Chave));
        }

        dados[indice] = item;
        chaves.Add(item.Chave);
    }

    public bool Remover(Tipo item)
    {
        int indice = -1;
        if (Existe(item, out indice))
        {
            dados[indice] = default(Tipo);
            chaves.Remove(item.Chave);
            return true;
        }

        return false;
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

            indice = (indice + Hash2(item.Chave));
        }

        return false;
    }
    
public Tipo Buscar(string chave)
    {
        int indice = Hash(chave);
        
        while (dados[indice] != null)
        {
            if (dados[indice].Chave == chave)
                return dados[indice];
            
            indice = (indice + Hash2(chave));
        }
        
        return default(Tipo);
    }
}
