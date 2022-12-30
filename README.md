# Welcome to ChatApp...

--- Steps to run this project ---
1. Clone the project (main branch) 
2. Restore the .bak file in the ChatApp.Database folder to your local SQL server. 
3. Open the ChatApp.API solution using Visual Studio 2019 and run the API (You will have to change the connection string with your restored DB name). 
4. Open the ChatApp.Client folder using VS code. 
5. run 'npm install' command in vs code terminal. 
6. use the command 'ng s' to run client project. (I have used Agular 7) 
7. Now you will see Welcome screen. You should create a new user in order to join to the chat room.

Note: There is only one chat room in the DB and you cannot add new chat rooms so far and that functionality will be available with the upcomming releases. So please use "pt room" as the chat room when you login. You can use "chamila" as a default user.
