
pipeline {
    agent any
    stages {
        stage('build docker') {
            steps {
              echo 'build docker'
              dir('samples\\aspnetapp') {
                powershell 'cp c:\\examples\\* aspnetapp\\' 
                bat 'docker build --pull -t ignaciocolmenares/aspnetapp:nanoserver -f Dockerfile.nanoserver-x64 .'
                powershell 'git stash' 
              }                
            }
        }
        stage('publish docker image') {
            steps {
                echo 'publish docker image'
                withCredentials([string(credentialsId: 'ignacioDockerHubPassword', variable: 'ignacioDockerHubPassword')]) {
                    bat "docker login -u ignaciocolmenares -p %ignacioDockerHubPassword% "
                    bat 'docker push ignaciocolmenares/aspnetapp:nanoserver'
                }
            }
        }
        stage('pull docker image') {
            steps{
                bat 'docker pull ignaciocolmenares/aspnetapp:nanoserver'
            }
        }
        stage('Stop && remove container AspnetApp in stage') {
            steps {
                catchError(buildResult: 'SUCCESS'){
                    bat 'docker stop aspnetapp_ignacio'
                    bat 'docker rm aspnetapp_ignacio'
                }
            }
        }
        stage('Start container AspnetApp in stage') {
            steps {
                bat 'docker run -d -p 8080:80 --name aspnetapp_ignacio ignaciocolmenares/aspnetapp:nanoserver'
            }
        }
        stage('clean dangling images') {
            steps {
                catchError(buildResult: 'SUCCESS'){
                    powershell  "docker rmi \$(docker images -f \"dangling=true\" -q)"
                }
            }
        }        
    }
}
