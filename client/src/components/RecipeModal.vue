<template>
    <div class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <section v-if="activeRecipe" class="row">
                    <div class="col-12 d-flex">
                        <div class="col-4">
                            <img class="img-fluid" :src="activeRecipe.img" alt="">
                        </div>
                        <div class="col-4 p-3">
                            <h3>{{ activeRecipe.title }}</h3>
                            <p>{{ activeRecipe.instructions }}</p>
                        </div>
                        <div v-for="ingredient in ingredients" :key="ingredient.id" class="col-4">
                            <div class="text-end">
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <h4>{{ ingredient.quantity }} {{ ingredient.name }}</h4>
                        </div>

                    </div>

                </section>
            </div>
        </div>
    </div>
</template>


<script>
import { computed, onMounted, watch, watchEffect } from 'vue';
import { ingredientsService } from '../services/IngredientsService.js'
import Pop from '../utils/Pop';
import { AppState } from '../AppState';



export default {
    setup() {

        watchEffect(() => {
            if (AppState.activeRecipe) {
                getIngredientByRecipeId()
            }
        })
        async function getIngredientByRecipeId() {
            try {

                const recipeId = AppState.activeRecipe.id
                await ingredientsService.getIngredientsByRecipeId(recipeId)

            } catch (error) {
                Pop.error(error)
            }
        }
        return {

            activeRecipe: computed(() => AppState.activeRecipe),
            ingredients: computed(() => AppState.ingredients)


        };

    }
};
</script>


<style lang="scss" scoped></style>