<template>
    <div class="col-12 p-2">
        <img class="img-fluid shadow" :src="recipe.img" alt="" :title="recipe.title">
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


export default {
    props: { recipe: { type: Recipe, required: true } },
    setup() {
        return {
            recipes: computed(() => AppState.recipes)
        }
    }
};
</script>


<style lang="scss" scoped>
.shadow {
    box-shadow: 2px 2px 10px gray;
}
</style>