### Links


[App](prod-techtest-app.azurewebsites.net)

[cd.yml](https://github.com/ishmaelshr/TechTest/actions/workflows/cd.yml) \
[ci.yml](https://github.com/ishmaelshr/TechTest/actions/workflows/ci.yml) \
[infra.yml](https://github.com/ishmaelshr/TechTest/actions/workflows/infra.yml)

# Production Environment 

The technical exercise has been split into two different branches. The production branch deploys the production environment for the exercise. To set up the environment please run the infra.yml GitHub action. The ci.yml which builds the artifact runs on pushes/pull request, hence the latest arifact has been already build. Run the cd.yml GitHub action to deploy it to the infrastructure.

Please note: 
- Only 1 environment can be running at the same time since the app runs on the AWS Free tier.

# Technical notes

## About the environment

The environment has been set up using GitHub environments. This allows for the Github Action (CI/CD) to deploy the infrastructure under different names. Normally, the repository would have 1 main branch, which would deploy to multiple environments but for simplicity I have create two branches to deploy to DEV and PROD.

## CI/CD pipelines

The CI pipelines builds, test and publishes the project. The published folder is saved in an artifact of the GIthub Action. The CD pipelines takes the CI Artifact and deploys it. Currently, the infrastructure deployment (infra.yml) is separate in its own Github Action because a terraform backend hasn’t been set for the project, hence the infrastructure needs to be taken down for re-deployment. To refelect this the CD pipleines runs only manually.

## Tools

- Github Action: CI/CD
- ASP.NET: Web App
- Terraform: Infrastructure
- Azure (Web App): Cloud Proivder

## Completed tasks

1.	Filters Section (Standard)
2.	User Model Properties (Standard)
3.	Actions Section (Standard)
4.	Data Logging (Advanced)
Missing* : In the Logs page, think about how you can provide a good user experience - even when there are many log entries.
5.	Future-Proof the Application (Platform)
Missing* : Introduce a message bus and/or worker to handle long-running operations.


