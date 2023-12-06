import { AppState } from "../AppState"
import { Favorite } from "../models/Favorite"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class FavoritesService {


    async favoriteRecipe(recipeId) {
        const res = await api.post(`api/favorites`, { recipeId })
        AppState.myFavorites.push(new Favorite(res.data))
        this.getMyFavorites()

        // logger.log('Created a favorite!?!?! FINISH IN THE SERVICE', res.data)
    }

    async unFavoriteRecipe(favoriteId) {
        const res = await api.delete(`api/favorites/${favoriteId}`)
        AppState.favorites.splice(0, 1)
        this.getMyFavorites()

        // logger.log('unfavorited this recipe? FINISH IN THE SERVICE', AppState.favorites)
    }

    async getMyFavorites() {
        const res = await api.get(`account/favorites`)
        AppState.myFavorites = res.data.map(pojo => new Favorite(pojo))
        // logger.log('got favorites FINISH IN THE SERVICE', AppState.myFavorites)
    }
}

export const favoritesService = new FavoritesService()