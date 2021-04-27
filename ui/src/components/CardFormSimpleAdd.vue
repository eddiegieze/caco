<template>
    <form @submit.prevent="onSubmit">
        <input
            type="text"
            id="add-card-input"
            name="new-card"
            autocomplete="off"
            v-model.lazy.trim="name"
        />
        <button type="submit">Add</button>
    </form>
</template>

<script>
export default {
    data() {
        return {
            name: "",
        };
    },
    methods: {
        onSubmit() {
            if (this.name !== "") this.$emit("card-added", this.name);
            this.name = "";
        },
    },
};
</script>
