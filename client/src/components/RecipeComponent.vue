<template>
    <div @click="setActiveRecipe()" class="col-12 p-2" data-bs-toggle="modal" data-bs-target="#recipeModal">
        <img class="img-fluid" :src="recipe.img" alt="" :title="recipe.title">
        <div>
            <p @click="createFavorite()" class="mdi mdi-heart-outline fs-2"></p>
            <p @click="unFavoriteRecipe()" class="mdi mdi-heart fs-2"></p>
            <p>{{ recipe.title }}</p>
            <p>{{ recipe.category }}</p>
        </div>
    </div>
</template>


<script>

import { computed } from 'vue';
import { Recipe } from '../models/Recipe';
import { AppState } from '../AppState';
import RecipeModal from './RecipeModal.vue';
import { recipesService } from '../services/RecipesService';
import Pop from '../utils/Pop';


export default {
    props: { recipe: { type: Recipe, required: true } },
    setup(props) {
        return {
            recipes: computed(() => AppState.recipes),
            activeRecipe: computed(() => AppState.activeRecipe),


            setActiveRecipe() {
                recipesService.setActiveRecipe(props.recipe)
            },

            async createFavorite() {
                try {
                    const recipeId = props.recipe.id
                    await recipesService.favoriteRecipe(recipeId)
                } catch (error) {
                    Pop.error(error)
                }
            },

            async unFavoriteRecipe() {
                try {
                    const recipeId = props.recipe.id
                    await recipesService.unFavoriteRecipe(recipeId)
                } catch (error) {
                    Pop.error(error)
                }
            }

        };
    },
    components: { RecipeModal }
};
</script>


<style lang="scss" scoped></style>