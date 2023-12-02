<template>
    <div class="modal fade" id="createRecipe" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-success">
                    <h1 class="modal-title fs-4 text-light" id="exampleModalLabel">New Recipe</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="d-flex justify-content-between">
                            <div class="mb-3 text-start">
                                <label for="title" class="form-label">Title</label>
                                <input type="text" class="form-control" id="title" required>
                            </div>
                            <div class="mb-3 text-start">
                                <label for="exampleInputPassword1" class="form-label">Category</label>
                                <input type="password" class="form-control" id="exampleInputPassword1">
                            </div>

                        </div>
                        <div class="mb-3 text-start">
                            <label for="exampleInputPassword1" class="form-label">Image URL</label>
                            <input type="password" class="form-control" id="exampleInputPassword1">
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>
</template>


<script>

export default {
    setup() {
        return {}
    }
};
</script>


<style lang="scss" scoped></style>