# SoftUni-MixologyWeb-CSharp-Project
A web application dedicated to mixology and cocktails, made as graduation project for SoftUni ASP .NET Core module.

The Application is designed to work with SQL Database (Microsoft SQL Server was used during development). 
The SQL server must be running and all migrations must be applied before the application can run.

The following functionality is implemented:
User Registration and Login;
Users can change their password;
Roles for Users can by assigned (Administrator, Manager, Guest, Banned);
The Administrator (User with Role of Administrator) can assign roles to all Users and can also change their Usernames (username must be a valid email);
The link for the Users management page is generated only for the Administrator and the Page cannot be accessed by Users who are not administrators;
A Privacy policy page;
A Contact us page with contact form (the form sends POST request with the form data but the data is not stored);
Page with list (cards) of all the cocktails with summary information;
Details page for every cocktail with additional information. 

Planned functionality:
Page for adding cocktails;
Form for editing and deleting cocktails by the user who added them;
Search bar
