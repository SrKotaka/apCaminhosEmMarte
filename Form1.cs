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
        List<Cidade> cidades = new List<Cidade>(); 
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void DesenharCidadesNoMapa(List<Cidade> cidades, Graphics g)
        {
            // Definir a cor do pincel para desenhar as cidades
            Brush brush = new SolidBrush(Color.Red);

            // Definir a fonte para desenhar os nomes das cidades
            Font font = new Font("Arial", 10);

            foreach (var cidade in cidades)
            {
                // Normalizar as coordenadas para o tamanho do PictureBox
                float x = (float)(cidade.x * pbMapa.Width);
                float y = (float)(cidade.y * pbMapa.Height);

                // Desenhar um círculo no local da cidade
                g.FillEllipse(brush, x, y, 10, 10);

                // Desenhar o nome da cidade próximo ao círculo
                g.DrawString(cidade.nome, font, brush, x + 10, y);
            }
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
                else if (rbSondagemLinear.Checked)
                    tabelaDeHash = new HashLinear<Cidade>();
                else if (rbSondagemQuadratica.Checked)
                    tabelaDeHash = new HashQuadratico<Cidade>();
                else
                    tabelaDeHash = new HashDuplo<Cidade>();

                // abrimos o arquivo escolhido
                using (var asCidades = new StreamReader(dlgAbrir.FileName))
                {
                    // Limpar o ListBox antes de adicionar as novas cidades
                    lsbListagem.Items.Clear();

                    // Ler registros do arquivo aberto
                    while (!asCidades.EndOfStream)
                    {
                        // Instanciar um objeto cidade
                        Cidade cidade = new Cidade().LerRegistro(asCidades);

                        // Inserir cidade na tabela de Hash
                        tabelaDeHash.Inserir(cidade);

                        // Adicionar cidade à lista de cidades a serem desenhadas no mapa
                        cidades.Add(cidade);

                        // Adicionar o nome da cidade à lista de cidades no ListBox
                        lsbListagem.Items.Add(cidade.nome);
                    }

                    // Selecionar a primeira cidade da lista, se houver
                    if (lsbListagem.Items.Count > 0)
                    {
                        lsbListagem.SelectedIndex = 0;
                    }
                }
                // Forçar o PictureBox a redesenhar sua superfície
                pbMapa.Invalidate();
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
                using (StreamWriter arquivoSaida = new StreamWriter("C:\\Temp\\cidades.txt"))
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
        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            DesenharCidadesNoMapa(cidades, e.Graphics);
        }

        private void btnListagem_Click(object sender, EventArgs e)
        {
            AtualizarListaCidades();
        }
    }
}
