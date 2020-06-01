namespace Truco_do_Bitola
{
    partial class Truco3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrVibracao = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pctTruco = new System.Windows.Forms.PictureBox();
            this.pctMaoDesce = new System.Windows.Forms.PictureBox();
            this.pctMaoCorre = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctTruco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMaoDesce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMaoCorre)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "O Cara ta Pedindo Truco";
            // 
            // tmrVibracao
            // 
            this.tmrVibracao.Enabled = true;
            this.tmrVibracao.Interval = 50;
            this.tmrVibracao.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Truco_do_Bitola.Properties.Resources.Corro;
            this.pictureBox2.Location = new System.Drawing.Point(211, 289);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(161, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.btnRecusar_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Truco_do_Bitola.Properties.Resources.Desce;
            this.pictureBox1.Location = new System.Drawing.Point(12, 289);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnAceitar_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // pctTruco
            // 
            this.pctTruco.BackColor = System.Drawing.Color.Transparent;
            this.pctTruco.Image = global::Truco_do_Bitola.Properties.Resources.Truco;
            this.pctTruco.Location = new System.Drawing.Point(35, 12);
            this.pctTruco.Name = "pctTruco";
            this.pctTruco.Size = new System.Drawing.Size(310, 123);
            this.pctTruco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctTruco.TabIndex = 6;
            this.pctTruco.TabStop = false;
            // 
            // pctMaoDesce
            // 
            this.pctMaoDesce.BackColor = System.Drawing.Color.Transparent;
            this.pctMaoDesce.Image = global::Truco_do_Bitola.Properties.Resources.Selecionar1;
            this.pctMaoDesce.Location = new System.Drawing.Point(53, 219);
            this.pctMaoDesce.Name = "pctMaoDesce";
            this.pctMaoDesce.Size = new System.Drawing.Size(44, 64);
            this.pctMaoDesce.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctMaoDesce.TabIndex = 10;
            this.pctMaoDesce.TabStop = false;
            // 
            // pctMaoCorre
            // 
            this.pctMaoCorre.BackColor = System.Drawing.Color.Transparent;
            this.pctMaoCorre.Image = global::Truco_do_Bitola.Properties.Resources.Selecionar1;
            this.pctMaoCorre.Location = new System.Drawing.Point(278, 219);
            this.pctMaoCorre.Name = "pctMaoCorre";
            this.pctMaoCorre.Size = new System.Drawing.Size(44, 64);
            this.pctMaoCorre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctMaoCorre.TabIndex = 11;
            this.pctMaoCorre.TabStop = false;
            // 
            // Truco3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.pctMaoCorre);
            this.Controls.Add(this.pctMaoDesce);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pctTruco);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Truco3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InimigoTruco";
            this.Load += new System.EventHandler(this.Truco3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctTruco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMaoDesce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMaoCorre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pctTruco;
        private System.Windows.Forms.Timer tmrVibracao;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pctMaoDesce;
        private System.Windows.Forms.PictureBox pctMaoCorre;
    }
}