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
				
		     sh'''
				dotnet C:/sonar/SonarScanner.MSBuild.dll begin /k:"WebApiDeployment" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="fb475cd759a65a4ca1beaf013807ee97cf18d222"

				dotnet restore ${SOLUTION_FILE_PATH} --source https://api.nuget.org/v3/index.json
				dotnet build ${SOLUTION_FILE_PATH} -p:Configuration=release -v:n
                              '''
			 }
			}
                stage('Test') {
			
             when{ expression {params.RELEASE_ENVIRONMENT=='Test'}
		}
		
			steps {
		       sh'''
				
				dotnet test ${TEST_PROJECT_PATH}
				
				'''
			    }
                         }
               stage('Publish') {
	      when{ expression {params.RELEASE_ENVIRONMENT=='Publish' }
             }
		      steps {
		      sh'''
			     dotnet C:/sonar/SonarScanner.MSBuild.dll end /d:sonar.login="fb475cd759a65a4ca1beaf013807ee97cf18d222"
			     dotnet publish ${PROJECT_FILE_PATH} -p:Configuration=release -v:n
			    '''
                        }
               }
	    
	    stage('Preparing_Docker_Image') {
	     when{ expression {params.RELEASE_ENVIRONMENT=='Publish'}
            }
		steps {
			
				
					     sh "docker build --tag=${PROJECT_NAME}:${BUILD_NUMBER} ."
					     sh "docker login --username=${DOCKERHUB_USERNAME} --password=${DOCKERHUB_PASSWORD}"
				             
					      sh "docker tag ${PROJECT_NAME}:${BUILD_VERSION} rohit1998/${PROJECT_NAME}:${BUILD_NUMBER}"
                                              sh "docker push rohit1998/${PROJECT_NAME}:${BUILD_NUMBER}"
			sh "docker run -d -p 5000:80 ${PROJECT_NAME}:${BUILD_NUMBER}"
			 
				
				
				
                               
			       
			}
	       }
	   }
	
	
  
	
}



