pipeline {
    agent any 
    stages {
        stage ('clone') {
            steps {
                git branch: 'main', url: 'https://github.com/DuVanSang/QLTV1.git'
            }
        }

        stage('restore package') {
            steps {
                echo 'Restore package'
                bat 'dotnet restore'
            }
        }

        stage ('build') {
            steps {
                echo 'build project netcore'
                bat 'dotnet build  --configuration Release'
            }
        }

        stage ('tests') {
            steps {
                echo 'running test...'
                bat 'dotnet test --no-build --verbosity normal'
            }
        }

        stage ('public den t thu muc') {
            steps {
                echo 'Publishing...'
                bat 'dotnet publish -c Release -o ./publish'
            }
        }

        stage ('Publish') {
            steps {
                echo 'public 2 running folder'
                //iisreset /stop // stop iis de ghi de file 
                bat 'xcopy "%WORKSPACE%\\publish" /E /Y /I /R "D:\\QLTV1"'
            }
        }

        stage('Deploy to IIS') {
            steps {
                powershell '''
                # Tạo website nếu chưa có
                Import-Module WebAdministration
                if (-not (Test-Path IIS:\\Sites\\QLTV1)) {
                    New-Website -Name "QLTV1" -Port 88 -PhysicalPath "D:\\QLTV1"
                }
                '''
            }
        }
    }
}
