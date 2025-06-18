// See https://aka.ms/new-console-template for more information
using System.Text.Json;

Console.WriteLine("Hello, World!");

public class Tarea
{
    public int userId { get; set; }
    public int id { get; set; }
    public string? title { get; set; }
    public bool completed { get; set; }
}

public class UsuariosServ
{
    private static readonly HttpClient client = new HttpClient();
    private static async Task GetUser()
    {
        var url = "https://jsonplaceholder.typicode.com/todos/";
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

        List<Tarea>? listTd = JsonSerializer.Deserialize<List<Tarea>>(responseBody);

        if (listTd != null)
        {
            foreach (var item in listTd)
            {
                Console.WriteLine("User id: " + item.userId + " Id: " + item.id + "Titulo" + item.title + "Completado" + item.completed);
            }
        }
    }

}