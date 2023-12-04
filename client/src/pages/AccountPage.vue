<template>
  <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div>
  <div class="col-12 text-center">
    <button class="btn btn-success w-90" data-bs-toggle="modal" data-bs-target="#editAccountModal">Edit Account</button>
  </div>
  <EditAccountModal />
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
import EditAccountModal from '../components/EditAccountModal.vue';
export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    };
  },
  components: { EditAccountModal }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
