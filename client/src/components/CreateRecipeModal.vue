<template>
    <div class="modal fade" id="createRecipe" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-success">
                    <h1 class="modal-title fs-4 text-light" id="exampleModalLabel">New Recipe</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="createRecipe()">
                        <div class="d-flex justify-content-between">
                            <div class="mb-3 text-start">
                                <label for="title" class="form-label">Title</label>
                                <input v-model="editable.title" type="text" class="form-control" id="title" required
                                    maxlength="225">
                            </div>
                            <div class="mb-3 text-start">
                                <label for="category" class="form-label">Category</label>
                                <select v-model="editable.category" id="category" class="form-select">
                                    <option :value="recipeType" v-for="recipeType in recipeTypes" :key="recipeType">{{
                                        recipeType }}</option>
                                </select>
                            </div>
                        </div>
                        <div class="mb-3 text-start">
                            <label for="img" class="form-label">Image URL</label>
                            <input v-model="editable.img" type="url" class="form-control" id="img" required>
                        </div>
                        <div class="mb-3 text-start">
                            <label for="instructions" class="form-label">Instructions </label>
                            <input v-model="editable.instructions" type="text" class="form-control" id="instructions"
                                required>
                        </div>

                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="submit" class="btn btn-primary">Save changes</button>
                    </form>
                </div>


            </div>
        </div>
    </div>
</template>


<script>

import { Modal } from 'bootstrap';
import { recipesService } from '../services/RecipesService';
import Pop from '../utils/Pop';
import { ref } from 'vue';



export default {
    setup() {
        const recipeTypes = ["Cheese", "Specialty Coffee", "Soup", "Mexican", "Italian"]
        const editable = ref({})
        return {
            recipeTypes,
            editable,

            async createRecipe() {
                try {
                    const formData = editable.value
                    recipesService.createRecipe(formData)
                    Pop.success('You created a recipe')
                    editable.value = {}
                    Modal.getOrCreateInstance('#createRecipe').hide()
                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    }
};
</script>


<style lang="scss" scoped></style>