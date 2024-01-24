using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Calculadora.Triggers.Tcalculadora
{
    public class Tboton : Behavior<Button>
    {
        // Almacenar una referencia al último botón presionado
        static Button Ultimo = null;

        protected override void OnAttachedTo(Button button)
        {
            base.OnAttachedTo(button);
            button.Pressed += Pressed;
        }

        protected override void OnDetachingFrom(Button button)
        {
            base.OnDetachingFrom(button);
            button.Pressed -= Pressed;
        }

        private void Pressed(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (Ultimo != null && Ultimo != button)
            {
                Ultimo.BackgroundColor = Color.FromHex("#1F1E1E");
            }

            button.BackgroundColor = Color.White;
            Ultimo = button;
        }
    }
}