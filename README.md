### Links

[App](dev-techtest-app.azurewebsites.net) 

[cd.yml](https://github.com/ishmaelshr/TechTest/actions/workflows/cd.yml) \
[ci.yml](https://github.com/ishmaelshr/TechTest/actions/workflows/ci.yml) \
[infra.yml](https://github.com/ishmaelshr/TechTest/actions/workflows/infra.yml)

# Production Environment 

The technical exercise has been split into two different branches. The dev branch deploys the dev environment for the exercise. To set up the environment please run the infra.yml GitHub action. The ci.yml which builds the artifact runs on pushes/pull request, hence the latest arifact has been already build. Run the cd.yml GitHub action to deploy it to the infrastructure. 

Please note: 
- Only 1 environment can be running at the same time since the app runs on the AWS Free tier.
- For more read the README.md in the prod branch