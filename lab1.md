# Login into Sonarqube and Import a project from AzDo

## Step 1: Login into sonarqube

1. Go to: `https://sonarqube.startsml.com`
2. Login with your email account, and the password will be shared.

## Step 2: Import DevOps Organization here

1. Click on `Import From Azure DevOps`.
2. It will prompt you for AzDo token which will be shared.
3. Choose `hitachi-developers` project and then select your repo.
4. Click import
5. Select `Follows the instance’s default` and then `Create Project`

## Step 3: Start Analysis

1. Go to your imported repository
2. Choose `Locally` for analysis method.
3. Click `Generate a project token`, keep it safe.
4. Run analysis on your project -> `.NET` -> `.NET Core`
5. Copy the commands given by the Sonarqube
6. Run `dotnet tool install --global dotnet-sonarscanner` as instructed by the SonarQube.

# Step 3: Install Java

```bash
sudo apt update
sudo apt install openjdk-jre-headless
```
## Step 5: Create some code and check with sonarqube

1. Clone the Repo from the devops organization: `Git Clone <URL>`
2. Change to that repo `cd <REPO NAME>`
3. Init a blank project `dotnet new console -n MyFirstDotNetApp`.
4. Chage to that project `cd MyFirstDotNetApp`
5. Run the SonarQube Executor ` /d:verbose=true /d:sonar.scanner.skipJreProvisioning=true` has been added to the command.
```bash
dotnet sonarscanner begin /k:"<Your Project Key>" /d:sonar.host.url="https://sonarqube.startsml.com"  /d:sonar.token="<Your Token>"   /d:sonar.scanner.skipJreProvisioning=true /d:verbose=true
```
This will take time.
6. Build the project `dotnet build`
7. Send report to SonarQube `dotnet sonarscanner end /d:sonar.token="<Your Token>"`

## Step 6: Find the Changes in the SonarQube server