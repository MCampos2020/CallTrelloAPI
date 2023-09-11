using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DesafioMJVCallAPI;
using Newtonsoft.Json;


//CallAPI();
ProcessJsonFileFromGitHub();

/*
 IMPORTANTE:
        Autora: Mônica Campos 
        Cel.:  11 96607-9416
        e-mail: Monica_RCampos@hotmail.com

        Desenvolvi o método static void ProcessLocalJsonFile(), que soluciona um desafio que encontrei ao tentar acessar a API do Trello. 
        Mesmo após criar uma conta e efetuar login, ainda enfrentei problemas de autorização, já que a API exige uma chave e um token específicos, 
        que não consegui localizar.

        Toda a lógica para interagir com a API estava pronta e funcional, e eu havia criado as classes necessárias para deserializar as respostas JSON, 
        que estão armazenadas no arquivo classesAuxiliares.cs. 
        No entanto, sem a chave e o token de acesso adequados, não era possível realizar chamadas bem-sucedidas à API do Trello.

        Para contornar esse problema, desenvolvi o método ProcessLocalJsonFile(), que utiliza uma abordagem alternativa. 
        Em vez de fazer chamadas diretas à API, ele lê o conteúdo de um arquivo JSON hospedado no GitHub. 
        O arquivo jsonTrello.txt contém o JSON que obtive anteriormente ao acessar manualmente a URL do Trello pelo navegador.

        Dessa forma, consegui continuar trabalhando com os dados e a lógica existentes, aproveitando o conteúdo do JSON, 
        mesmo sem a chave e o token de autenticação necessários para as chamadas API. 
        O método extrai informações relevantes do JSON e as utiliza conforme necessário, resolvendo assim o desafio de acesso à API do Trello.
 
 */


static void ProcessJsonFileFromGitHub()
{

    WebClient client = new WebClient();

    Stream stream = client.OpenRead("https://raw.githubusercontent.com/MCampos2020/CallTrelloAPI/main/jsonTrello.txt");

    // Lê o conteúdo do arquivo
    string jsonContent = new StreamReader(stream).ReadToEnd();

    CardUpdate card = JsonConvert.DeserializeObject<CardUpdate>(jsonContent);

    string name = card.Data.List.Name;
    Console.WriteLine("Name: " + name);
    Console.Read();
}

static void CallAPI()
{


    string apiUrl = "https://api.trello.com/1/actions/592f11060f95a3d3d46a987a"; 

    string apiKey = "830739a70547e9ea4c04523d1e35b71b"; // chave da API
    string token = "830739a70547e9ea4c04523d1e35b71b"; // token de autenticação

    using (HttpClient httpClient = new HttpClient())
    {
        try
        {
            ///exemplo de autenticacao extraído do site suporte trello
            string authorizationHeader = $"OAuth oauth_consumer_key=\"{apiKey}\", oauth_token=\"{token}\"";
            httpClient.DefaultRequestHeaders.Add("Authorization", authorizationHeader);


            HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
            
            
            ///StatusCode: 401, ReasonPhrase: 'Unauthorized'
            if (response.StatusCode==  HttpStatusCode.OK)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                CardUpdate cardUpdate = JsonConvert.DeserializeObject<CardUpdate>(jsonContent);

                string name = cardUpdate.Data.List.Name;
                Console.WriteLine("Name: "+ name);
            }
            else
            {
                Console.WriteLine("Erro na requisição. Status Code: " + response.StatusCode);
            }

        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Erro na requisição HTTP: " + ex.Message);
        }
    }

}
    
