<template>
    <div id="column">
        <div class="main">
            <ul>
                <li v-for="card in cards" :key="card.id">
                    {{ card.name }}
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
export default {
    data() {
        return {
            cards: [],
        };
    },
    async created() {
        this.cards = await api.getAll(this.columnId);
    },
    props: {
        columnId: Number,
    },
};
</script>
