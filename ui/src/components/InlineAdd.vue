<template>
    <div class="inline-add">
        <form
            @submit.prevent="onSubmit"
            v-if="editing"
            v-on-clickaway="onCancel"
        >
            <input
                type="text"
                name="new-item"
                ref="newInput"
                autocomplete="off"
                v-model.lazy.trim="name"
            />
            <button class="ok-button" type="submit" />
            <button class="cancel-button" @click.prevent="onCancel" />
        </form>
        <button class="add-button" @click.prevent="onAdd" v-else />
    </div>
</template>

<style>
.inline-add {
    display: flex;
    align-items: center;
    justify-content: center;
}

button {
    height: 2em;
    width: 2em;
    margin-left: 0.3em;
    background-color: inherit;
    border: 0;
    cursor: pointer;
    position: relative;
    top: -0.4em;
}

input {
    width: 10em;
}

input,
textarea {
    background-color: inherit;
    color: inherit;
    font: inherit;
    border: 0.05em solid white;
}
</style>

<script>
import { mixin as clickaway } from "vue-clickaway";
export default {
    data() {
        return {
            name: "",
            editing: false,
        };
    },
    mixins: [clickaway],
    methods: {
        onSubmit() {
            if (this.name !== "") this.$emit("item-added", this.name);
            this.name = "";
            this.editing = false;
        },
        onAdd() {
            this.editing = true;
            this.$nextTick(() => {
                // @ts-ignore
                this.$refs.newInput.focus();
            });
        },
        onCancel() {
            this.editing = false;
        },
    },
};
</script>
