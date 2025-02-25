# CS-3502-Project
CS 3502 Project 1 Multi Threaded Banking System
# Overview
This Project contains 4 different Programs coded in C# via Visual Studio. The Scenario chosen was a Banking System where people are the threads depositing or withdrawing money. The Linux subsystem Ubuntu was used to run the code.
# Instructions
Although I have provided the entire project, to run the code using Ubuntu you only need the "Program.cs" files for the lines of code, the order of which goes Basic Thread Protection, Resource Protection, Deadlock Creation, Deadlock Resolution. After creating an Ubuntu account or logging in, you need to run some commands to install .Net SDK

# Run the following commands to add the Microsoft package repository:

wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb                                    
sudo dpkg -i packages-microsoft-prod.deb                                                                         
rm packages-microsoft-prod.deb

# Update Package List:

sudo apt update

# Install .NET SDK:

sudo apt install -y dotnet-sdk-6.0

# Verify the Installation:

dotnet --version

# Next Create directory for the project:

mkdir BankingProject            
cd BankingProject

# Run the following command to create a new .NET console project:

dotnet new console

(This will generate a Program.cs file and a .csproj file.)

# Replace the Default Code:

nano Program.cs

(You can also go into your linux folders and edit the Progam.cs from there, edit it with my code)

# To run the code:

dotnet build

(Then)

dotnet run
