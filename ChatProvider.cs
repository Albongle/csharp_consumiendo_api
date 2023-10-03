using System.Net.Http.Json;

namespace test_csharp;
public class ChatProvider
{
    private static string host;
    private static HttpClient httpClient;
    static ChatProvider()
    {
        ChatProvider.host = @"http://localhost:3000/v1/chat";
        ChatProvider.httpClient = new HttpClient();
    }

    public async Task<Chat> ObtenerChats()
    {
        HttpResponseMessage response = await ChatProvider.httpClient.GetAsync(ChatProvider.host);

        if (response.IsSuccessStatusCode)
        {
            Chat chat = await response.Content.ReadFromJsonAsync<Chat>();
            if (chat is not null)
            {
                return chat;
            }

        }
        throw new HttpRequestException("Sin contendido");

    }

    public async Task<Conversacion> InsertarConversacion(Conversacion conversacion)
    {
        HttpResponseMessage response = await ChatProvider.httpClient.PostAsJsonAsync<Conversacion>(ChatProvider.host, conversacion);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Conversacion>();
        }

        throw new HttpRequestException("Error al insertar");
    }
}