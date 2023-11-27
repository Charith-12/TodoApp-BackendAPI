## To Build the API:

### 1. Clone the Repository:

Run the following command to clone the repository:

`git clone https://github.com/Charith-12/TodoApp-BackendAPI.git`


### 2. Navigate to the Project Folder:

`cd TodoApp-BackendAPI`

### 3. Build the Project:

Build the project using the following command:

`dotnet build`

### 4. Run the .NET Web API:

Run the project with:

`dotnet run`

The API will be hosted, and you should see output indicating the URL where it's running (typically http://localhost:5000).

### 5. Test the API:

Navigate to `http://localhost:7089/api/todo` to test the API. (the PORT could be vary e.g.:- 5000)

________________________________________________________________________________________________________________________________

## API Details

### GET

1. All Todos:

Request URL: `https://localhost:7089/api/Todo`

Example response to the GET request:

```
[
  {
    "todoId": 1,
    "title": "string",
    "description": "string",
    "isCompleted": true,
    "createdAt": "2023-11-27T13:35:15.097Z"
  }
]
```

2. A specific Todo:

Request URL: `https://localhost:7089/api/Todo/{id}`

Example response to the GET request:

```
{
  "todoId": 2,
  "title": "Fly",
  "description": "planes",
  "isCompleted": false,
  "createdAt": "2023-11-25T11:08:35.7375166"
}
```




### POST

Request URL: `https://localhost:7089/api/Todo`

Expected POST request body example:

```
{
  "title": "todo title: max 1000 characters",
  "description": "description: max 5000 characters",
  "isCompleted": false
}
```

 The "title" field is mandatory. Also, you could provide only the title. In such cases, the "description" becomes "" and "isCompleted" becomes "false" by default.

 "todoId" and "createdAt" attributes are getting auto-assigned by the server.


Expected response body example:
```
{
  "todoId": 21,
  "title": "todo title",
  "description": "description",
  "isCompleted": false,
  "createdAt": "2023-11-27T19:37:35.993849+05:30"
}
```



### PUT

Request URL: `https://localhost:7089/api/Todo/{id}`

Expected request body example:
```
{
  "todoId": 21,
  "title": "new title",
  "description": "new description",
  "isCompleted": true
}
```

The response indicating the successful update: 204 No Content.

Invalid "todoId" returns 404 Not Found.




### DELETE

Request URL: `https://localhost:7089/api/Todo/{id}`

The response indicating the successful deletion: 204 No Content.

Invalid "todoId" returns 404 Not Found.




### SQLite Database Schema

```
{
todoId	integer($int32)
title*	string
        maxLength: 1000
description	string
                maxLength: 5000
                nullable: true
isCompleted	boolean
createdAt	string($date-time)
}
```





