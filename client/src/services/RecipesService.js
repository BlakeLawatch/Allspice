import { AppState } from "../AppState"
import { Account } from "../models/Account"
import { Favorite } from "../models/Favorite"
import { Recipe } from "../models/Recipe"
import { router } from "../router"
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

    async destroyRecipe(recipeId) {
        const res = await api.delete(`api/recipes/${recipeId}`)
        const index = AppState.recipes.findIndex(recipe => recipe.id == recipeId)
        AppState.recipes.splice(index, 1)
        AppState.activeRecipe = null
        logger.log('destroyed recipe FINISH IN THE SERVICE', res.data)
    }

    async searchRecipes(query) {
        const res = await api.get(`api/recipes?query=${query}`)
        AppState.recipes = res.data.map(pojo => new Recipe(pojo))
        // logger.log('got search working FINISH IN THE SERVICE', AppState.recipes)

    }

    changeFilterType(filter) {
        if (filter == 'Home') {
            AppState.filteredRecipes = AppState.recipes
            logger.log('got home recipes', AppState.filteredRecipes)
        }
        if (filter == 'My Favorites') {
            AppState.filteredRecipes = AppState.myFavorites
            logger.log('got favorite recipes', AppState.filteredRecipes)
        }
        if (filter == 'My Recipes') {

            AppState.filteredRecipes = AppState.recipes.filter(recipe => recipe.creatorId == Account.id)
            logger.log('got my created recipes', AppState.filteredRecipes)
        }
    }
}

export const recipesService = new RecipesService()