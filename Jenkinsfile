pipeline {
    agent any
	parameters {
	       string(name : 'GIT_HTTPS_PATH', defaultValue: 'https://github.com/tavisca-rgupta-2019/DemoWebApi.git')
	       string(name : 'SOLUTION_FILE_PATH', defaultValue: 'WebApplication1.sln')
               string(name : 'TEST_PROJECT_PATH', defaultValue: 'WebApi.Test/WebApi.Test.csproj')
               string(name : 'PROJECT_FILE_PATH', defaultValue: 'WebApplication1/WebApi.csproj')
	       string(name : 'SOLUTION_DLL_FILE', defaultValue: 'WebApi.dll')
	       string(name : 'DOCKERHUB_USERNAME', defaultValue: 'rohit1998')
	       string(name : 'BUILD_VERSION', defaultValue: '1.0')
	       string(name : 'PROJECT_NAME', defaultValue: 'demowebapi')
	       string(name : 'DOCKERHUB_PASSWORD', defaultValue: 'rohit1998password')
	       choice(name: 'RELEASE_ENVIRONMENT', choices: ['Build', 'Test','Publish'], description: 'Pick something')
	       
            }
	stages {
		stage('Build') {

	
             when{ anyOf{expression {params.RELEASE_ENVIRONMENT=='Build'};expression {params.RELEASE_ENVIRONMENT=='Test'};expression {params.RELEASE_ENVIRONMENT=='Publish'}} 
	      }
		
			steps {
				
		    powershell'''
				dotnet restore ${SOLUTION_FILE_PATH} --source https://api.nuget.org/v3/index.json
				dotnet build ${SOLUTION_FILE_PATH} -p:Configuration=release -v:n
                              '''
			 }
			}
                stage('Test') {
			
             when{ expression {params.RELEASE_ENVIRONMENT=='Test'}
		}
		
			steps {
		       powershell'''
				
				dotnet test ${TEST_PROJECT_PATH}
				
				'''
			    }
                         }
               stage('Publish') {
	      when{ expression {params.RELEASE_ENVIRONMENT=='Publish'}
             }
		      steps {
		      powershell'''
			     dotnet publish ${PROJECT_FILE_PATH} -p:Configuration=release -v:n
			    '''
                        }
               }
	    
	    stage('Preparing_Docker_Image') {
	     when{ expression {params.RELEASE_ENVIRONMENT=='Publish'}
            }
		steps {
			
				
					     powershell "docker build --tag=${PROJECT_NAME}:${BUILD_NUMBER}"
					     powershell "docker login --username=${DOCKERHUB_USERNAME} --password=${DOCKERHUB_PASSWORD}"
				             
					      powershell "docker tag ${PROJECT_NAME}:${BUILD_VERSION} rohit1998/${PROJECT_NAME}:${BUILD_NUMBER}"
                                              powershell "docker push rohit1998/${PROJECT_NAME}:${BUILD_NUMBER}"
			 
				
				
				
                               
			       
			}
	       }
	   }
	 post{
		always{
			deleteDir()
		}
	  }
	
  
	
}



