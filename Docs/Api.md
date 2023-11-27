# API

## Auth

### Register

#### Register request

```
POST {{host}}/api/auth/register
```

```json
{
    "name": "Cyril Morozov",
    "email": "cyril@morozov.com",
    "password": "Cyril123"
}
```

#### Register response

```js
200 OK
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Cyril Morozov",
    "email": "cyril@morozov.com",
    "token": "asds...as234k",
}
```

### Login

#### Login request

```
POST {{host}}/api/auth/login
```

```json
{
    "email": "cyril@morozov.com",
    "password": "Cyril123"
}
```

#### Login response

```js
200 OK
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Cyril Morozov",
    "email": "cyril@morozov.com",
    "token": "asds...as234k",
}
```

## Posts

### Create post

#### Create post request

```
POST {{host}}/api/posts
Authorization: Bearer {{token}}
```

```json
{
    "title": "Title",
    "description" "Description"
}
```

#### Create post response

```js
200 OK
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000"
}
```

### Delete post

#### Delete post request

```
DELETE {{host}}/api/posts/00000000-0000-0000-0000-000000000000
Authorization: Bearer {{token}}
```

#### Delete post response

```js
200 OK
```

### Edit post

#### Edit post request

```
PUT {{host}}/api/posts/00000000-0000-0000-0000-000000000000
Authorization: Bearer {{token}}
```

#### Edit post response

```js
200 OK
```

### Get post by id

#### Get post by id request

```
GET {{host}}/api/posts/00000000-0000-0000-0000-000000000000
```

#### Get post by id response

```js
200 OK
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "title": "Title",
    "description": "Description",
    "Date": "00/00/0000 00:00"
}
```

### Get posts

#### Get posts request

```
GET {{host}}/api/posts
```

#### Get posts response

```js
200 OK
```

```json
[
    {
        "id": "00000000-0000-0000-0000-000000000000",
        "title": "Title",
        "description": "Description",
        "Date": "00/00/0000 00:00"
    }
]
```