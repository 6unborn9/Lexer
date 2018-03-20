/* 
Archivo de codigo fuente:
Form1.cs
Creado en:
13/3/2018
Por:
Ikkram
Todos los derechos reservados, no se permite crear copias totales o parciales del codigo fuente.

Los usos no autorizados del mismo pueden y seran sancionados.
*/

namespace Lexer
{
    using Lexer.Lex;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Form1" />
    /// </summary>
    public partial class Form1 : Form
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The Tokens
        /// </summary>
        /// <param name="vs">The <see cref="List{string}"/></param>
        internal void Tokens(List<string> vs)
        {
            foreach (var item in vs)
            {
                ltTokes.Items.Add(item);
            }
        }

        /// <summary>
        /// The Form1_Load
        /// </summary>
        /// <param name="sender">The <see cref="object"/></param>
        /// <param name="e">The <see cref="EventArgs"/></param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The Procesar_Click
        /// </summary>
        /// <param name="sender">The <see cref="object"/></param>
        /// <param name="e">The <see cref="EventArgs"/></param>
        private void Procesar_Click(object sender, EventArgs e)
        {
            string cadena = txCodigo.Text;
            Lexe lex = new Lexe(cadena);
            lex.Estado_0();
            Tokens(lex.TOKENS);
            MessageBox.Show("Se han encontrado " + lex.Estado_Final().ToString() + " Errores", "Errores");
        }

        #endregion
    }
}
