using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculadora.VistaModelo
{

    public class VMcalcular : BaseViewModel
    {
        #region VARIABLES
        public double numero1 = 0, numero2 = 0, numeroRespuesta = 0;
        //Operador inicia en 4 para evitar que haga nada aun
        int operador = 4;
        //One decimal es para saber si el primer span es decimal y two decimal es para verificar el tercer span
        bool isPunto = false, oneDecimal = false, twoDecimal;
        string _Mensaje;
        string _spnPrimero;
        string _spnSegundo;
        string _spnTercero;
        string _lblNumero;

        #endregion
        #region CONSTRUCTOR
        public VMcalcular(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Mensaje
        {
            get { return _Mensaje; }
            set { SetValue(ref _Mensaje, value); }
        }
        public string spnPrimero
        {
            get { return _spnPrimero; }
            set { SetValue(ref _spnPrimero, value); }
        }
        public string spnSegundo
        {
            get { return _spnSegundo; }
            set { SetValue(ref _spnSegundo, value); }
        }
        public string spnTercero
        {
            get { return _spnTercero; }
            set { SetValue(ref _spnTercero, value); }
        }
        public string lblNumero
        {
            get { return _lblNumero; }
            set { SetValue(ref _lblNumero, value); }
        }
        #endregion
        #region PROCESOS

        private void Igualar_Valores(String operando, int valor)
        {


            //Verificar que si los valores son enteros o no comparandolo con operador que es un entero
            bool validaLb1 = Convert.ToInt32(lblNumero) != operador;
            bool validaSpn = Convert.ToInt32(spnPrimero) != operador;
            //Verificar si hay valores decimales o si solo hay enteros, si el numero es diferente de cero significa que ya se realizo alguna accion
            if (numeroRespuesta != 0 || ((validaLb1 || validaSpn) || (validaLb1 && validaSpn)))
            {
                oneDecimal = true;
            }
            if (oneDecimal)
            {
                //Si oneDecimal es True transforma el primer valor a decimal
                numero1 = double.Parse(lblNumero);
            }
            else
            {
                //Si oneDecimal es False  el primer valor sera entero
                numero1 = int.Parse(lblNumero);
            }

            spnPrimero = numero1 + " ";
            lblNumero = "0";
            //Toma el valor del operador
            spnSegundo = operando;
            //Selecciona el case a usar
            operador = valor;
            isPunto = false;
        }

        private bool Lleno()
        {
            bool estaLleno = false;
            //Si el primer span esta vacio y el segundo tambien esta lleno sera True, evitara usar operadores si no hay numeros seleccionados
            if (spnPrimero == "" && spnSegundo == "")
            {
                estaLleno = true;
            }
            return estaLleno;
        }

        private void Poner_Numeros(String numero)
        {
            //Si lblNumero es igual a cero significa que no hay ningun valor aun y que sea diferente a un punto porque significa que debe haber un valor detras o un cero al menos
            if (lblNumero == "0" && numero != ".")
            {
                lblNumero = numero;
            }
            //Si hay un numero ingresado previamente lo concatenara 
            else
            {
                lblNumero += numero;
            }
        }

        private void Btn_AC()
        {
            //Devolver todos los valores a cero o nulo
            numero1 = 0;
            numero2 = 0;
            numeroRespuesta = 0;
            isPunto = false;
            spnPrimero = "";
            spnSegundo = "";
            spnTercero = "";
            lblNumero = "0";
        }
        private void Btn_Sumar()
        {
            //Selecciona el numero de la accion de suma en este caso es el cero
            Igualar_Valores("+", 0);
            if (Lleno())
            {
                spnTercero = "";
            }
        }

        private void Click_C()
        {
            //Si el numero termina con un punto entonces al ser borrado isPunto pasa a ser False
            if (lblNumero.EndsWith("."))
            {
                isPunto = false;
            }
            //Si el numero es cero o cero punto entrara a la condicional porque en el primer caso no hay nada que borrar y en el segundo el anterior if se hace cargo
            if (lblNumero != "0" && lblNumero != "0.")
            {
                //Si no es mayor a 10 el numero es solo de una cifra, esta no se borra si no que pasa a ser cero
                if (double.Parse(lblNumero) > 10)
                {
                    //Con el length cuentas la longitud del numero y se le va restando uno, cuando solo queda un numero pasa a ser cero
                    lblNumero = lblNumero.Substring(0, lblNumero.Length - 1);
                }
                else
                {
                    lblNumero = "0";
                }
            }
            if (lblNumero.EndsWith("."))
            {
                //Lo mismo de lo anterior pero ahora borra el punto para que el isPunto que ahora es false tenga sentido y no quede el punto ahi de colado
                lblNumero = lblNumero.Substring(0, lblNumero.Length - 1);
            }

        }

        private void Btn_Restar()
        {
            //Mismo caso que con la suma solo cambia el numero de la accion
            Igualar_Valores("-", 1);
            if (Lleno())
            {
                spnTercero = "";
            }
        }

        private void Btn_Por()
        {
            //Mismo caso que con la suma y resta solo cambia el numero de la accion
            Igualar_Valores("*", 2);
            if (Lleno())
            {
                spnTercero = "";
            }
        }

        private void Btn_Dividir()
        {
            //Mismo caso que con los anteriores solo cambia el numero de la accion
            Igualar_Valores("/", 3);
            if (Lleno())
            {
                spnTercero = "";
            }
        }

        private void Click_Uno()
        {
            Poner_Numeros("1");
        }
        private void Click_Dos()
        {
            Poner_Numeros("2");
        }
        private void Click_Tres()
        {
            Poner_Numeros("3");
        }
        private void Click_Cuatro()
        {
            Poner_Numeros("4");
        }
        private void Click_Cinco()
        {
            Poner_Numeros("5");
        }
        private void Click_Seis()
        {
            Poner_Numeros("6");
        }
        private void Click_Siete()
        {
            Poner_Numeros("7");
        }
        private void Click_Ocho()
        {
            Poner_Numeros("8");
        }
        private void Click_Nueve()
        {
            Poner_Numeros("9");
        }
        private void Click_Cero()
        {
            //Si el primer numero es cero entonces no te dejara poner otro cero seguido
            if (lblNumero != "0")
            {
                Poner_Numeros("0");
            }
        }

        private void Click_Return()
        {
            //Este no lo entendi bien
            Navigation.PopAsync();
        }

        private void Btn_Igual()
        {
            //Solo entrara a la condicion si el primer span y el segundo tienen un valor
            if (spnPrimero != "" && spnSegundo != "")
            {
                //El tercer span mostrara el resultado de antemano en pantalla
                spnTercero = " " + lblNumero;
                //Mismo caso que con ingresar numero
                if (twoDecimal)
                {
                    numero2 = double.Parse(spnTercero);
                }
                else
                {
                    numero2 = int.Parse(spnTercero);
                }
                //Las operaciones
                if (operador == 0)
                {
                    numeroRespuesta = numero1 + numero2;
                    lblNumero = numeroRespuesta + "";
                }
                else if (operador == 1)
                {
                    numeroRespuesta = numero1 - numero2;
                    lblNumero = numeroRespuesta + "";
                }
                else if (operador == 2)
                {
                    numeroRespuesta = numero1 * numero2;
                    lblNumero = numeroRespuesta + "";
                }
                else
                {
                    //Condicion que evita que dividas entre cero devolviendo siempre el valor uno
                    if (numero2 == 0)
                    {
                        numero2 = 0;
                    }
                    numeroRespuesta = numero1 / numero2;
                    lblNumero = numeroRespuesta + "";
                }
                numero1 = 0;
                numero2 = 0;
                numeroRespuesta = 0;
                operador = 4;
                oneDecimal = false;
                twoDecimal = false;

            }
        }

        private void Click_Punto()
        {
            //Evitar que se puedan agregar mas puntos
            if (!isPunto)
            {
                Poner_Numeros(".");
                isPunto = true;
            }
            //Estos no los acabe de comprender
            if (operador == 4)
            {
                oneDecimal = true;
            }
            else
            {
                twoDecimal = true;
            }
        }
        public async Task ProcesoAsyncrono()
        {

        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsynCommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand Btn_DividirCommand => new Command(Btn_Dividir);
        public ICommand Btn_ACCommand => new Command(Btn_AC);
        public ICommand Btn_SumarCommand => new Command(Btn_Sumar);
        public ICommand Click_CCommand => new Command(Click_C);
        public ICommand Btn_RestarCommand => new Command(Btn_Restar);
        public ICommand Btn_PorCommand => new Command(Btn_Por);
        public ICommand Click_UnoCommand => new Command(Click_Uno);
        public ICommand Click_DosCommand => new Command(Click_Dos);
        public ICommand Click_TresCommand => new Command(Click_Tres);
        public ICommand Click_CuatroCommand => new Command(Click_Cuatro);
        public ICommand Click_CincoCommand => new Command(Click_Cinco);
        public ICommand Click_SeisCommand => new Command(Click_Seis);
        public ICommand Click_SieteCommand => new Command(Click_Siete);
        public ICommand Click_OchoCommand => new Command(Click_Ocho);
        public ICommand Click_NueveCommand => new Command(Click_Nueve);
        public ICommand Click_PuntoCommand => new Command(Click_Punto);
        public ICommand Btn_IgualCommand => new Command(Btn_Igual);
        public ICommand Click_CeroCommand => new Command(Click_Cero);
        public ICommand Click_ReturnCommand => new Command(Click_Return);


        #endregion
    }
}
