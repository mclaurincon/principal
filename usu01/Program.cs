// See https://aka.ms/new-console-template for more information
using Flurl.Http;
using usu01;

Console.WriteLine("Hello, World!");

string url = "https://localhost:7255/";

item tarefa1 = new item();
tarefa1.Id = 1;
tarefa1.Nome = "Pagar contas";
tarefa1.Finalizado = true;

item tarefa2 = new item();
tarefa2.Id = 3;
tarefa2.Nome = "Guardar contas";
tarefa2.Finalizado = false;



// gerar uma tarefa

string endpoint = url + "api/TarefaItems";

//flurl
endpoint.PostJsonAsync(tarefa1);
endpoint.PostJsonAsync(tarefa2);


// ler a lista
IEnumerable<item> ListaTarefas = await endpoint.GetJsonAsync<IEnumerable<item>>();

foreach (item item in ListaTarefas)
    {
    Console.WriteLine($"A tarefa: {item.Nome} está {item.Finalizado}");
}
Console.WriteLine("vamos alterar: Digite um id");

// alterar
int id = Convert.ToInt32(Console.ReadLine());
string endpoint_alterar = url + $"api/TarefaItems/{id}";

item tarefa3 = new item();
tarefa3.Id = 1;
tarefa3.Nome = "Receber salário";
tarefa3.Finalizado = false;

await endpoint_alterar.PutJsonAsync(tarefa3);

// ler a lista
IEnumerable<item> ListaTarefas1 = await endpoint.GetJsonAsync<IEnumerable<item>>();

foreach (item item in ListaTarefas)
{
    Console.WriteLine($"A tarefa: {item.Nome} está {item.Finalizado}");
}

Console.WriteLine("vamos deletar");


//deletar um item da lista

string endpoint_deletar = url + $"api/TarefaItems/2";
await endpoint_deletar.DeleteAsync();

//ler a lista
IEnumerable<item> ListaTarefas2 = await endpoint.GetJsonAsync<IEnumerable<item>>();

foreach (item item in ListaTarefas)
{
    Console.WriteLine($"A tarefa: {item.Nome} está {item.Finalizado}");
}


Console.WriteLine("aperte qualquer tecla para finalizar a aplicação");
Console.Read();