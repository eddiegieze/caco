<template>
    <div class="glasspane" @click="close">
        <form @submit.prevent="onSubmit">
            <div class="card-modal" @click.stop v-if="card !== null">
                <h1 class="h1">
                    <input
                        type="text"
                        name="card-name"
                        ref="cardName"
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
    background-color: rgba(0, 0, 0, 0.35);
    display: flex;
    justify-content: center;
    align-items: center;
    z-index: 99;
}
.card-modal {
    width: 60vw;
    height: 70vh;
    display: flex;
    flex-direction: column;
    box-shadow: 3px 3px 5px #000;
    h1 {
        background-color: rgb(46, 137, 255);
        margin: 0;
        padding: 0.6em;
        color: white;
        height: 1.4em;
        min-height: 1.4em;
        display: flex;
        border-radius: 0.3em 0.3em 0 0;

        span,
        input {
            flex-grow: 1;
            text-align: left;
            padding: 0;
        }

        span {
            border: 0.05em solid;
            border-color: rgb(46, 137, 255);
            overflow: hidden;
            text-overflow: ellipsis;
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
        border-radius: 0em 0em 0.3em 0.3em;
        flex-grow: 1;
        max-height: 30em;
        overflow: auto;

        p {
            white-space: pre-line;
        }
    }

    form {
        display: inline;
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
            try {
                this.card = await api.get(this.$route.params.cardId);
            } catch (err) {
                alert("Error: " + err.response.status);
                this.$router.push({
                    name: "board",
                    params: { boardId: this.$route.params.boardId },
                });
            }
        },
        close() {
            this.$router.push({
                name: "board",
                params: { boardId: this.$route.params.boardId },
            });
        },
        onEdit() {
            this.editing = true;
            this.$nextTick(() => {
                var input = this.$refs.cardName;
                // @ts-ignore
                input.focus();
                // @ts-ignore
                input.select();
            });
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
            try {
                await api.update(this.$route.params.cardId, {
                    name: this.card.name,
                    description: this.card.description,
                });
                this.$emit("card-edited");
            } catch (err) {
                alert("Failed to update card.");
            }
            await this.fetchData();
            this.editing = false;
        },
    },
};
</script>
