# CLI Command Reference API (ASP.NET Core MVC)

## Introduction
This API serves as a convenient resource for recalling various CLI commands. It stores command line snippets, each with a brief description and platform specification, facilitating easy recollection of frequently used or complex commands.

## Project Goals: Learning and Applying Key Concepts
The main objective of this project is to deepen understanding and apply practical skills in several areas, including:
- Developing a RESTful API
- Utilizing .NET Core framework
- Implementing the MVC (Model-View-Controller) architectural pattern
- Programming in C#

## Key Technologies and Practices Employed:
In building this project, I employed several essential development practices and technologies:
- Dependency injection
- Repository design pattern
- SQL Server Express & SSMS
- Entity Framework Core O/RM (DBContext, Migration)
- Data Transfer Objects (DTOs) & AutoMapper
- RESTful API guidelines
- HTTP (GET, POST, PUT, PATCH, DELETE, status codes)
- Testing API Endpoints (SwaggerUI & Postman)

## Application Architecture:
![image](https://github.com/Gravqc/.Net-Core-Rest-API/assets/90492971/53d0e071-e29d-42c1-a3f4-37af84944af8)


## Website Look:
<img width="941" alt="image" src="https://github.com/Gravqc/.Net-Core-Rest-API/assets/90492971/f8ae70ae-fad6-419a-915f-c6cab263d0d8">


## API Endpoints (CRUD):
![image](https://github.com/Gravqc/.Net-Core-Rest-API/assets/90492971/39f80c85-ae85-4e85-a6a5-da5cc076ff73)

## Usage Example:
### GET(api/commands{id}) (Swagger):
<img width="809" alt="image" src="https://github.com/Gravqc/.Net-Core-Rest-API/assets/90492971/dc23537b-dd8c-4a21-b7a4-cfa3011018d9">

## POST(api/commands/) (PostMan):
<img width="784" alt="image" src="https://github.com/Gravqc/.Net-Core-Rest-API/assets/90492971/c7ad9dba-9fa4-4974-87c1-09fb81e17c36">

## To Do:
### Docker Integration
- Containerization: Describes how the API is containerized using Docker, including the creation of a Dockerfile.
- Image Creation: Details on building Docker images for the API.
- Deployment on Docker Hub: Instructions for pushing the Docker image to Docker Hub for distribution.
### Microsoft Azure Deployment
- Deploying Docker Image: Steps to deploy the Dockerized API on Microsoft Azure.
- Azure SQL Database: Guidelines for setting up and connecting to an Azure SQL Database instance for the API.
- Configuration and Management: Information on configuring the deployment and managing the service in the Azure environment.
