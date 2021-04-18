<template>
    <div id="column">
        <h1 class="h1">Cards</h1>
        <div class="main">
            <ul>
                <li v-for="card in cards" :key="card">
                    {{ card.name }}
                    <Card :card="card" />
                </li>
            </ul>
        </div>
    </div>
</template>

<style lang="scss">
.main {
    display: flex;
    align-items: center;
    justify-content: center;
}
</style>

<script>
import api from "@/CardAPIService";
import Card from "../components/Card";
export default {
    data() {
        return {
            cards: [],
        };
    },
    async created() {
        this.cards = await api.getAll(this.columnId);
    },
    components: {
        Card,
    },
    props: {
        columnId: Number,
    },
};
</script>
