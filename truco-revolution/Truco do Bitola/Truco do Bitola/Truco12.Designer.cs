﻿namespace Truco_do_Bitola
{
    partial class Truco12
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
            this.pctMaoCorre = new System.Windows.Forms.PictureBox();
            this.pctMaoDesce = new System.Windows.Forms.PictureBox();
            this.pctCorro = new System.Windows.Forms.PictureBox();
            this.pctDesce = new System.Windows.Forms.PictureBox();
            this.pctTruco = new System.Windows.Forms.PictureBox();
            this.tmrVibracao = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pctMaoCorre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMaoDesce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCorro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctDesce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctTruco)).BeginInit();
            this.SuspendLayout();
            // 
            // pctMaoCorre
            // 
            this.pctMaoCorre.BackColor = System.Drawing.Color.Transparent;
            this.pctMaoCorre.Image = global::Truco_do_Bitola.Properties.Resources.Selecionar1;
            this.pctMaoCorre.Location = new System.Drawing.Point(334, 219);
            this.pctMaoCorre.Name = "pctMaoCorre";
            this.pctMaoCorre.Size = new System.Drawing.Size(44, 64);
            this.pctMaoCorre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctMaoCorre.TabIndex = 25;
            this.pctMaoCorre.TabStop = false;
            // 
            // pctMaoDesce
            // 
            this.pctMaoDesce.BackColor = System.Drawing.Color.Transparent;
            this.pctMaoDesce.Image = global::Truco_do_Bitola.Properties.Resources.Selecionar1;
            this.pctMaoDesce.Location = new System.Drawing.Point(53, 219);
            this.pctMaoDesce.Name = "pctMaoDesce";
            this.pctMaoDesce.Size = new System.Drawing.Size(44, 64);
            this.pctMaoDesce.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctMaoDesce.TabIndex = 24;
            this.pctMaoDesce.TabStop = false;
            // 
            // pctCorro
            // 
            this.pctCorro.BackColor = System.Drawing.Color.Transparent;
            this.pctCorro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctCorro.Image = global::Truco_do_Bitola.Properties.Resources.Corro;
            this.pctCorro.Location = new System.Drawing.Point(267, 289);
            this.pctCorro.Name = "pctCorro";
            this.pctCorro.Size = new System.Drawing.Size(161, 60);
            this.pctCorro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctCorro.TabIndex = 23;
            this.pctCorro.TabStop = false;
            this.pctCorro.Click += new System.EventHandler(this.btnRecusar_Click);
            this.pctCorro.MouseEnter += new System.EventHandler(this.pctCorro_MouseEnter);
            this.pctCorro.MouseLeave += new System.EventHandler(this.pctCorro_MouseLeave);
            // 
            // pctDesce
            // 
            this.pctDesce.BackColor = System.Drawing.Color.Transparent;
            this.pctDesce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctDesce.Image = global::Truco_do_Bitola.Properties.Resources.Desce;
            this.pctDesce.Location = new System.Drawing.Point(12, 289);
            this.pctDesce.Name = "pctDesce";
            this.pctDesce.Size = new System.Drawing.Size(130, 60);
            this.pctDesce.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctDesce.TabIndex = 22;
            this.pctDesce.TabStop = false;
            this.pctDesce.Click += new System.EventHandler(this.btnAceitar_Click);
            this.pctDesce.MouseEnter += new System.EventHandler(this.pctDesce_MouseEnter);
            this.pctDesce.MouseLeave += new System.EventHandler(this.pctDesce_MouseLeave);
            // 
            // pctTruco
            // 
            this.pctTruco.BackColor = System.Drawing.Color.Transparent;
            this.pctTruco.Image = global::Truco_do_Bitola.Properties.Resources.Doze;
            this.pctTruco.Location = new System.Drawing.Point(12, 12);
            this.pctTruco.Name = "pctTruco";
            this.pctTruco.Size = new System.Drawing.Size(416, 127);
            this.pctTruco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctTruco.TabIndex = 21;
            this.pctTruco.TabStop = false;
            // 
            // tmrVibracao
            // 
            this.tmrVibracao.Enabled = true;
            this.tmrVibracao.Interval = 50;
            this.tmrVibracao.Tick += new System.EventHandler(this.tmrVibracao_Tick_1);
            // 
            // Truco12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 361);
            this.Controls.Add(this.pctMaoCorre);
            this.Controls.Add(this.pctMaoDesce);
            this.Controls.Add(this.pctCorro);
            this.Controls.Add(this.pctDesce);
            this.Controls.Add(this.pctTruco);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Truco12";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truco12";
            this.Load += new System.EventHandler(this.Truco12_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctMaoCorre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMaoDesce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCorro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctDesce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctTruco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctMaoCorre;
        private System.Windows.Forms.PictureBox pctMaoDesce;
        private System.Windows.Forms.PictureBox pctCorro;
        private System.Windows.Forms.PictureBox pctDesce;
        private System.Windows.Forms.PictureBox pctTruco;
        private System.Windows.Forms.Timer tmrVibracao;
    }
}