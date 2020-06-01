namespace Truco_do_Bitola
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.btnJogar = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnJogar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnJogar
            // 
            this.btnJogar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnJogar.BackColor = System.Drawing.SystemColors.Control;
            this.btnJogar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnJogar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJogar.Image = global::Truco_do_Bitola.Properties.Resources.JogarInicio;
            this.btnJogar.Location = new System.Drawing.Point(160, 335);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(280, 100);
            this.btnJogar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnJogar.TabIndex = 3;
            this.btnJogar.TabStop = false;
            this.btnJogar.Click += new System.EventHandler(this.btnJogar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSair.BackColor = System.Drawing.SystemColors.Control;
            this.btnSair.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnSair.Cursor = System.Windows.Forms.Cursors.No;
            this.btnSair.Image = global::Truco_do_Bitola.Properties.Resources.SairInicio;
            this.btnSair.Location = new System.Drawing.Point(160, 441);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(280, 100);
            this.btnSair.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSair.TabIndex = 4;
            this.btnSair.TabStop = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Help;
            this.pictureBox1.Image = global::Truco_do_Bitola.Properties.Resources.tectruco_logo;
            this.pictureBox1.Location = new System.Drawing.Point(200, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Truco_do_Bitola.Properties.Resources.mesa;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnJogar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trutec";
            this.Load += new System.EventHandler(this.Inicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnJogar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox btnJogar;
        private System.Windows.Forms.PictureBox btnSair;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}