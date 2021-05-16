<template>
    <div>
        <form @submit.prevent="onSubmit" v-if="editing">
            <input
                type="text"
                name="new-card"
                ref="newCardInput"
                autocomplete="off"
                v-model.lazy.trim="name"
            />
            <button class="ok-button" type="submit" />
        </form>
        <button class="add-button" @click.prevent="onAdd" v-else />
    </div>
</template>

<style>
.add-button {
    background-image: url("/icons/add-white.svg");
}

.ok-button {
    background-image: url("/icons/ok-white.svg");
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

input,
textarea {
    background-color: inherit;
    color: inherit;
    font: inherit;
    border: 0.05em solid white;
}
</style>

<script>
export default {
    data() {
        return {
            name: "",
            editing: false,
        };
    },
    methods: {
        onSubmit() {
            if (this.name !== "") this.$emit("card-added", this.name);
            this.name = "";
            this.editing = false;
        },
        onAdd() {
            this.editing = true;
            this.$nextTick(() => {
                // @ts-ignore
                this.$refs.newCardInput.focus();
            });
        },
    },
};
</script>
