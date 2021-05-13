<template>
    <div class="card">
        <h1 class="h1">{{ card.name }}</h1>
        <p>{{ card.description }}</p>
    </div>
</template>

<style lang="scss"></style>

<script>
import api from "../APIClient/CardAPIService.js";
export default {
    data() {
        return {
            card: {},
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
    },
};
</script>
