<template>
  <div class="container-fluid">
    <section class="row">
      <div class="text-center my-3">
        <button @click="changeRecipeType('')" class="rounded-pill mx-1">All</button>
        <button @click="changeRecipeType(recipeType)" class="rounded-pill mx-1" v-for="recipeType in recipeTypes"
          :key="recipeType">
          {{ recipeType }}
        </button>
      </div>
      <div v-for="filter in filters" :key="filter">
        <button @click="changeFilterType(filter)">{{ filter }}</button>

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
import { computed, onMounted, ref, watch, watchEffect } from 'vue';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService.js'
import { logger } from '../utils/Logger';
import RecipeComponent from '../components/RecipeComponent.vue';



export default {
  setup() {
    const filters = ["Home", "My Favorites", "My Recipes"]
    const recipeTypes = ["Cheese", "Specialty Coffee", "Soup", "Mexican", "Italian"];
    const filteredRecipeTypes = ref('');
    const search = ref('');

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
      filters,
      account: computed(() => AppState.account),
      // recipes: computed(() => AppState.recipes),
      recipes: computed(() => {
        if (filteredRecipeTypes.value) {
          return AppState.recipes.filter(pojo => pojo.category == filteredRecipeTypes.value);
        }
        else {
          return AppState.recipes;
        }
      }),
      types: computed(() => {
        if (recipeFilter == favorites) {
          return AppState.myFavorites
        }
      }
      ),

      changeFilterType(filter) {
        recipesService.changeFilterType(filter)
      },

      changeRecipeType(recipeType) {
        // logger.log('this is the recipe type', recipeType);
        filteredRecipeTypes.value = recipeType;
      },
    };
  },
  components: { RecipeComponent }
}
</script>

<style scoped lang="scss">
.shadow {
  box-shadow: 2px 2px 10px gray;
}
</style>
