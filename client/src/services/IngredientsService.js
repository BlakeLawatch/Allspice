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
}

export const ingredientsService = new IngredientsService()