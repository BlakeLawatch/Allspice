<template>
    <div class="modal fade" id="editAccountModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Edit Account</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="editAccount()">
                        <div class="mb-3">
                            <label for="name" class="form-label">Name</label>
                            <input v-model="editable.name" type="text" class="form-control" id="name">
                        </div>
                        <div class="mb-3">
                            <label for="email" class="form-label">Email</label>
                            <input v-model="editable.email" type="email" class="form-control" id="email">
                        </div>
                        <div class="mb-3">
                            <label for="picture" class="form-label">Image URL</label>
                            <input v-model="editable.picture" type="url" class="form-control" id="picture">
                        </div>
                        <div class="justify-content-around d-flex">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <button type="submit" class="btn btn-primary">Save changes</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { computed, ref } from 'vue';
import { accountService } from '../services/AccountService';
import { Modal } from 'bootstrap';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';

export default {
    setup() {
        const editable = ref({})
        // account: computed(() => AppState.account)
        return {
            editable,


            async editAccount() {
                try {
                    const accountId = AppState.account.id
                    const accountData = editable.value
                    accountService.editAccount(accountId, accountData)
                    editable.value = {}
                    Modal.getOrCreateInstance('#editAccountModal').hide()

                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    }
};
</script>


<style lang="scss" scoped></style>