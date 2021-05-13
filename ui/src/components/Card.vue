<template>
    <div class="glasspane" @click="close">
        <div class="card-modal" @click.stop v-if="card !== null">
            <h1 class="h1">
                <form @submit.prevent="onSubmit" v-if="editing">
                    <input
                        type="text"
                        id="card-name"
                        name="edit-card-name"
                        autocomplete="off"
                        v-model.lazy.trim="card.name"
                    />
                    <button class="cancel-button" @click="onCancel" />
                    <button class="ok-button" type="submit" />
                </form>
                <span v-else>
                    {{ card.name }}
                    <button class="edit-button" @click="onEdit" />
                </span>
            </h1>
            <p>{{ card.description }}</p>
        </div>
    </div>
</template>

<style lang="scss">
.glasspane {
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: rgba(0, 0, 0, 0.7);
    display: flex;
    justify-content: center;
    align-items: center;
}
.card-modal {
    h1 {
        background-color: rgb(46, 137, 255);
        margin: 0;
        padding: 0.6em;
        color: white;
        height: 1.3em;
    }
    p {
        background-color: rgb(158, 194, 241);
        margin: 0;
        padding: 3em;
        color: black;
    }

    button {
        height: 2em;
        width: 2em;
        margin-left: 0.3em;
        background-color: inherit;
        border: 0;
    }

    form {
        display: inline;
    }
    .cancel-button {
        background-image: url("/icons/cancel-white.svg");
    }
    .ok-button {
        background-image: url("/icons/ok-white.svg");
    }
    .edit-button {
        background-image: url("/icons/edit-white.svg");
    }
}
</style>

<script>
import api from "../APIClient/CardAPIService.js";
export default {
    data() {
        return {
            card: null,
            editing: false,
        };
    },
    async created() {
        this.fetchData();
    },
    watch: {
        $route: "fetchData",
    },
    methods: {
        async fetchData() {
            this.card = await api.get(this.$route.params.cardId);
        },
        close() {
            this.$router.push({
                name: "board",
                params: { boardId: this.$route.params.boardId },
            });
        },
        onEdit() {
            this.editing = true;
        },
        async onCancel() {
            this.editing = false;
            await this.fetchData();
        },
        async onSubmit() {
            await api.update(this.$route.params.cardId, {
                name: this.card.name,
                description: this.card.description,
            });
            this.$emit("card-edited");
            await this.fetchData();
            this.editing = false;
        },
    },
};
</script>
