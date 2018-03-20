/* 
Archivo de codigo fuente:
Lex.cs
Creado en:
1/3/2018
Por:
Ikkram
Todos los derechos reservados, no se permite crear copias totales o parciales del codigo fuente.

Los usos no autorizados del mismo pueden y seran sancionados.
*/

/*
 * Lista de palabras reservadas aceptadas por el Lexer
 * 
 * Namespace
 * New
 * Class
 * String
 * Static
 * If
 * Int
 * For
 * Private
 * 
 */

namespace Lexer.Lex
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Defines the <see cref="Lexe" />
    /// </summary>
    public class Lexe
    {
        #region Fields

        /// <summary>
        /// Definir variable privada _Cadena
        /// </summary>
        internal string _Cadena;

        /// <summary>
        /// Defines the BUFFER
        /// </summary>
        internal string BUFFER;

        /// <summary>
        /// Defines the errorCount
        /// </summary>
        internal int errorCount = 0;

        /// <summary>
        /// Defines the ERRORES
        /// </summary>
        internal List<string> ERRORES = new List<string>();

        /// <summary>
        /// Defines the LETRAS
        /// </summary>
        internal string LETRAS = "[a-zA-Z]";

        /// <summary>
        /// Defines the MAYUSCULAS
        /// </summary>
        internal string MAYUSCULAS = "[A-Z]";

        /// <summary>
        /// Defines the MINUSCULAS
        /// </summary>
        internal string MINUSCULAS = "[a-z]";

        /// <summary>
        /// Defines the NUMEROS
        /// </summary>
        internal string NUMEROS = "[0-9]";

        // Variables para el proceso de la cadena        
        /// <summary>
        /// Definir la variable de posicion
        /// </summary>
        internal int posicion = 0;

        /// <summary>
        /// Definir variable temporal para el tamaño de la cadena temp
        /// </summary>
        internal int temp;

        /// <summary>
        /// Defines the tokenconunt
        /// </summary>
        internal int tokenconunt = 0;

        /// <summary>
        /// Defines the TOKENS
        /// </summary>
        internal List<string> TOKENS = new List<string>();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Lex"/> class.
        /// </summary>
        /// <param name="cadena">The <see cref="string"/></param>
        public Lexe(string cadena)
        {
            temp = cadena.Length - 1;
            Cadena = cadena;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Cadena
        /// </summary>
        internal string Cadena
        {
            get { return _Cadena; }
            set { _Cadena = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The Estado_0
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        internal int Estado_0()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'N':
                    BUFFER += simbolo.ToString();
                    return Estado_1();
                case 'C':
                    BUFFER += simbolo.ToString();
                    return Estado_14();
                case 'S':
                    BUFFER += simbolo.ToString();
                    return Estado_20();
                case 'I':
                    BUFFER += simbolo.ToString();
                    return Estado_32();
                case 'F':
                    BUFFER += simbolo.ToString();
                    return Estado_38();
                case 'P':
                    BUFFER += simbolo.ToString();
                    return Estado_42();
                default:
                    if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        BUFFER += simbolo.ToString();
                        return Estado_55();
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        BUFFER += simbolo.ToString();
                        return Estado_50();
                    }
                    else if (simbolo == '\0')
                    {
                        // Desencadena el final del programa
                        return Estado_Final();
                    }
                    else
                    {
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_0
        /// </summary>
        /// <param name="Simbolo">The <see cref="char"/></param>
        /// <returns>The <see cref="int"/></returns>
        internal int Estado_0(char Simbolo)
        {
            char simbolo = Simbolo;
            switch (simbolo)
            {
                case 'N':
                    BUFFER += simbolo.ToString();
                    return Estado_1();
                case 'C':
                    BUFFER += simbolo.ToString();
                    return Estado_14();
                case 'S':
                    BUFFER += simbolo.ToString();
                    return Estado_20();
                case 'I':
                    BUFFER += simbolo.ToString();
                    return Estado_32();
                case 'F':
                    BUFFER += simbolo.ToString();
                    return Estado_38();
                case 'P':
                    BUFFER += simbolo.ToString();
                    return Estado_42();
                default:
                    if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        BUFFER += simbolo.ToString();
                        return Estado_55();
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        BUFFER += simbolo.ToString();
                        return Estado_50();
                    }
                    else
                    {
                        // Desencadena el final del programa
                        return Estado_Final();
                    }
            }
        }

        /// <summary>
        /// The Estado_3
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        internal int Estado_3()
        {
            char simbolo = Leer();
            // Estado de aceptación
            return Estado_4(simbolo);
        }

        /// <summary>
        /// The Estado_35
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        internal int Estado_35()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 't':
                    BUFFER += simbolo.ToString();
                    return Estado_36();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// Estado_4, Evaluacion de TOKEN positivo
        /// Se determina si el siguiente simbolo leido es parte de un identificador o un caracter desconocido.
        /// </summary>
        /// <param name="Simbolo">The <see cref="char"/></param>
        /// <returns>The <see cref="int"/></returns>
        internal int Estado_4(char Simbolo)
        {
            if (Simbolo == ' ' || Simbolo == '\n' || Simbolo == '\r')
            {
                // TOKEN valido, inicia proceso de lectura del siguiente simbolo
                //TOKENS.SetValue(BUFFER, tokenconunt);
                TOKENS.Add(BUFFER);
                tokenconunt++;
                BUFFER = null;
                return Estado_0();
            }
            else if (Regex.IsMatch(Simbolo.ToString(), MAYUSCULAS))
            {
                // TOKEN valido, inicia proceso de lectura del simbolo actual en el Estado_0 enviado el parametro con el caracter actual
                TOKENS.Add(BUFFER);
                tokenconunt++;
                BUFFER = null;
                return Estado_0(Simbolo);
            }
            else if (Regex.IsMatch(Simbolo.ToString(), MINUSCULAS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_50
                return Estado_50(Simbolo);
            }
            else if (Regex.IsMatch(Simbolo.ToString(), NUMEROS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_50
                return Estado_53(Simbolo);
            }
            else
            {
                // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                ERRORES.Add(Simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_5
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        internal int Estado_5()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'm':
                    BUFFER += simbolo.ToString();
                    return Estado_6();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        return Estado_53(simbolo);
                    }
                    else if (simbolo == '_')
                    {
                        return Estado_52(simbolo);
                    }
                    else
                    {
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_Final
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        internal int Estado_Final()
        {
            BUFFER = null;
            temp = 0;
            return errorCount;
        }

        /// <summary>
        /// The Estado_1
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_1()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'e':
                    BUFFER += simbolo.ToString();
                    return Estado_2();
                case 'a':
                    BUFFER += simbolo.ToString();
                    return Estado_5();
                default:
                    if (simbolo == ' ' || simbolo == '\r' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        return Estado_53(simbolo);
                    }
                    else if (simbolo == '_')
                    {
                        return Estado_52(simbolo);
                    }
                    else
                    {
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_10
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_10()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'c':
                    BUFFER += simbolo.ToString();
                    return Estado_11();
                default:
                    if (simbolo == '_')
                    {
                        return Estado_52(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_11
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_11()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'e':
                    BUFFER += simbolo.ToString();
                    return Estado_12();
                default:
                    if (simbolo == '_')
                    {
                        return Estado_52(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_12
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_12()
        {
            char simbolo = Leer();
            return Estado_13(simbolo);
        }

        /// <summary>
        /// The Estado_13
        /// </summary>
        /// <param name="Simbolo">The <see cref="char"/></param>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_13(char Simbolo)
        {
            if (Simbolo == ' ' || Simbolo == '\n')
            {
                // TOKEN valido, inicia proceso de lectura del siguiente simbolo
                TOKENS.Add(BUFFER);
                tokenconunt++;
                BUFFER = null;
                return Estado_0();
            }
            else if (Regex.IsMatch(Simbolo.ToString(), LETRAS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_50
                return Estado_50(Simbolo);
            }
            else if (Regex.IsMatch(Simbolo.ToString(), NUMEROS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_53
                return Estado_53(Simbolo);
            }
            else
            {
                // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                ERRORES.Add(Simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_14
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_14()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'l':
                    BUFFER += simbolo.ToString();
                    return Estado_15();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_15
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_15()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'a':
                    BUFFER += simbolo.ToString();
                    return Estado_16();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_16
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_16()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 's':
                    BUFFER += simbolo.ToString();
                    return Estado_17();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_17
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_17()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 's':
                    BUFFER += simbolo.ToString();
                    return Estado_18();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_18
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_18()
        {
            char simbolo = Leer();
            return Estado_19(simbolo);
        }

        /// <summary>
        /// The Estado_19
        /// </summary>
        /// <param name="simbolo">The <see cref="char"/></param>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_19(char simbolo)
        {
            if (simbolo == ' ' || simbolo == '\n')
            {
                // TOKEN valido, inicia proceso de lectura del siguiente simbolo
                TOKENS.Add(BUFFER);
                tokenconunt++;
                BUFFER = null;
                return Estado_0();
            }
            else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_50
                return Estado_50(simbolo);
            }
            else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_53
                return Estado_53(simbolo);
            }
            else
            {
                // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_2
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_2()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'w':
                    BUFFER += simbolo.ToString();
                    return Estado_3();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        return Estado_53(simbolo);
                    }
                    else if (simbolo == '_')
                    {
                        return Estado_52(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_20
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_20()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 't':
                    BUFFER += simbolo.ToString();
                    return Estado_21();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_21
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_21()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'r':
                    BUFFER += simbolo.ToString();
                    return Estado_22();
                case 'a':
                    BUFFER += simbolo.ToString();
                    return Estado_27();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_22
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_22()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'i':
                    BUFFER += simbolo.ToString();
                    return Estado_23();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_23
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_23()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'n':
                    BUFFER += simbolo.ToString();
                    return Estado_24();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_24
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_24()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'g':
                    BUFFER += simbolo.ToString();
                    return Estado_25();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_25
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_25()
        {
            char simbolo = Leer();
            return Estado_26(simbolo);
        }

        /// <summary>
        /// The Estado_26
        /// </summary>
        /// <param name="simbolo">The <see cref="char"/></param>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_26(char simbolo)
        {
            if (simbolo == ' ' || simbolo == '\n')
            {
                TOKENS.Add(BUFFER);
                tokenconunt++;
                BUFFER = null;
                return Estado_0();
            }
            else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_50
                return Estado_50(simbolo);
            }
            else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_53
                return Estado_53(simbolo);
            }
            else
            {
                // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_27
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_27()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 't':
                    BUFFER += simbolo.ToString();
                    return Estado_28();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_28
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_28()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'i':
                    BUFFER += simbolo.ToString();
                    return Estado_29();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_29
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_29()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'c':
                    BUFFER += simbolo.ToString();
                    return Estado_30();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_30
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_30()
        {
            char simbolo = Leer();
            return Estado_31();
        }

        /// <summary>
        /// The Estado_31
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_31()
        {
            char simbolo = Leer();

            if (simbolo == ' ' || simbolo == '\n')
            {
                TOKENS.Add(BUFFER);
                tokenconunt++;
                BUFFER = null;
                return Estado_0();
            }
            else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_50
                return Estado_50(simbolo);
            }
            else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_53
                return Estado_53(simbolo);
            }
            else
            {
                // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_32
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_32()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'f':
                    BUFFER += simbolo.ToString();
                    return Estado_33();
                case 'n':
                    BUFFER += simbolo.ToString();
                    return Estado_35();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_33
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_33()
        {
            char simbolo = Leer();
            return Estado_34(simbolo);
        }

        /// <summary>
        /// The Estado_34
        /// </summary>
        /// <param name="simbolo">The <see cref="char"/></param>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_34(char simbolo)
        {
            if (simbolo == ' ' || simbolo == '\n')
            {
                TOKENS.Add(BUFFER);
                tokenconunt++;
                BUFFER = null;
                return Estado_0();
            }
            else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_50
                return Estado_50(simbolo);
            }
            else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_53
                return Estado_53(simbolo);
            }
            else
            {
                // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_36
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_36()
        {
            char simbolo = Leer();
            return Estado_37(simbolo);
        }

        /// <summary>
        /// The Estado_37
        /// </summary>
        /// <param name="simbolo">The <see cref="char"/></param>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_37(char simbolo)
        {
            if (simbolo == ' ' || simbolo == '\n')
            {
                TOKENS.Add(BUFFER);
                tokenconunt++;
                BUFFER = null;
                return Estado_0();
            }
            else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_50
                return Estado_50(simbolo);
            }
            else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_53
                return Estado_53(simbolo);
            }
            else
            {
                // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_38
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_38()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'o':
                    BUFFER += simbolo.ToString();
                    return Estado_39();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_39
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_39()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'r':
                    BUFFER += simbolo.ToString();
                    return Estado_40();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_40
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_40()
        {
            char simbolo = Leer();
            return Estado_41(simbolo);
        }

        /// <summary>
        /// The Estado_41
        /// </summary>
        /// <param name="simbolo">The <see cref="char"/></param>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_41(char simbolo)
        {
            if (simbolo == ' ' || simbolo == '\n')
            {
                TOKENS.Add(BUFFER);
                tokenconunt++;
                BUFFER = null;
                return Estado_0();
            }
            else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_50
                return Estado_50(simbolo);
            }
            else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_53
                return Estado_53(simbolo);
            }
            else
            {
                // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_42
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_42()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'r':
                    BUFFER += simbolo.ToString();
                    return Estado_43();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_43
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_43()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'i':
                    BUFFER += simbolo.ToString();
                    return Estado_44();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_44
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_44()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'v':
                    BUFFER += simbolo.ToString();
                    return Estado_45();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_45
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_45()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'a':
                    BUFFER += simbolo.ToString();
                    return Estado_46();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_46
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_46()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 't':
                    BUFFER += simbolo.ToString();
                    return Estado_47();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_47
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_47()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'e':
                    BUFFER += simbolo.ToString();
                    return Estado_48();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// The Estado_48
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_48()
        {
            char simbolo = Leer();
            return Estado_49(simbolo);
        }

        /// <summary>
        /// The Estado_49
        /// </summary>
        /// <param name="simbolo">The <see cref="char"/></param>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_49(char simbolo)
        {
            if (simbolo == ' ' || simbolo == '\n')
            {
                TOKENS.Add(BUFFER);
                tokenconunt++;
                BUFFER = null;
                return Estado_0();
            }
            else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_50
                return Estado_50(simbolo);
            }
            else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
            {
                // TOKEN no completado, continual el proceso de lectura en el Estado_53
                return Estado_53(simbolo);
            }
            else
            {
                // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_50
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_50()
        {
            char simbolo = Leer();
            if (simbolo == ' ' || simbolo == '\n')
            {
                return Estado_51(simbolo);
            }
            else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
            {
                BUFFER += simbolo.ToString();
                return Estado_50();
            }
            else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
            {
                BUFFER += simbolo.ToString();
                return Estado_53();
            }
            else if (simbolo == '_')
            {
                BUFFER += simbolo.ToString();
                return Estado_52();
            }
            else
            {
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_50
        /// </summary>
        /// <param name="simbolo">The <see cref="char"/></param>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_50(char simbolo)
        {
            if (simbolo == ' ' || simbolo == '\n')
            {
                return Estado_51(simbolo);
            }
            else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
            {
                BUFFER += simbolo.ToString();
                return Estado_50();
            }
            else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
            {
                BUFFER += simbolo.ToString();
                return Estado_53();
            }
            else
            {
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_51
        /// </summary>
        /// <param name="simbolo">The <see cref="char"/></param>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_51(char simbolo)
        {
            if (simbolo == ' ' || simbolo == '\n')
            {
                // TOKEN valido, inicia proceso de lectura del siguiente simbolo
                TOKENS.Add(BUFFER);
                tokenconunt++;
                BUFFER = null;
                return Estado_0();
            }
            else
            {
                // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_52
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_52()
        {
            char simbolo = Leer();
            if (simbolo == '_')
            {
                BUFFER += simbolo.ToString();
                return Estado_52();
            }
            else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
            {
                BUFFER += simbolo.ToString();
                return Estado_50();
            }
            else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
            {
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
            else
            {
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_52
        /// </summary>
        /// <param name="simbolo">The <see cref="char"/></param>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_52(char simbolo)
        {
            if (simbolo == '_')
            {
                BUFFER += simbolo.ToString();
                return Estado_52();
            }
            else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
            {
                BUFFER += simbolo.ToString();
                return Estado_50();
            }
            else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
            {
                BUFFER += simbolo.ToString();
                return Estado_53();
            }
            else
            {
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_53
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_53()
        {
            char simbolo = Leer();
            if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
            {
                BUFFER += simbolo.ToString();
                return Estado_53();
            }
            else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
            {
                BUFFER += simbolo.ToString();
                return Estado_50();
            }
            else if (simbolo == '_')
            {
                BUFFER += simbolo.ToString();
                return Estado_52();
            }
            else if (simbolo == ' ' || simbolo == '\n')
            {
                return Estado_51(simbolo);
            }
            else
            {
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_53
        /// </summary>
        /// <param name="simbolo">The <see cref="char"/></param>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_53(char simbolo)
        {
            if (simbolo == '_')
            {
                BUFFER += simbolo.ToString();
                return Estado_54();
            }
            else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
            {
                BUFFER += simbolo.ToString();
                return Estado_50();
            }
            else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
            {
                BUFFER += simbolo.ToString();
                return Estado_53();
            }
            else
            {
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();
            }
        }

        /// <summary>
        /// The Estado_54
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_54()
        {
            char simbolo = Leer();
            if (simbolo == '_')
            {
                BUFFER += simbolo.ToString();
                return Estado_54();
            }
            else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
            {
                BUFFER += simbolo.ToString();
                return Estado_53();
            }
            else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
            {
                BUFFER += simbolo.ToString();
                return Estado_50();
            }
            else if (simbolo == ' ' || simbolo == '\n')
            {
                ERRORES.Add(simbolo.ToString() + " :: " + "Identificador Erroneo");
                errorCount++;
                return Estado_0();
            }
            else
            {
                ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                errorCount++;
                return Estado_0();

            }
        }

        /// <summary>
        /// The Estado_55
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_55()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Estado_6
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_6()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'e':
                    BUFFER += simbolo.ToString();
                    return Estado_7();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        return Estado_50();
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        return Estado_54();
                    }
                    else if (simbolo == '_')
                    {
                        return Estado_52();
                    }
                    else
                    {
                        return 0;
                    }
            }
        }

        /// <summary>
        /// The Estado_7
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_7()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 's':
                    BUFFER += simbolo.ToString();
                    return Estado_8();
                default:
                    return 0;
            }
        }

        /// <summary>
        /// The Estado_8
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_8()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'p':
                    BUFFER += simbolo.ToString();
                    return Estado_9();
                default:
                    return 0;
            }
        }

        /// <summary>
        /// The Estado_9
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int Estado_9()
        {
            char simbolo = Leer();
            switch (simbolo)
            {
                case 'a':
                    BUFFER += simbolo.ToString();
                    return Estado_10();
                default:
                    if (simbolo == ' ' || simbolo == '\n')
                    {
                        return Estado_51(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), LETRAS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_50
                        return Estado_50(simbolo);
                    }
                    else if (Regex.IsMatch(simbolo.ToString(), NUMEROS))
                    {
                        // TOKEN no completado, continual el proceso de lectura en el Estado_53
                        return Estado_53(simbolo);
                    }
                    else
                    {
                        // Error encontrado, No se conoce el caracter evaluado, se continua el proceso de lectura en el Estado_0
                        ERRORES.Add(simbolo.ToString() + " :: " + "Caracter desconocido");
                        errorCount++;
                        return Estado_0();
                    }
            }
        }

        /// <summary>
        /// Lee y procesa la cadena de entrada
        /// </summary>
        /// <returns></returns>
        private char Leer()
        {
            char Caracter;
            if (posicion <= temp)
            {
                Caracter = char.Parse(Cadena.Substring(posicion, 1));
                posicion += 1;
                return Caracter;
            }
            else
            {
                return '\0';
            }
        }

        #endregion
    }
}
