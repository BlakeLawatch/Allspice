<template>
    <div @click="setActiveRecipe()" class="col-12 p-2" data-bs-toggle="modal" data-bs-target="#recipeModal">
        <img class="img-fluid" :src="recipe.img" alt="" :title="recipe.title">
        <div>
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


export default {
    props: { recipe: { type: Recipe, required: true } },
    setup(props) {
        return {
            recipes: computed(() => AppState.recipes),
            activeRecipe: computed(() => AppState.activeRecipe),


            setActiveRecipe() {
                recipesService.setActiveRecipe(props.recipe)
            }

        };
    },
    components: { RecipeModal }
};
</script>


<style lang="scss" scoped></style>