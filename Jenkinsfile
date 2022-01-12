
pipeline {
    agent any
    stages {
        stage('build docker') {
            steps {
              echo 'build docker'
              dir('samples\\aspnetapp') {
                bat 'docker build --pull -t ignaciocolmenares/aspnetapp:nanoserver -f Dockerfile.nanoserver-x64 .'
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
    }
}
