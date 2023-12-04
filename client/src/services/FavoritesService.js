import { AppState } from "../AppState"
import { Favorite } from "../models/Favorite"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class FavoritesService {


    async favoriteRecipe(recipeId) {
        const res = await api.post(`api/favorites`, { recipeId })
        AppState.favorites.push(new Favorite(res.data))

        // logger.log('Created a favorite!?!?! FINISH IN THE SERVICE', res.data)
    }

    async unFavoriteRecipe(favoriteId) {
        const res = await api.delete(`api/favorites/${favoriteId}`)
        logger.log('unfavorited this recipe? FINISH IN THE SERVICE', res.data)
    }
}

export const favoritesService = new FavoritesService()