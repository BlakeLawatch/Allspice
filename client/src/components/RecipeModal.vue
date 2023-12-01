<template>
    <div class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Modal title</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div>
                    <img src="" alt="">
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { computed, onMounted } from 'vue';
import { ingredientsService } from '../services/IngredientsService.js'
import Pop from '../utils/Pop';
import { AppState } from '../AppState';


export default {
    setup() {
        onMounted(() => {

            // getIngredientByRecipeId()
        })
        // async function getIngredientByRecipeId() {
        //     try {
        //         // const recipeId = id
        //         await ingredientsService.getIngredientsByRecipeId(recipeId)

        //     } catch (error) {
        //         Pop.error(error)
        //     }
        // }
        return {
            activeRecipe: computed(() => AppState.activeRecipe)


        };

    }
};
</script>


<style lang="scss" scoped></style>