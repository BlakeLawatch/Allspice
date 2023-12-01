export class Ingredient {
    constructor(data) {
        this.id = data.id
        this.name = data.name
        this.quantity = data.quantity
        this.recipeId = data.recipeId
        this.creatorId = data.creatorId
        this.creator = data.creator
    }
}

const ingredients = {
    "id": 3,
    "name": "Potato",
    "quantity": "1/2 Cup",
    "recipeId": 68,
    "creatorId": "6541827fc58db642d7c02476",
    "creator": {
        "id": "6541827fc58db642d7c02476",
        "name": "anothernewemail@new.email",
        "email": "anothernewemail@new.email",
        "picture": "https://s.gravatar.com/avatar/87d93fa56cfb84f69fde33613bc552ea?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fan.png"
    }
}