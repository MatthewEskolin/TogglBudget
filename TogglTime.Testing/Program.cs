using System.Diagnostics;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using TogglTimeWeb.API;

//Make a Call to the Rest Client and attempt to return a basic report

var workspace = new Workspace() {id = 4, name = "w4"};
var workspace1 = new Workspace() {id = 3, name = "w3"};
var workspace2 = new Workspace() {id = 2, name = "w2"};

var list = new List<Workspace> {workspace, workspace1, workspace2};


var reportWorkspaces = list;

var dataAsString = JsonConvert.SerializeObject(reportWorkspaces);
var content = new StringContent(dataAsString);
content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

var httpClient = new HttpClient();



var result = await httpClient.PostAsync("http://localhost/api/userreport", content);
var contentString = result.Content.ReadAsStringAsync();




//var client = new TogglRestClient();

//var result = await client.GetUserData();

////Print Out Workspaces

//Console.WriteLine();

//Console.WriteLine("**WORKSPACES**");

//if (result.data is { workspaces: { } })
//{
//    foreach (var workspace in result.data.workspaces)
//    {
//        Console.WriteLine(workspace.name);
//    }
//}

////TEST JSON BODY 





//For Each Workspace get the 

Console.WriteLine();

//Console.Write(result.ToString());


Console.ReadLine();





