<template>
    <div class="glasspane" @click="close">
        <form @submit.prevent="onSubmit">
            <div class="card-modal" @click.stop v-if="card !== null">
                <h1 class="h1">
                    <input
                        type="text"
                        name="card-name"
                        autocomplete="off"
                        v-model.lazy.trim="card.name"
                        v-if="editing"
                    />
                    <span v-else>
                        {{ card.name }}
                    </span>
                    <div class="button-bar" v-if="editing">
                        <button class="ok-button" type="submit" />
                        <button
                            class="cancel-button"
                            @click.prevent="onCancel"
                        />
                    </div>
                    <div class="button-bar" v-else>
                        <button
                            class="delete-button"
                            @click.prevent="onDelete"
                        />
                        <button class="edit-button" @click.prevent="onEdit" />
                    </div>
                </h1>
                <div class="card-contents">
                    <textarea
                        autocomplete="off"
                        v-model.lazy.trim="card.description"
                        v-if="editing"
                    ></textarea>
                    <p v-else>{{ card.description }}</p>
                </div>
            </div>
        </form>
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
    width: 60vw;
    height: 70vh;
    display: flex;
    flex-direction: column;
    h1 {
        background-color: rgb(46, 137, 255);
        margin: 0;
        padding: 0.6em;
        color: white;
        height: 1.3em;
        display: flex;

        span,
        input {
            flex-grow: 1;
            text-align: left;
            padding: 0;
        }

        input {
            padding-top: 0.18em;
        }

        span {
            border: 0.05em solid;
            border-color: rgb(46, 137, 255);
        }
    }

    button {
        height: 2em;
        width: 2em;
        margin-left: 0.3em;
        background-color: inherit;
        border: 0;
        cursor: pointer;
    }

    input,
    textarea {
        background-color: inherit;
        color: inherit;
        font: inherit;
        border: 0.05em solid black;
    }

    textarea {
        resize: none;
        width: 99%;
        height: 98%;
    }

    p {
        margin: 0.22em 0 0 0.15em;
    }

    .card-contents {
        background-color: rgb(158, 194, 241);
        margin: 0;
        padding: 1em;
        text-align: left;
        color: black;
        border-radius: 0;
        flex-grow: 1;

        p {
            white-space: pre-line;
        }
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
    .delete-button {
        background-image: url("/icons/delete-white.svg");
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
        async onDelete() {
            if (confirm("Are you sure?")) {
                await api.delete(this.$route.params.cardId);
                this.$emit("card-edited");
                this.close();
            }
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
