using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        public double numero1 = 0, numero2 = 0, numeroRespuesta = 0;
        //Operador inicia en 4 para evitar que haga nada aun
        int operador = 4;
        //One decimal es para saber si el primer span es decimal y two decimal es para verificar el tercer span
        bool isPunto = false, oneDecimal = false, twoDecimal;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Igualar_Valores(String operando, int valor)
        {
            //Verificar que si los valores son enteros o no comparandolo con operador que es un entero
            bool validaLb1 = lblNumero.Text.GetType() != operador.GetType();
            bool validaSpn = spnPrimero.Text.GetType() != operador.GetType();
            //Verificar si hay valores decimales o si solo hay enteros, si el numero es diferente de cero significa que ya se realizo alguna accion
            if(numeroRespuesta != 0 || ((validaLb1 || validaSpn) || (validaLb1 && validaSpn)))
            {
                oneDecimal = true;
            }
            if (oneDecimal)
            {
                //Si oneDecimal es True transforma el primer valor a decimal
                numero1 = double.Parse(lblNumero.Text);
            }
            else
            {
                //Si oneDecimal es False  el primer valor sera entero
                numero1 = int.Parse(lblNumero.Text);
            }

            spnPrimero.Text = numero1 + " ";
            lblNumero.Text = "0";
            //Toma el valor del operador
            spnSegundo.Text = operando;
            //Selecciona el case a usar
            operador = valor;
            isPunto = false;
        }

        private bool Lleno()
        {
            bool estaLleno = false;
            //Si el primer span esta vacio y el segundo tambien esta lleno sera True, evitara usar operadores si no hay numeros seleccionados
            if(spnPrimero.Text == "" && spnSegundo.Text == "")
            {
                estaLleno = true;
            }
            return estaLleno;
        }

        private void Poner_Numeros(String numero)
        {
            //Si lblNumero es igual a cero significa que no hay ningun valor aun y que sea diferente a un punto porque significa que debe haber un valor detras o un cero al menos
            if(lblNumero.Text == "0" && numero != ".")
            {
                lblNumero.Text = numero;
            }
            //Si hay un numero ingresado previamente lo concatenara 
            else
            {
                lblNumero.Text += numero;
            }
        }

        private void Btn_AC(object sender, EventArgs e)
        {
            //Devolver todos los valores a cero o nulo
            numero1 = 0;
            numero2 = 0;
            numeroRespuesta = 0;
            isPunto = false;
            spnPrimero.Text = "";
            spnSegundo.Text= "";
            spnTercero.Text = "";
            lblNumero.Text= "0";
        }
        private void Btn_Sumar(object sender, EventArgs e)
        {
            //Selecciona el numero de la accion de suma en este caso es el cero
            Igualar_Valores("+", 0);
            if (Lleno())
            {
                spnTercero.Text= "";
            }
        }

        private void Click_C(object sender, EventArgs e)
        {
            //Si el numero termina con un punto entonces al ser borrado isPunto pasa a ser False
            if (lblNumero.Text.EndsWith("."))
            {
                isPunto = false;
            }
            //Si el numero es cero o cero punto entrara a la condicional porque en el primer caso no hay nada que borrar y en el segundo el anterior if se hace cargo
            if (lblNumero.Text != "0" && lblNumero.Text != "0.")
            {
                //Si no es mayor a 10 el numero es solo de una cifra, esta no se borra si no que pasa a ser cero
                if (double.Parse(lblNumero.Text) > 10)
                {
                    //Con el length cuentas la longitud del numero y se le va restando uno, cuando solo queda un numero pasa a ser cero
                    lblNumero.Text = lblNumero.Text.Substring(0, lblNumero.Text.Length - 1);
                }
                else
                {
                    lblNumero.Text = "0";
                }
            }
            if (lblNumero.Text.EndsWith("."))
            {
                //Lo mismo de lo anterior pero ahora borra el punto para que el isPunto que ahora es false tenga sentido y no quede el punto ahi de colado
                lblNumero.Text = lblNumero.Text.Substring(0, lblNumero.Text.Length - 1);
            }

        }

        private void Btn_Restar(object sender, EventArgs e)
        {
            //Mismo caso que con la suma solo cambia el numero de la accion
            Igualar_Valores("-", 1);
            if (Lleno())
            {
                spnTercero.Text = "";
            }
        }

        private void Btn_Por(object sender, EventArgs e)
        {
            //Mismo caso que con la suma y resta solo cambia el numero de la accion
            Igualar_Valores("*", 2);
            if (Lleno())
            {
                spnTercero.Text = "";
            }
        }

        private void Btn_Dividir(object sender, EventArgs e)
        {
            //Mismo caso que con los anteriores solo cambia el numero de la accion
            Igualar_Valores("/", 3);
            if (Lleno())
            {
                spnTercero.Text = "";
            }
        }

        private void Click_Uno(object sender, EventArgs e)
        {
            Poner_Numeros("1");
        }
        private void Click_Dos(object sender, EventArgs e)
        {
            Poner_Numeros("2");
        }
        private void Click_Tres(object sender, EventArgs e)
        {
            Poner_Numeros("3");
        }
        private void Click_Cuatro(object sender, EventArgs e)
        {
            Poner_Numeros("4");
        }
        private void Click_Cinco(object sender, EventArgs e)
        {
            Poner_Numeros("5");
        }
        private void Click_Seis(object sender, EventArgs e)
        {
            Poner_Numeros("6");
        }
        private void Click_Siete(object sender, EventArgs e)
        {
            Poner_Numeros("7");
        }
        private void Click_Ocho(object sender, EventArgs e)
        {
            Poner_Numeros("8");
        }
        private void Click_Nueve(object sender, EventArgs e)
        {
            Poner_Numeros("9");
        }
        private void Click_Cero(object sender, EventArgs e)
        {
            //Si el primer numero es cero entonces no te dejara poner otro cero seguido
            if (lblNumero.Text != "0")
            {
                Poner_Numeros("0");
            }
        }

        private void Click_Return(object sender, EventArgs e)
        {
            //Este no lo entendi bien
            Navigation.PopAsync();
        }

        private void Btn_Igual(object sender, EventArgs e)
        {
            //Solo entrara a la condicion si el primer span y el segundo tienen un valor
            if(spnPrimero.Text != "" && spnSegundo.Text != "")
            {
                //El tercer span mostrara el resultado de antemano en pantalla
                spnTercero.Text = " " + lblNumero.Text;
                //Mismo caso que con ingresar numero
                if (twoDecimal)
                {
                    numero2 = double.Parse(spnTercero.Text);
                }
                else
                {
                    numero2 = int.Parse(spnTercero.Text);
                }
                //Las operaciones
                if(operador == 0)
                {
                    numeroRespuesta = numero1 + numero2;
                    lblNumero.Text = numeroRespuesta + "";
                }
                else if(operador == 1)
                {
                    numeroRespuesta = numero1 - numero2;
                    lblNumero.Text = numeroRespuesta + "";
                }
                else if (operador == 2)
                {
                    numeroRespuesta = numero1 * numero2;
                    lblNumero.Text = numeroRespuesta + "";
                }
                else
                {
                    //Condicion que evita que dividas entre cero devolviendo siempre el valor uno
                    if (numero2 == 0)
                    {
                        numero2 = 0;
                    }
                    numeroRespuesta = numero1 / numero2;
                    lblNumero.Text = numeroRespuesta + "";
                }
                numero1 = 0;
                numero2 = 0;
                numeroRespuesta = 0;
                operador = 4;
                oneDecimal = false;
                twoDecimal = false;

            }
        }

        private void Click_Punto(object sender, EventArgs e)
        {
            //Evitar que se puedan agregar mas puntos
            if (!isPunto)
            {
                Poner_Numeros(".");
                isPunto = true;
            }
            //Estos no los acabe de comprender
            if(operador == 4)
            {
                oneDecimal = true;
            }
            else
            {
                twoDecimal = true;
            }
        }
    }
}
