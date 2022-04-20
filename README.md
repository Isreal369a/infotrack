# InfoTrack 

This solution contains three projects:
1.  **WebApi**  - .Net core Web Api 
2. **UnitTests**  - Unit tests of the Web api 
3. **Frontend**  - React UI where users can enter a url and keywords



## Work done vs Future work
1.  API implemented. Can scrape **Google** search result and return url positioning
2. Validate user input: Url and keyword cant be empty
3. Use Dependency injection and tried to be SOLID
4. Unit test 
5. Dokerize web api

## Future work
1. Add more tests
2. Clean up UI page. i.e. dont hard code API endpoing
3. Unit test UI

# Running the solution

1. Navigate to the WebApi folder and run the following command
```cmd
cd {REPO}/WebApi
dotnet run WebApi
```
Go to: https://localhost:5001/swagger/index.html

2. Navigate to the Frontend Folder and run the following command
```cmd
cd {REPO}/Frontend
npm install
npm start
```
Go to: https://localhost:3000