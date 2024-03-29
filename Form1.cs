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
        private void DesenharCidadesNoMapa()
        {
            var cidade = new Cidade();
            
            // Obter o objeto Graphics do PictureBox
            Graphics g = pbMapa.CreateGraphics();

            // Definir a cor do pincel para desenhar as cidades
            Brush brush = new SolidBrush(Color.Red);

            // Definir a fonte para desenhar os nomes das cidades
            Font font = new Font("Arial", 10);
            
            // Desenhar um círculo no local da cidade
            g.FillEllipse(brush, (float)cidade.x, (float)cidade.y, 10, 10);

            // Desenhar o nome da cidade próximo ao círculo
            g.DrawString(cidade.nome, font, brush, (float)cidade.x + 10, (float)cidade.y);
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                // verificamos qual a técnica de Hash escolhida
                // pelo usuário e criamos uma tabela de hash de
                // acordo com essa escolha
                if (rbBucketHash.Checked) 
                    tabelaDeHash = new BucketHash<Cidade>();
                else
                if (rbSondagemLinear.Checked)
                    tabelaDeHash = new HashLinear<Cidade>();
                else
                if (rbSondagemQuadratica.Checked)
                    tabelaDeHash = new HashQuadratico<Cidade>();
                else
                    tabelaDeHash = new HashDuplo<Cidade>();

                // abrimos o arquivo escolhido
                var asCidades = new StreamReader(dlgAbrir.FileName);
                // ler registros do arquivo aberto
                while (!asCidades.EndOfStream)
                {
                    // instanciar um objeto cidade
                    Cidade cidade = new Cidade().LerRegistro(asCidades);
                    // lê-lo do arquivo para preencher seus atributos
                    // armazenar esse objeto na tabela de Hash
                    // de acordo com a técnica de hash escolhida
                    // pelo usuário
                    tabelaDeHash.Inserir(cidade);
                }
                // Forçar o PictureBox a redesenhar sua superfície
                pbMapa.Invalidate();
                // Desenhar os nomes das cidades no mapa de Marte
                DesenharCidadesNoMapa();
                // deixar arquivo fechado
                asCidades.Close();  
            }
        }

        private void FrmCaminhos_FormClosing(object sender, FormClosingEventArgs e)
        {
            // aqui, a tabela de hash deve ser percorrida e os 
            // registros armazenados devem ser gravados no arquivo
            // agora, aberto para saída (StreamWriter).
            if (tabelaDeHash != null)
            {
                // Abre o arquivo para escrita
                using (StreamWriter arquivoSaida = new StreamWriter("cidades.txt"))
                {
                    // Percorre a tabela de hash
                    foreach (var cidade in tabelaDeHash.Conteudo())
                    {
                        // Escreve cada registro no arquivo
                        arquivoSaida.WriteLine(cidade);
                    }
                }
            }
        }
    }
}