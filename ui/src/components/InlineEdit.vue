<template>
    <form @submit.prevent="onSubmit" v-if="editing">
        <input
            type="text"
            name="edit-name"
            ref="nameInput"
            autocomplete="off"
            v-model.lazy.trim="name"
        />
        <button class="ok-button" type="submit" />
        <button class="cancel-button" @click.prevent="onCancel" />
    </form>
    <div @mouseover="hover = true" @mouseleave="hover = false" v-else>
        <slot></slot>
        <span v-if="hover && editable" class="ud-buttons">
            <button class="edit-button" @click.prevent="onEdit" />
            <button class="delete-button" @click.prevent="onDelete" />
        </span>
    </div>
</template>

<style>
.ud-buttons {
    position: absolute;
    margin-left: 0.8em;
}
</style>

<script>
export default {
    data() {
        return {
            hover: false,
            editing: false,
            name: this.itemName,
        };
    },
    props: {
        itemName: String,
        itemId: Number,
        editable: {
            type: Boolean,
            default: true,
        },
    },
    methods: {
        onDelete() {
            if (confirm("Are you sure?")) {
                this.$emit("item-deleted", this.itemId);
            }
        },
        onEdit() {
            this.editing = true;
            this.$nextTick(() => {
                // @ts-ignore
                this.$refs.nameInput.focus();
            });
        },
        onCancel() {
            this.editing = false;
        },
        onSubmit() {
            if (this.name !== "") {
                this.$emit("item-edited", this.itemId, this.name);
            }
            this.editing = false;
        },
    },
};
</script>
