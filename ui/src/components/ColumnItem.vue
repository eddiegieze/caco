<template>
    <div @mouseover="hover = true" @mouseleave="hover = false">
        <router-link :to="linkTo">
            {{ itemName }}
        </router-link>
        <span v-if="hover && editable">
            <button class="edit-button" @click.prevent="onEdit" />
            <button class="delete-button" @click.prevent="onDelete" />
        </span>
    </div>
</template>

<style></style>

<script>
export default {
    data() {
        return {
            hover: false,
        };
    },
    props: {
        linkTo: Object,
        itemName: String,
        itemId: Number,
        editable: {
            type: Boolean,
            default: true,
        },
    },
    methods: {
        onDelete() {
            this.$emit("item-deleted", this.itemId);
        },
    },
};
</script>
