using System.Net.Http.Json;

namespace test_csharp;
class Program
{
    static void Main(string[] args)
    {
        ChatProvider chatProvider = new ChatProvider();

        Console.WriteLine("empezo la tarea");
        Task<Chat> tareaChat = chatProvider.ObtenerChats();

        tareaChat.Wait();
        Console.WriteLine("termino la tarea");
        if (tareaChat.IsCompletedSuccessfully)
        {
            Chat chat = tareaChat.Result;
            foreach (var item in chat.Chats)
            {
                Console.WriteLine(item.Emisor.Apellido);
            }
        }




        Emisor emisor = new Emisor() { Nombre = "csharp", Apellido = "Consola", Edad = 7, Email = "csharp@consola.com" };
        Mensaje mensaje = new Mensaje() { Contenido = "Hola desde la consola Csharp", FechaEnvio = DateTime.Now.ToString() };

        Conversacion conversacion = new Conversacion() { Emisor = emisor, Mensaje = mensaje };

        Task<Conversacion> tareaConversacion = chatProvider.InsertarConversacion(conversacion);

        tareaConversacion.Wait();

        if (tareaConversacion.IsCompletedSuccessfully)
        {
            Conversacion conversacionInsertada = tareaConversacion.Result;
            Console.WriteLine(conversacionInsertada.Mensaje.Contenido);
        }

    }
}
