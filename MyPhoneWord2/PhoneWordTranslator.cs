using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhoneWord2
{

    public static class PhoneWordTranslator
    {

        public static string ToNumber(string raw)
        // El método estático ToNumber de la clase PhonewordTranslator
        // traduce el número de texto alfanumérico a un número de teléfono convencional.
        {
            // [ ToNumber (tipo de formato , nombre de variable) ]la clase estatica sera de tipo string y tendra un metodo declarado
            // ya que recibe una variable de tipo string y es de nombre raw.
            // -----------------------------------------------------------------------------------------------------------------------
            // IsNullWhiteSpace indica si el string a evalluar/cadena se encuentra en blanco sera TRUE
            // lo que devuelve es un BOOLEAN com true o False como tal el receptor tiene que tener un BOOLEAN HABILLITADO
            // el return nulll indica terminar todo el proceso y sea un null tambien.
            if (string.IsNullOrWhiteSpace(raw))
                return null;

            // [ ToUpperInvariant() ]aca igualamos a una propiedad del metodo que estamos
            // pasando ToUpperInvariant sera pasar todos los valores a mayusculas
            raw = raw.ToUpperInvariant();


            // [ StringBuilder() ]se declara una variable con wl metodo STRINGBUILDER,
            // +++ para reconocer un metodo es con () +++
            //  sera de tipo STRING pero adicional tiene mas funciones (ejemplo .Length)
            //  por lo que si se quiere usar seria : StringBuilder(variable.Length)
            //  PERO tiene mas convinaciones todo depende que reciba entonces como tal
            //  el metodo esta en basico declarado y se le pondra el nombre de una variable
            var newNumber = new StringBuilder();

            // [ foreach ] recorre cada elemento de la coleccion, array, lista
            // lo que reciba en este caso se le pasara el raw y este sera una variable de nombre "c"
            // [ Contains(String) ] indica si lla cadena que se le pasa tiene el valor string 
            foreach (var c in raw)
            {
                // [ Contains(c) ]entonces para cada linea sera evalluar si el siguiente valor
                // que se le pasara al Contanins tiene el valor C que es cada linea
                // [ Append ] para a;adir el ultimo valor a la lista
                // a la lista que se va agregar es un stringbuilder cual permite tener otras metodos en interno y o funciones para cada elemento
                if (" -0123456789".Contains(c))
                    newNumber.Append(c);
                else
                {

                    //se declara una variable con el nombnre "resullt" se
                    //le pasara tambien pasado a numero el valor de cada elemento que es "c"
                    var result = TranslateToNumber(c);

                    // si el valor NO esta vacio ya que esta negando con el ! se a;adira el resultado el cualto esta arriba
                    if (result != null)
                        newNumber.Append(result);

                    // si esto no se cumpel terminar todo --- return
                    else
                        return null;
                }
            }

            // se devuelve una cadena string 
            return newNumber.ToString();
        }



        // se declara un metodo BOOLLEANO en el que recibe un STRING aplicando este objeto de nombre keystring y otro CHAR de nombre c
        // solo si es TRUE se aplicara lo que esta dentro de las lllaves entonces el keystring de cada item es igual o mayor que 0
        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

        // otro metodo de sollo lectura de tipo array de nombre digits con la siguiente cadena 
        static readonly string[] digits = {
            "ABC","DEF","GHI","JKL","MNO","PQRS","TUV","WXYZ"
        };

        // una varible int de nombre translatetonumbre que recibe un char 
        // entra en un bucle para evalluar cada filade la lista que indica si cada numero de evaluacuon pasaria a recorrer la fila y buscar una vez que lo encuentre encada fila en adelante se termina
        static int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c))
                    return 2 + i;
            }
            return null;
        }
    }
}
