<template>
  <div class="container-fluid">
    <section class="row">
      <!-- <div class="col-12 header-img">
        <img class="img-fluid"
          src="https://images.unsplash.com/photo-1501430654243-c934cec2e1c0?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
          alt="">
      </div> -->
      <div>

      </div>
    </section>

    <section class="row">
      <div class="col-4 " v-for="recipe in recipes" :key="recipe.id">
        <RecipeComponent :recipe="recipe" />
      </div>
    </section>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService.js'


export default {
  setup() {
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
      recipes: computed(() => AppState.recipes)
    };
  },
}
</script>

<style scoped lang="scss">
.header_img {
  max-height: .1rem;
  width: .1rem;
  object-fit: contain;
  object-position: center;

}
</style>
