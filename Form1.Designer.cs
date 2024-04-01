﻿namespace apCaminhosEmMarte
{
  partial class FrmCaminhos
  {
    /// <summary>
    /// Variável de designer necessária.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpar os recursos que estão sendo usados.
    /// </summary>
    /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Código gerado pelo Windows Form Designer

    /// <summary>
    /// Método necessário para suporte ao Designer - não modifique 
    /// o conteúdo deste método com o editor de código.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCaminhos));
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.tbControl = new System.Windows.Forms.TabControl();
            this.tpCidades = new System.Windows.Forms.TabPage();
            this.btnListagem = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.lsbListagem = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.udY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.udX = new System.Windows.Forms.NumericUpDown();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAbrirArquivo = new System.Windows.Forms.Button();
            this.rbHashDuplo = new System.Windows.Forms.RadioButton();
            this.rbSondagemQuadratica = new System.Windows.Forms.RadioButton();
            this.rbSondagemLinear = new System.Windows.Forms.RadioButton();
            this.rbBucketHash = new System.Windows.Forms.RadioButton();
            this.tpCaminhos = new System.Windows.Forms.TabPage();
            this.tbControl.SuspendLayout();
            this.tpCidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlgAbrir
            // 
            this.dlgAbrir.DefaultExt = "*.txt";
            this.dlgAbrir.InitialDirectory = "c:\\temp";
            // 
            // tbControl
            // 
            this.tbControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbControl.Controls.Add(this.tpCidades);
            this.tbControl.Controls.Add(this.tpCaminhos);
            this.tbControl.Location = new System.Drawing.Point(1, 0);
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedIndex = 0;
            this.tbControl.Size = new System.Drawing.Size(783, 460);
            this.tbControl.TabIndex = 2;
            // 
            // tpCidades
            // 
            this.tpCidades.Controls.Add(this.btnListagem);
            this.tpCidades.Controls.Add(this.btnBuscar);
            this.tpCidades.Controls.Add(this.btnRemover);
            this.tpCidades.Controls.Add(this.btnInserir);
            this.tpCidades.Controls.Add(this.lsbListagem);
            this.tpCidades.Controls.Add(this.label3);
            this.tpCidades.Controls.Add(this.udY);
            this.tpCidades.Controls.Add(this.label2);
            this.tpCidades.Controls.Add(this.udX);
            this.tpCidades.Controls.Add(this.txtNome);
            this.tpCidades.Controls.Add(this.label1);
            this.tpCidades.Controls.Add(this.pbMapa);
            this.tpCidades.Controls.Add(this.groupBox1);
            this.tpCidades.Location = new System.Drawing.Point(4, 22);
            this.tpCidades.Name = "tpCidades";
            this.tpCidades.Padding = new System.Windows.Forms.Padding(3);
            this.tpCidades.Size = new System.Drawing.Size(775, 434);
            this.tpCidades.TabIndex = 0;
            this.tpCidades.Text = "Cidades";
            this.tpCidades.UseVisualStyleBackColor = true;
            // 
            // btnListagem
            // 
            this.btnListagem.Image = ((System.Drawing.Image)(resources.GetObject("btnListagem.Image")));
            this.btnListagem.Location = new System.Drawing.Point(114, 144);
            this.btnListagem.Name = "btnListagem";
            this.btnListagem.Size = new System.Drawing.Size(28, 23);
            this.btnListagem.TabIndex = 14;
            this.btnListagem.UseVisualStyleBackColor = true;
            this.btnListagem.Click += new System.EventHandler(this.btnListagem_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(80, 144);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(28, 23);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(46, 144);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(28, 23);
            this.btnRemover.TabIndex = 12;
            this.btnRemover.Text = "-";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(12, 145);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(28, 23);
            this.btnInserir.TabIndex = 11;
            this.btnInserir.Text = "+";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // lsbListagem
            // 
            this.lsbListagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lsbListagem.FormattingEnabled = true;
            this.lsbListagem.Location = new System.Drawing.Point(8, 175);
            this.lsbListagem.Name = "lsbListagem";
            this.lsbListagem.ScrollAlwaysVisible = true;
            this.lsbListagem.Size = new System.Drawing.Size(171, 251);
            this.lsbListagem.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Y:";
            // 
            // udY
            // 
            this.udY.DecimalPlaces = 5;
            this.udY.Location = new System.Drawing.Point(62, 118);
            this.udY.Name = "udY";
            this.udY.Size = new System.Drawing.Size(64, 20);
            this.udY.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "X:";
            // 
            // udX
            // 
            this.udX.DecimalPlaces = 5;
            this.udX.Location = new System.Drawing.Point(62, 89);
            this.udX.Name = "udX";
            this.udX.Size = new System.Drawing.Size(64, 20);
            this.udX.TabIndex = 6;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(62, 63);
            this.txtNome.MaxLength = 15;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(117, 20);
            this.txtNome.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cidade:";
            // 
            // pbMapa
            // 
            this.pbMapa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMapa.Image = ((System.Drawing.Image)(resources.GetObject("pbMapa.Image")));
            this.pbMapa.Location = new System.Drawing.Point(186, 63);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(587, 369);
            this.pbMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMapa.TabIndex = 3;
            this.pbMapa.TabStop = false;
            this.pbMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMapa_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.btnAbrirArquivo);
            this.groupBox1.Controls.Add(this.rbHashDuplo);
            this.groupBox1.Controls.Add(this.rbSondagemQuadratica);
            this.groupBox1.Controls.Add(this.rbSondagemLinear);
            this.groupBox1.Controls.Add(this.rbBucketHash);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 51);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Técnica de Hash desejada";
            // 
            // btnAbrirArquivo
            // 
            this.btnAbrirArquivo.Location = new System.Drawing.Point(456, 18);
            this.btnAbrirArquivo.Name = "btnAbrirArquivo";
            this.btnAbrirArquivo.Size = new System.Drawing.Size(75, 23);
            this.btnAbrirArquivo.TabIndex = 4;
            this.btnAbrirArquivo.Text = "Abrir Arquivo";
            this.btnAbrirArquivo.UseVisualStyleBackColor = true;
            this.btnAbrirArquivo.Click += new System.EventHandler(this.btnAbrirArquivo_Click);
            // 
            // rbHashDuplo
            // 
            this.rbHashDuplo.AutoSize = true;
            this.rbHashDuplo.Location = new System.Drawing.Point(350, 24);
            this.rbHashDuplo.Name = "rbHashDuplo";
            this.rbHashDuplo.Size = new System.Drawing.Size(81, 17);
            this.rbHashDuplo.TabIndex = 3;
            this.rbHashDuplo.Text = "Hash Duplo";
            this.rbHashDuplo.UseVisualStyleBackColor = true;
            // 
            // rbSondagemQuadratica
            // 
            this.rbSondagemQuadratica.AutoSize = true;
            this.rbSondagemQuadratica.Location = new System.Drawing.Point(217, 24);
            this.rbSondagemQuadratica.Name = "rbSondagemQuadratica";
            this.rbSondagemQuadratica.Size = new System.Drawing.Size(131, 17);
            this.rbSondagemQuadratica.TabIndex = 2;
            this.rbSondagemQuadratica.Text = "Sondagem Quadrática";
            this.rbSondagemQuadratica.UseVisualStyleBackColor = true;
            // 
            // rbSondagemLinear
            // 
            this.rbSondagemLinear.AutoSize = true;
            this.rbSondagemLinear.Location = new System.Drawing.Point(107, 24);
            this.rbSondagemLinear.Name = "rbSondagemLinear";
            this.rbSondagemLinear.Size = new System.Drawing.Size(108, 17);
            this.rbSondagemLinear.TabIndex = 1;
            this.rbSondagemLinear.Text = "Sondagem Linear";
            this.rbSondagemLinear.UseVisualStyleBackColor = true;
            // 
            // rbBucketHash
            // 
            this.rbBucketHash.AutoSize = true;
            this.rbBucketHash.Checked = true;
            this.rbBucketHash.Location = new System.Drawing.Point(18, 24);
            this.rbBucketHash.Name = "rbBucketHash";
            this.rbBucketHash.Size = new System.Drawing.Size(87, 17);
            this.rbBucketHash.TabIndex = 0;
            this.rbBucketHash.TabStop = true;
            this.rbBucketHash.Text = "Bucket Hash";
            this.rbBucketHash.UseVisualStyleBackColor = true;
            // 
            // tpCaminhos
            // 
            this.tpCaminhos.Location = new System.Drawing.Point(4, 22);
            this.tpCaminhos.Name = "tpCaminhos";
            this.tpCaminhos.Padding = new System.Windows.Forms.Padding(3);
            this.tpCaminhos.Size = new System.Drawing.Size(775, 434);
            this.tpCaminhos.TabIndex = 1;
            this.tpCaminhos.Text = "Caminhos";
            this.tpCaminhos.UseVisualStyleBackColor = true;
            // 
            // FrmCaminhos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 457);
            this.Controls.Add(this.tbControl);
            this.Name = "FrmCaminhos";
            this.Text = "Caminhos Em Marte";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCaminhos_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tbControl.ResumeLayout(false);
            this.tpCidades.ResumeLayout(false);
            this.tpCidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.OpenFileDialog dlgAbrir;
    private System.Windows.Forms.TabControl tbControl;
    private System.Windows.Forms.TabPage tpCidades;
    private System.Windows.Forms.PictureBox pbMapa;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnAbrirArquivo;
    private System.Windows.Forms.RadioButton rbHashDuplo;
    private System.Windows.Forms.RadioButton rbSondagemQuadratica;
    private System.Windows.Forms.RadioButton rbSondagemLinear;
    private System.Windows.Forms.RadioButton rbBucketHash;
    private System.Windows.Forms.TabPage tpCaminhos;
    private System.Windows.Forms.TextBox txtNome;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown udY;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown udX;
    private System.Windows.Forms.Button btnRemover;
    private System.Windows.Forms.Button btnInserir;
    private System.Windows.Forms.ListBox lsbListagem;
    private System.Windows.Forms.Button btnBuscar;
    private System.Windows.Forms.Button btnListagem;
  }
}

