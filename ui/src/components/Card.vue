<template>
    <div class="glasspane" @click="close">
        <div class="card-modal">
            <h1 class="h1">{{ card.name }}</h1>
            <p>{{ card.description }}</p>
        </div>
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
    h1 {
        background-color: rgb(46, 137, 255);
        margin: 0;
        padding: 0.6em;
        color: white;
        height: 1.3em;
    }
    p {
        background-color: rgb(158, 194, 241);
        margin: 0;
        padding: 3em;
        color: black;
    }
}
</style>

<script>
import api from "../APIClient/CardAPIService.js";
export default {
    data() {
        return {
            card: null,
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
    },
};
</script>
