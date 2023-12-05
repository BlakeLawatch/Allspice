<template>
    <div @click="setActiveRecipe()" class="selectable col-12 p-2 recipe_cardImg" :title="recipe.title"
        data-bs-toggle="modal" data-bs-target="#recipeModal">
        <div class="row justify-content-end text-end my-4">
            <!-- NOTE fix the conditional render -->
            <p v-if="favorite && account.id == recipe.creatorId" @click="createFavorite()"
                class="col-2 mdi mdi-heart-outline fs-2 bg_card"></p>
            <p v-else @click="unFavoriteRecipe()" class="col-2 mdi mdi-heart fs-2 bg_card"></p>

        </div>
        <div class="text-light bg_card rounded-pill text-center mx-4">
            <p>{{ recipe.title }}</p>
            <p>{{ recipe.category }}</p>
        </div>
    </div>
    <div>
    </div>
</template>


<script>

import { computed } from 'vue';
import { Recipe } from '../models/Recipe';
import { AppState } from '../AppState';
import RecipeModal from './RecipeModal.vue';
import { recipesService } from '../services/RecipesService';
import { favoritesService } from '../services/FavoritesService';
import Pop from '../utils/Pop';


export default {
    props: { recipe: { type: Recipe, required: true } },
    setup(props) {
        return {
            account: computed(() => AppState.account),
            recipes: computed(() => AppState.recipes),
            activeRecipe: computed(() => AppState.activeRecipe),
            coverImg: computed(() => `url(${props.recipe.img})`),
            favorite: computed(() => AppState.myFavorites.find(recipe => recipe.id == myFavorites.recipeId)),



            setActiveRecipe() {
                recipesService.setActiveRecipe(props.recipe)
            },

            async createFavorite() {
                try {
                    const recipeId = props.recipe.id
                    await favoritesService.favoriteRecipe(recipeId)
                } catch (error) {
                    Pop.error(error)
                }
            },

            async unFavoriteRecipe() {
                try {
                    const recipeId = props.recipe.id
                    await favoritesService.unFavoriteRecipe(favoriteId)
                } catch (error) {
                    Pop.error(error)
                }
            }

        };
    },
    components: { RecipeModal }
};
</script>


<style lang="scss" scoped>
.recipe_cardImg {
    background-image: v-bind(coverImg);
    background-position: center;
    background-size: cover;
}

.bg_card {

    backdrop-filter: blur(15px);

}
</style>