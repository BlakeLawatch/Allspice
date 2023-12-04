import { AppState } from "../AppState"
import { Favorite } from "../models/Favorite"
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

    async favoriteRecipe(recipeId) {
        const res = await api.post(`api/favorites`, { recipeId })
        AppState.favorites.push(new Favorite(res.data))

        // logger.log('Created a favorite!?!?! FINISH IN THE SERVICE', res.data)
    }

    async unFavoriteRecipe(favoriteId) {
        const res = await api.delete(`api/favorites/${favoriteId}`)
        logger.log('unfavorited this recipe? FINISH IN THE SERVICE', res.data)
    }

    async createInstruction(instructionData, instructionId) {
        const res = await api.put(`api/recipes/${instructionId}`, instructionData)
        const newRecipe = new Recipe(res.data)
        AppState.activeRecipe = newRecipe
        const recipeIndex = AppState.recipes.findIndex(recipe => recipe.id == instructionId)
        if (recipeIndex == -1) {
            throw new Error('no recipe with this ID')
        }
        AppState.recipes.splice(recipeIndex, 1, newRecipe)
        logger.log('created instructions FINISH IN THE SERVICE', res.data)
    }
}

export const recipesService = new RecipesService()