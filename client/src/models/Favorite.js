export class Favorite {
    constructor(data) {
        this.id = data.id
        this.recipeId = data.recipeId
        this.accountId = data.accountId
        this.title = data.title
        this.instructions = data.instructions
        this.img = data.img
        this.category = data.category
        this.creatorId = data.creatorId
        this.creator = data.creator
    }
}

const favorite = {
    "recipeId": 3,
    "accountId": "6541827fc58db642d7c02476",
    "id": 15,
    "createdAt": "2023-12-04T01:21:17",
    "updatedAt": "2023-12-04T01:21:17",
    "title": null,
    "instructions": null,
    "img": null,
    "category": null,
    "creatorId": null,
    "creator": null
}