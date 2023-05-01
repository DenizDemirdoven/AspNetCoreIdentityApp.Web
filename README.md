# ASP.NET CORE 7.0

### Table of Contents

- [About Project](#about-project)
- [Main Features](#main-features)
- [3rd Party Libraries](#3rd-party-libraries)
- [Credits](#credits)

### About Project

- This is an Asp.Net Core MVC web project to practice membership system using Core Identity library. 
- Access is provided according to Role Based Authorization, Claim Based Authorization and Policy Based Authorization scenarios. 
- Models were determined with the Coding First approach and the database was created with migration.
- MSSQL is used as database. ConnectionStrings can be found in appsettings.Development.json
- MVC Area is used for Admin. This mvc area can have its own models, views and controllers.
- To send email there is an IEmailService interface and an EmailServices class. EmailSettings can be found in [appsettings.Development.json]

### Main Features

- Users can SignUp or SignIn by using buttons in top navigation. 
- Users can view profile, edit their user data, change their password.
- A cookie is created when the user logs in. Cookie configuration can be found in "program.cs".
- There is a ForgetPassword method in HomeController. EmailServices sends reset password link to user mail if there is a registered email.
- Roles can be managed by Admin only. (create, update, view and assign a role to users)
- There are 3 policies for authorization in "program.cs". 
    - ("city", "İstanbul") : checks the user's city field. If the city is not null and if it is "İstanbul", then the user can view İstanbul page.
    - "CampaignPolicy" : checks user claim type(ChampaignExpireDate). The campaign is valid for 10 days from the date the user becomes a member. 
    - "ViolencePolicy" : checks and calculates the user's birthdate. (ThresholdAge=18)  

### 3rd Party Libraries

The following libraries are used in the application:

- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.VisualStudio.Web.CodeGeneration.Design

### Credits

Deniz Demirdöven

- [Github](https://github.com/DenizDemirdoven)
- [LinkedIn](https://www.linkedin.com/in/denizdemirdoven)
- [Email](mailto:denizdemirdoven@gmail.com)
- [Web](https://www.denizdemirdoven.com/)