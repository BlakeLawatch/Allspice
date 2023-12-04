<template>
    <div class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <section v-if="activeRecipe" class="row">

                    <div class="col-4">
                        <img class="img-fluid" :src="activeRecipe.img" alt="">
                    </div>
                    <div class="col-4 p-3">
                        <h3>{{ activeRecipe.title }}</h3>
                        <p>{{ activeRecipe.instructions }}</p>
                    </div>
                    <div class="col-4">
                        <div v-for="ingredient in ingredients" :key="ingredient.id">
                            <h4>{{ ingredient.quantity }} {{ ingredient.name }} </h4>
                            <p @click="destroyIngredient(ingredient.id)"><i class="mdi mdi-delete-empty"></i></p>
                        </div>

                    </div>

                    <div class="col-6">
                        <form @submit.prevent="createInstruction()">
                            <div class="mb-3 text-start">
                                <label for="instructions" class="form-label">Add Instructions</label>
                                <input v-model="editable.instructions" type="text" class="form-control" id="instructions"
                                    required>
                                <button type="submit" class="btn btn-success">+</button>
                            </div>
                        </form>
                    </div>
                    <div class="col-6">
                        <form @submit.prevent="addIngredients()">
                            <div class="mb-3 text-start">
                                <label for="quantity" class="form-label">Add quantity</label>
                                <input v-model="editableIngredients.quantity" type="text" class="form-control" id="quantity"
                                    required>
                            </div>
                            <div class="mb-3 text-start">
                                <label for="name" class="form-label">Add Ingredients</label>
                                <input v-model="editableIngredients.name" type="text" class="form-control" id="name"
                                    required>
                            </div>
                            <button type="submit" class="btn btn-success">+</button>
                        </form>

                    </div>
                    <div class="col-12">

                        <button v-if="account.id == activeRecipe.creatorId" @click="destroyRecipe(activeRecipe.id)">
                            {{ activeRecipe.id }}<i class="mdi mdi-delete-empty fs-1"></i></button>

                    </div>

                </section>
            </div>
        </div>
    </div>
</template>


<script>
import { computed, ref, watchEffect } from 'vue';
import { ingredientsService } from '../services/IngredientsService.js'
import Pop from '../utils/Pop';
import { AppState } from '../AppState';

import { recipesService } from '../services/RecipesService';
import { router } from '../router';
import { useRouter } from 'vue-router';




export default {
    setup() {
        const editable = ref({})
        const editableIngredients = ref({})
        const router = useRouter()


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
            editable,
            editableIngredients,
            router,
            account: computed(() => AppState.account),
            activeRecipe: computed(() => AppState.activeRecipe),
            ingredients: computed(() => AppState.ingredients),

            async createInstruction() {
                try {
                    const instructionData = editable.value;
                    // const instructionId = instructionData.recipeId
                    // instructionId = AppState.activeRecipe.id
                    instructionData.recipeId = AppState.activeRecipe.id
                    await recipesService.createInstruction(instructionData, instructionData.recipeId)
                    editable.value = {}

                } catch (error) {
                    Pop.error(error)
                }

            },

            async addIngredients() {
                const ingredientData = editableIngredients.value
                ingredientData.recipeId = AppState.activeRecipe.id
                await ingredientsService.addIngredients(ingredientData, ingredientData.recipeId)
                editableIngredients.value = {}
            },

            async destroyIngredient(ingredientId) {
                try {
                    const wantToDelete = await Pop.confirm("You sure about that?")
                    if (!wantToDelete) {
                        return
                    }
                    await ingredientsService.destroyIngredient(ingredientId)
                } catch (error) {
                    Pop.error(error)
                }
            },

            async destroyRecipe(recipeId) {
                try {
                    const wantToDelete = await Pop.confirm("You sure about that?")
                    if (!wantToDelete) {
                        return
                    }
                    await recipesService.destroyRecipe(recipeId)
                    router.push({ name: 'HomePage' })
                } catch (error) {
                    Pop.error(error)
                }
            }

        };

    }
};
</script>


<style lang="scss" scoped></style>