<template>
    <form @submit.prevent="onSubmit" v-if="editing" v-on-clickaway="onCancel">
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
    <div
        @mouseover="hover = true"
        @mouseleave="hover = false"
        v-else
        class="ud-buttons-container"
    >
        <slot></slot>
        <div v-if="hover && editable" class="ud-buttons">
            <button class="edit-button" @click.prevent="onEdit" />
            <button class="delete-button" @click.prevent="onDelete" />
        </div>
    </div>
</template>

<style>
.ud-buttons {
    grid-area: 1 / 3 / 1 / 4;
    padding-top: 0;
}

.ud-content {
    grid-area: 1 / 1 / 1 / 4;
}

.ud-buttons-container {
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    grid-template-rows: 1fr;
    grid-column-gap: 0px;
    grid-row-gap: 0px;
}
</style>

<script>
import { mixin as clickaway } from "vue-clickaway";
export default {
    data() {
        return {
            hover: false,
            editing: false,
            name: this.itemName,
        };
    },
    mixins: [clickaway],
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
