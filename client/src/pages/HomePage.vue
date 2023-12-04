<template>
  <div class="container-fluid">
    <section class="row">

      <div class="col-12">
        <div class="header_img text-light d-flex justify-content-center align-items-center">
          <h1>Allspice</h1>
          <!-- <h2>Cherish your family and their cooking</h2> -->
        </div>
      </div>
      <div>
        <form @submit.prevent="searchRecipes()">
          <input v-model="search" class="form-control" type="search">
          <button type="submit" class="btn btn-success">Search</button>
        </form>
      </div>
      <div class="text-center">
        <button @click="changeRecipeType('')" class="rounded-pill mx-1">All</button>
        <button @click="changeRecipeType(recipeType)" class="rounded-pill mx-1" v-for="recipeType in recipeTypes"
          :key="recipeType">
          {{ recipeType }}
        </button>
      </div>
    </section>

    <section class="row d-flex justify-content-around">
      <div class="col-3 shadow m-2" v-for="recipe in recipes" :key="recipe.id">
        <RecipeComponent :recipe="recipe" />
      </div>
    </section>
    <section>
      <div class="col-12 text-end">
        <button class="rounded-circle btn btn-success fs-1 my-1" data-bs-toggle="modal"
          data-bs-target="#createRecipe">+</button>
        <CreateRecipeModal />
      </div>
    </section>
  </div>
</template>

<script>
import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService.js'
import { logger } from '../utils/Logger';



export default {
  setup() {
    const recipeTypes = ["Cheese", "Specialty Coffee", "Soup", "Mexican", "Italian"]
    const filteredRecipeTypes = ref('')
    const search = ref('')


    onMounted(() => {
      getRecipes();
    });
    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      }
      catch (error) {
        Pop.error(error);
      }
    }
    return {
      recipeTypes,
      search,
      account: computed(() => AppState.account),
      recipes: computed(() => {
        if (filteredRecipeTypes.value) {
          return AppState.recipes.filter(
            pojo => pojo.category == filteredRecipeTypes.value
          )
        } else {
          return AppState.recipes
        }
      }),

      async changeRecipeType(recipeType) {
        logger.log('this is the recipe type', recipeType)
        filteredRecipeTypes.value = recipeType
      },

      searchRecipes() {
        try {
          if (search.value == '') {
            getRecipes()
            return
          }

        } catch (error) {
          Pop.error(error)
        }


      },


    };


  },

}
</script>

<style scoped lang="scss">
.header_img {
  height: 35vh;
  background-size: cover;
  border-radius: 15px;
  background-position: center;
  background-image: url(https://images.unsplash.com/photo-1437252611977-07f74518abd7?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8d2hlYXR8ZW58MHx8MHx8fDA%3D);
}

.shadow {
  box-shadow: 2px 2px 10px gray;
}
</style>
