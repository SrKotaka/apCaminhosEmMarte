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

        private void btnInserir_Click(object sender, EventArgs e)
        {
            // Criar um novo objeto Cidade com os dados dos campos de texto
            Cidade novaCidade = new Cidade();
            novaCidade.nome = txtNome.Text;
            novaCidade.x = (double)udX.Value;
            novaCidade.y = (double)udY.Value;

            // Inserir a cidade na tabela de hash correspondente à opção selecionada pelo usuário
            tabelaDeHash.Inserir(novaCidade);

            // Atualizar a lista de cidades exibida no ListBox
            AtualizarListaCidades();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            // Criar um objeto Cidade com os dados dos campos de texto
            Cidade cidadeARemover = new Cidade();
            cidadeARemover.nome = txtNome.Text;
            cidadeARemover.x = (double)udX.Value;
            cidadeARemover.y = (double)udY.Value;

            // Remover a cidade da tabela de hash correspondente à opção selecionada pelo usuário
            tabelaDeHash.Remover(cidadeARemover);

            // Atualizar a lista de cidades exibida no ListBox
            AtualizarListaCidades();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Criar um objeto Cidade com os dados dos campos de texto
            Cidade cidadeABuscar = new Cidade();
            cidadeABuscar.nome = txtNome.Text;
            cidadeABuscar.x = (double)udX.Value;
            cidadeABuscar.y = (double)udY.Value;

            // Verificar se a cidade existe na tabela de hash correspondente à opção selecionada pelo usuário
            int onde;
            bool existe = tabelaDeHash.Existe(cidadeABuscar, out onde);

            if (existe)
            {
                MessageBox.Show("A cidade existe na tabela de hash.");
            }
            else
            {
                MessageBox.Show("A cidade não existe na tabela de hash.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AtualizarListaCidades();
        }
        private void AtualizarListaCidades()
        {
            // Limpar o ListBox
            lsbListagem.Items.Clear();

            // Obter o conteúdo da tabela de hash correspondente à opção selecionada pelo usuário
            List<string> conteudo = tabelaDeHash.Conteudo();

            // Adicionar os itens da lista ao ListBox
            foreach (string item in conteudo)
            {
                lsbListagem.Items.Add(item);
            }
        }
    }
}