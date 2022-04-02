using TogglTimeWeb.API;

//Make a Call to the Rest Client and attempt to return a basic report

var client = new TogglRestClient();

var result = await client.GetUserData();

//Print Out Workspaces

Console.WriteLine();

Console.WriteLine("**WORKSPACES**");

foreach (var workspace in result.data.workspaces)
{
    Console.WriteLine(workspace.name);
}

//For Each Workspace get the 

Console.WriteLine();

Console.Write(result.ToString());


Console.ReadLine();





