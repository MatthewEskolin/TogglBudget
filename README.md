## Development Log 

01/30/2022
-Started dashboard that would show us how much total time we have logged in Toggl in the current week using Toggl API

02/05/2022
-Twitch Stream for an Hour. Continue on dashboard

02/05/2022
-Trying to Get Links on Top to get away from default template
-Add the Bar Graph on the Dashboard Page

02/19/2022
-Work on UI CRUD Form - Should have ability to Display a Grid From DB/Update Records/Delete Records/View Record Details

02/27/2022
-Getting CRUD Working in Blazor - get comfortable interaction with sqlite

03/12/2022
-Keep working with SQL Lite and verifying CRUD Operations
-Javascript for ProgressBar

03/13/2022
-Add 2 more progress bars

03/18/2022
-Add a gitignore

03/19/2022
Start adding TogglAPI connectivity

03/19/2022
Build Connection to TogglAPI and query the total logged time for the week
API documentation canbe found here
https://github.com/toggl/toggl_api_docs

04/02/2022
Calculate How much time logged in ALL workspaces or only selected workspaces

04/03/022
Continue adding workspaces dropdown

04/15/2022
Verify workspaces dropdown
https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types

04/16/2022
Got the app running on IIS

04/23/2022
Continue to work on the multi-workspace logged time total -


04/24/2022
-Need to figure out how to deserialize the dictionary
-Need to continue with the select element for workspaces - and trigger a change event that will update the graph for the selected workspace
-We started experimenting in the - TestComponent2 -> 
    [Parameter]  
    public EventCallback<string> TestValueChanged { get; set; }  

-Start building a list on the left for different categories of time - so we can this app somewhat useful - and really show a useful
application of the toggl API.

04/25/2022



use this to fix toggl buckets

fix dbcontext nullable warning by removing ?


## TODO
-Come up with a name for this App before integrating with Toggl

--USE A DIAGRAM BUILDER TO SHOW THE ARHITECTURE OF THIS APP


-figure out the best way to get the total time tracked from the Toggl API.

-Start Creating a bar graph to show time metrics. Things like total time tracked. a Time Budget for different
categories/tags and show how much we have used in the graph.

--Create a Tagging rules Engine
https://automate.io/integration/toggl/webhooks

https://codepen.io/olufemi/pen/QRvRjQ








