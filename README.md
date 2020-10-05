# WPF Caliburn NTier Sample
Sample WPF project using Caliburn.Micro MVVM framework with .Net 4.7.2



I had a job interview with an **Abroad company** recently and this sample is the result of the **Coding Test session**


- Key factors about this project

  - MVVM design pattern with messaging between View Models
  - IOC : Simple Container
  - Loosely coupled High cohesion
  - Pagination to handle loading of high volume of data 
  - Generic classes for reusability
  - Entity framework Code First with migration
  - Separation of Concerns with putting each component in related class and related classes into layers presented by projects in the solution

  

- Note: This project is created in a very limited time for my coding test session for the company that was trying to assess my coding skills, so in regards of these keys this project is architected and structured:

  - Time management to end the task completely

  - To have least technical debt

  - Keep code simple while not loosing the impression that I wanted to have on the reviewers team

  - Keep focus on code style instead of focusing on UI (It much more interests me to have a working project instead of not working beauty! in other words Having a 2007 Nissan Sentra with an engine running is more appealing to me than having a Lamborghini with a broken engine! )

    

- Project Specs:
	- Framework: .Net 4.7.2
	- Caliburn.Micro MVVM framework 3.2.0
	- Entity Framework 6.4.4
- Project Creation Environment:
	- IDE: Visual Studio 2019 Community edition
	- OS: Windows 10

- To run project:
	- Open the project in IDE
	- Restore Nuget
	- Set your SqlServer data server name in app.config in connection string in PresentationLayer project (replace "SqlServerInstanceName")
	-- Note: You can use command update-database to create database without data or download database backup file from "https://bit.ly/3ir8H2t" and after extracting it restore the database backup in MS SqlServer to have database and sample data
	- Restore database
	- Run the project

