export class Recipe {
    constructor(data) {
        this.id = data.id
        this.createdAt = new Date(data.createdAt)
        this.updatedAt = new Date(data.updatedAt)
        this.title = data.title
        this.instructions = data.instructions
        this.img = data.img
        this.category = data.category
        this.creatorId = data.creatorId
        this.creator = data.creator

    }
}

const recipe = {
    "id": 4,
    "createdAt": "2023-11-30T04:20:40",
    "updatedAt": "2023-11-30T04:20:40",
    "title": "The Senior Jake Burrito",
    "instructions": "Take your burrito and cook it, then add hotdog.  Boom, Burrito.",
    "img": "https://images.unsplash.com/photo-1584031036380-3fb6f2d51880?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=900&q=80",
    "category": "Mexican",
    "creatorId": "6541827fc58db642d7c02476",
    "creator": {
        "id": "6541827fc58db642d7c02476",
        "name": "anothernewemail@new.email",
        "email": "anothernewemail@new.email",
        "picture": "https://s.gravatar.com/avatar/87d93fa56cfb84f69fde33613bc552ea?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fan.png"
    }
}