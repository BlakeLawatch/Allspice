import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipesService {


    async getRecipes() {
        const res = await api.get('api/recipes')
        AppState.recipes = res.data.map(pojo => new Recipe(pojo))
        // logger.log('got recipes FINISH IN THE SERVICE', AppState.recipes)
    }

    setActiveRecipe(recipe) {
        AppState.activeRecipe = recipe
    }

    async createRecipe(formData) {
        const res = await api.post(`api/recipes`, formData)
        logger.log('created a recipe FINISH IN THE SERVICE', res.data)
    }

    searchRecipes(search) {
        if (search) {
            const foundRecipes = AppState.recipes.filter(recipe => recipe.category == search)
            logger.log(foundRecipes, 'found recipes')
        } else {
            this.getRecipes()
            return AppState.recipes
        }
    }
}

export const recipesService = new RecipesService()