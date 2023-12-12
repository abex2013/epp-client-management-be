pipeline{
    agent
    {
     docker
        {
         image 'mcr.microsoft.com/dotnet/sdk:5.0'
          args '-u root:root'
        }
    }
    stages
    { 
        stage('Git checkout')
        {
            steps{
              git credentialsId: 'bitbucketpw', url: 'https://bitbucket.org/Excellerent_Solutions/excellerent-epp-be'
        
            }
        }
        stage('Dotnet build')
        {
            steps{
               sh 'dotnet build' 
            }
        }
        stage('Dotnet test')
        {
            steps{
              sh 'dotnet test'  
            }
        }
        stage('Deploy to Staging')
        {
            when {
                expression  {
                    BRANCH_NAME == master
                }
            }
            steps{
              sh 'docker build -t eppbe .'  
              sh 'docker run -d -p 3000:3000 eppbe --name eppbe'
            }
        }