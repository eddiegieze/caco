<template>
    <div id="column">
        <div class="main">
            <ul>
                <li v-for="card in cards" :key="card.id">
                    {{ card.name }}
                </li>
                <li><CardFormSimpleAdd @card-added="addCard" /></li>
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
import api from "../APIClient/CardAPIService.js";
import CardFormSimpleAdd from "./CardFormSimpleAdd.vue";
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
    components: {
        CardFormSimpleAdd,
    },
    methods: {
        async addCard(cardName) {
            await api.create(this.columnId, { name: cardName });
            this.cards = await api.getAll(this.columnId);
        },
    },
};
</script>
