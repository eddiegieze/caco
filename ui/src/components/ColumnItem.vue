<template>
    <div>
        <router-link :to="linkTo">
            {{ itemName }}
        </router-link>
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
    },
};
</script>
