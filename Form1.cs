using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace apCaminhosEmMarte
{
  public partial class FrmCaminhos : Form
  {
    public FrmCaminhos()
    {
      InitializeComponent();
    }

    ITabelaDeHash<Cidade> tabelaDeHash;
    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void btnAbrirArquivo_Click(object sender, EventArgs e)
    {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                // Verificamos qual a técnica de Hash escolhida
                // pelo usuário e criamos uma tabela de hash de
                // acordo com essa escolha
                if (rbBucketHash.Checked)
                    tabelaDeHash = new BucketHash<Cidade>();
                else if (rbSondagemLinear.Checked)
                    tabelaDeHash = new HashLinear<Cidade>();
                else if (rbSondagemQuadratica.Checked)
                    tabelaDeHash = new HashQuadratico<Cidade>();
                else
                    tabelaDeHash = new HashDuplo<Cidade>();

                // Abrimos o arquivo escolhido
                using (var asCidades = new StreamReader(dlgAbrir.FileName))
                {
                    // Ler registros do arquivo aberto
                    while (!asCidades.EndOfStream)
                    {
                        // Instanciar um objeto cidade
                        var cidade = new Cidade();
                        // Lê-lo do arquivo para preencher seus atributos
                        cidade.LerRegistro(asCidades);
                        // Armazenar esse objeto na tabela de Hash
                        // de acordo com a técnica de hash escolhida
                        tabelaDeHash.Inserir(cidade);
                    }
                }
                lsbListagem.Items.Clear();
                foreach (var cidade in tabelaDeHash.Conteudo())
                {
                    lsbListagem.Items.Add(cidade);
                    //adicionar ao ler arquivo tambem para ler as cordenadas x e y
                }

                // Desenhar os nomes das cidades no mapa de Marte
                // Implementar essa funcionalidade aqui.
                // Para isso, é necessário percorrer a tabela de hash
                // e desenhar cada cidade no mapa.
                // Para desenhar uma cidade, é necessário calcular
                // as coordenadas x e y do ponto onde ela será desenhada.
                // Para isso, é necessário saber as coordenadas x e y
                // máximas e mínimas das cidades.
                // Para desenhar o nome de uma cidade, é necessário
                // instanciar um objeto Font e um objeto Brush.
                // Para desenhar o nome de uma cidade, é necessário
                // chamar o método DrawString do objeto Graphics.

            }
    }

    private void FrmCaminhos_FormClosing(object sender, FormClosingEventArgs e)
    {
            // aqui, a tabela de hash deve ser percorrida e os 
            // registros armazenados devem ser gravados no arquivo
            // agora, aberto para saída (StreamWriter).
            if (tabelaDeHash != null)
            {
                using (var arquivo = new StreamWriter("CidadesMarte2024.txt"))
                {
                    foreach (var cidade in tabelaDeHash.Conteudo())
                    {
                        arquivo.WriteLine(cidade);
                    }
                }
            } 
    }

    private void lsbListagem_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  }
}
