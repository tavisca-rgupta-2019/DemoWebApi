pipeline {
    agent any
	parameters {
	       string(name : 'GIT_HTTPS_PATH', defaultValue: 'https://github.com/tavisca-rgupta-2019/DemoWebApi.git')
	       string(name : 'SOLUTION_FILE_PATH', defaultValue: 'WebApplication1.sln')
               string(name : 'TEST_PROJECT_PATH', defaultValue: 'WebApi.Test/WebApi.Test.csproj')
	       choice(name: 'RELEASE_ENVIRONMENT', choices: ['Build', 'Test'], description: 'Pick something')
            }
	stages {
             when{ params.RELEASE_ENVIRONMENT=='Build' 
	      }
		stage('Build') {
			steps {
				
			     sh'''
				dotnet restore ${SOLUTION_FILE_PATH} --source https://api.nuget.org/v3/index.json
				dotnet build ${SOLUTION_FILE_PATH} -p:Configuration=release -v:n
                              '''
			 }
			}
             when{ params.RELEASE_ENVIRONMENT=='Test'
		}
		 stage('Test') {
			steps {
		              sh'''
				dotnet test ${TEST_PROJECT_PATH}
				
				'''
			    }
			   }	
              }
  
	posts {
	   success{
		 sh "deleteDir()"

                   }
               }
}



