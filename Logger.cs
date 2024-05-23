using System;
using System.IO;

namespace DesignPatterns
{
    // 1.- Al definir el constructor como privado,
    //     previene que cualquier clase externa cree instancias de Logger.
    // 2.- El tipo Lazy<T> asegura que la instancia sera creada unicamente cuando sea necesario.
    //     Y considerando que sea thread-safe.
    // 3.- La propiedad estatica Instance devolvera siempre la misma instancia.
    // 4.- Y finalmente, la utilidad de este patron, sera insertar mensajes en un archivo;
    //     mediante el metodo publico Log.
    // 
    // Para hacer simple este ejemplo, el nombre de archivo 'log.txt' esta fijo, pero deberia ser leido
    // desde la configuracion.

    public class Logger {
        private static readonly Lazy<Logger> instance = new Lazy<Logger>(() => new Logger());

        private Logger() {
        }

        public static Logger Instance
        {
            get {
                return instance.Value;
            }
        }

        public void Log(string textMessage)
        {
            using(var stream = File.AppendText("log.txt")) {
                stream.WriteLine( $"{DateTime.Now}: {textMessage }");
            }
        }
    }
}