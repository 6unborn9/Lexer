namespace Lexer
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txCodigo = new System.Windows.Forms.TextBox();
            this.ltTokes = new System.Windows.Forms.ListBox();
            this.Procesar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txCodigo
            // 
            this.txCodigo.Location = new System.Drawing.Point(12, 12);
            this.txCodigo.Multiline = true;
            this.txCodigo.Name = "txCodigo";
            this.txCodigo.Size = new System.Drawing.Size(660, 290);
            this.txCodigo.TabIndex = 0;
            // 
            // ltTokes
            // 
            this.ltTokes.FormattingEnabled = true;
            this.ltTokes.Location = new System.Drawing.Point(690, 12);
            this.ltTokes.Name = "ltTokes";
            this.ltTokes.Size = new System.Drawing.Size(190, 290);
            this.ltTokes.TabIndex = 1;
            // 
            // Procesar
            // 
            this.Procesar.Location = new System.Drawing.Point(12, 315);
            this.Procesar.Name = "Procesar";
            this.Procesar.Size = new System.Drawing.Size(75, 23);
            this.Procesar.TabIndex = 2;
            this.Procesar.Text = "Procesar";
            this.Procesar.UseVisualStyleBackColor = true;
            this.Procesar.Click += new System.EventHandler(this.Procesar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 350);
            this.Controls.Add(this.Procesar);
            this.Controls.Add(this.ltTokes);
            this.Controls.Add(this.txCodigo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txCodigo;
        private System.Windows.Forms.ListBox ltTokes;
        private System.Windows.Forms.Button Procesar;
    }
}

