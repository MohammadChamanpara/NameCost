# Name Cost, A number converter
A sample application which converts a currency number to words.  
For example 123.45 will be converted to ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS

## Convert a number into words
  1. Visit the NameCost site at [namecost-ui.azurewebsites.net](http://namecost-ui.azurewebsites.net).
  1. Write your number in the cost box.
  1. Click Generate Words.
  1. In a new page, you’ll see the words for your number.   

## Table of contents

  * [Name Cost, A number converter](#name-cost-a-number-converter)
  * [Convert a number into words](#convert-a-number-into-words)
  * [Table of contents](#table-of-contents)  
  * [Implementation Notes](#implementation-notes)  
  * [Working Instance on Azure](#working-instance-on-azure)
  * [Azure Application Insights](#azure-application-insights)
  * [REST API](#rest-api)
  * [Unit Tests](#unit-tests)
  * [Solution Structure](#solution-structure)
  * [Acknowledgements](#acknowledgements)

## Implementation Notes
It is tried to design the structure of the application to be highly extensible and easily maintainable.
Implementation and design best practices have been employed to serve as means to create a well crafted testable code.
Although the implementation has taken place in a limited time frame, therefore there are several points of improvement.
  
In this project, Microsoft Asp.Net MVC is used for the UI and Microsoft Asp.Net WebApi for the implemented API of the application.
Dependency Injection is enabled thanks to the Microsoft Unity and some frameworks such as Moq and FluentAssertions are used for Mocking and assertions in the unit tests.

The logic of the application is injected in, using the strategy pattern. Currently, the implementation is based on using a currency class. This can be replaced with another approach in a convenient manner.  
  
## Working Instance on Azure
A working instance of the Link application is deployed to a Microsoft Azure Web App and accessible via [namecost-ui.azurewebsites.net](http://namecost-ui.azurewebsites.net/). The API of the application is also deployed to an API App and can be accessed and consumed by client applications via [namecost.azurewebsites.net](http://namecost.azurewebsites.net/)  
  
![Azure Resources](screenshots/AzureResources.png)  

## Azure Application Insights
Azure Application insight has been employed for the application in order to diagnose exceptions and application performance issues. It is used to monitor the application and automatically detect performance anomalies.  
  
![Performance](screenshots/AiPerformance.png)  
  
![Health](screenshots/AiHealth.png)  
  
The custom logging mechanism of the application is also based on the Application Insights and collects traces, exceptions, and all the application events of various severities and sends to Azure Application Insights.  
  
![Logs](screenshots/AiLog.png)  
  
## REST API
A RESTful API layer is provided for the client applications to consume and use conversion facilities.
Asp.Net WebApi 2.0 is used for the implementation and the API is available on an Azure API App  [namecost.azurewebsites.net](http://namecost.azurewebsites.net/) and ready to be consumed.  
  
Swashbuckle swagger is enabled for the API for easier use and having a simple documentation on API.  
  
  ![Swagger](screenshots/Swagger.png)  
  
Application insight features are also available on this layer and trace and diagnostic data are actively being sent to Azure Application Insight resource.

## Unit Tests
A number of unit tests are prepared for each project of the application. Unit tests for each project are organized in a separate project. MSTest is the test framework used and FluentAssertions and Moq are the assertion and mocking frameworks. It is tried to show different examples, while the coverage can be improved.  
A naming convention as _Method_Condition_ExpectedBahavior_ is utilized for naming unit tests.  
  
  ![UnitTests](screenshots/UnitTests.png)   
  
## Solution Structure
  1. __NameCost.Core__: Common facilities, which is limited to models for now, are stored in this project.  
  1. __NameCost.UI__: This is an MVC application serving as the UI of the project.  
  1. __NameCost.UI.Tests__: unit tests of the UI project.  
  1. __NameCost.WebApi__: API of the application which is not used by any other layer and is ready to be consumed in any front end client.  
  1. __NameCost.WebApi.Tests__: unit tests of the API project.  
  1. __NameCost.Logic__: this layer contains the url service, responsible for the business logic of the application.  
  1. __NameCost.Logic.Tests__: unit tests of the logic layer.   
      
  ![Structure](screenshots/SolutionStructure.png)  
  
## Acknowledgements
  I am willing to extend my gratitude to those who initiated this urge in me to start working on this project.  
  I hope the high respect I have for my product is demonstrated through this project.
