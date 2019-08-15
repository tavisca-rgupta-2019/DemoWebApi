pipeline {
    agent any
	parameters {
	       string(name : 'GIT_HTTPS_PATH', defaultValue: 'https://github.com/tavisca-rgupta-2019/DemoWebApi.git')
	       string(name : 'SOLUTION_FILE_PATH', defaultValue: 'WebApplication1.sln')
               string(name : 'TEST_PROJECT_PATH', defaultValue: 'WebApi.Test/WebApi.Test.csproj')
	       choice(name: 'RELEASE_ENVIRONMENT', choices: ['Build', 'Test'], description: 'Pick something')
            }
	stages {
		stage('Build') {

	
             when{ expression {params.RELEASE_ENVIRONMENT=='Build'} 
	      }
		
			steps {
				
			     powershell '''
				dotnet restore ${SOLUTION_FILE_PATH} --source https://api.nuget.org/v3/index.json
				dotnet build ${SOLUTION_FILE_PATH} -p:Configuration=release -v:n
                              '''
			 }
			}
                stage('Test') {
			
             when{ expression {params.RELEASE_ENVIRONMENT=='Test'}
		}
		
			steps {
		              powershell '''
				dotnet restore ${SOLUTION_FILE_PATH} --source https://api.nuget.org/v3/index.json
				dotnet build ${SOLUTION_FILE_PATH} -p:Configuration=release -v:n
				dotnet test ${TEST_PROJECT_PATH}
				
				'''
			    }
                         }
			   	
              }
	post {
	   success{
			
		powershell '''mkdir archive
                           '''
               
                   }
               }
  
	
}



