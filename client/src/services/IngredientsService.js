import { api } from "./AxiosService"
import { logger } from "../utils/Logger"

class IngredientsService {

    async getIngredientsByRecipeId(recipeId) {
        const res = await api.get(`api/recipes/{recipeId}/ingredients`)
        logger.log('Got ingredients FINISH IN THE SERVICE', res.data)
    }
}

export const ingredientsService = new IngredientsService()