<template>
  <nav class="header_img navbar navbar-expand-sm navbar-dark px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column">
        <h1 class="mdi mdi-liquor text-light"></h1>
      </div>
    </router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse justify-content-end" id="navbarText">

      <!-- LOGIN COMPONENT HERE -->
      <!-- <div>
        <button class="btn text-light" @click="toggleTheme"><i class="mdi"
            :class="theme == 'light' ? 'mdi-weather-sunny' : 'mdi-weather-night'"></i></button>
      </div> -->
      <div>
        <form @submit.prevent="searchRecipes()" class="d-flex me-2">
          <input v-model="editable" type="text" class="form-control" id="recipes">
          <button type="submit w-10" class="btn btn-success">Search</button>
        </form>
      </div>
      <Login />
    </div>
  </nav>
</template>

<script>
import { computed, onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
import { AppState } from '../AppState';
import { recipesService } from '../services/RecipesService';
import Pop from '../utils/Pop';
export default {
  setup() {

    const theme = ref(loadState('theme') || 'light')
    const editable = ref('')

    onMounted(() => {
      document.documentElement.setAttribute('data-bs-theme', theme.value)
    })

    return {
      theme,
      editable,
      recipes: computed(() => AppState.recipes),


      toggleTheme() {
        theme.value = theme.value == 'light' ? 'dark' : 'light'
        document.documentElement.setAttribute('data-bs-theme', theme.value)
        saveState('theme', theme.value)
      },

      async searchRecipes() {
        try {
          // if (search.value == '') {
          //   getRecipes()
          //   return
          const query = editable.value
          await recipesService.searchRecipes(query)
        }

        catch (error) {
          Pop.error(error)
        }


      },
    }
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}

.header_img {
  height: 15vh;
  background-size: cover;
  border-bottom-left-radius: 15px;
  border-bottom-right-radius: 15px;
  background-position: center;
  background-image: url(https://i0.wp.com/www.faithanddoubt.com/wp-content/uploads/hossein-farahani-pqJ21tErTgI-unsplash-edited-scaled.jpg?fit=2560%2C1437&ssl=1);
}
</style>
