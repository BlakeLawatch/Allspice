import { api } from "./AxiosService"
import { logger } from "../utils/Logger"
import { AppState } from "../AppState"
import { Ingredient } from "../models/Ingredient"

class IngredientsService {

    async getIngredientsByRecipeId(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        // logger.log('Got ingredients FINISH IN THE SERVICE', res.data)
        AppState.ingredients = res.data.map(pojo => new Ingredient(pojo))
        // logger.log('Got ingredients FINISH IN THE SERVICE', AppState.ingredients)
    }

    async addIngredients(ingredientData, recipeId) {
        const res = await api.post(`api/ingredients`, ingredientData)
        const newIngredient = new Ingredient(res.data)
        AppState.ingredients.push(newIngredient)
        AppState.activeRecipe = newIngredient
        return newIngredient

    }

    async destroyIngredient(ingredientId) {
        const res = await api.delete(`api/ingredients/${ingredientId}`)
        const index = AppState.ingredients.findIndex(ingredient => ingredient.id == ingredientId)
        AppState.ingredients.splice(index, 1)
        // logger.log('deleted ingredient FINISH IN THE SERVICE', res.data)

    }
}

export const ingredientsService = new IngredientsService()