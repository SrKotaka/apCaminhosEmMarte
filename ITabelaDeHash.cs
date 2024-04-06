// Felipe Luzivotto de Castro          22129
// Felipe Antônio de Oliveira Almeida  22130

using System;
using System.Collections.Generic;

interface ITabelaDeHash<Tipo> 
    where Tipo : IRegistro<Tipo>, IComparable<Tipo>
{
    int Hash(string chave);
    void Inserir(Tipo item);
    bool Remover(Tipo item);
    bool Existe(Tipo item, out int onde);
    List<string> Conteudo();
    Tipo Buscar(string chave);
    List<string> Chaves { get; }
}