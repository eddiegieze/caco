<template>
    <div class="main">
        <ul>
            <li v-for="card in cards" :key="card.id">
                <div>
                    <router-link
                        :to="{
                            name: 'card',
                            params: { cardId: card.id },
                        }"
                    >
                        {{ card.name }}
                    </router-link>
                </div>
            </li>
            <li><CardFormSimpleAdd @card-added="addCard" /></li>
            <router-view @card-edited="editCard"></router-view>
        </ul>
    </div>
</template>

<style lang="scss">
.main {
    display: flex;
    align-items: center;
    justify-content: center;
}

.column {
    width: 15em;
}

ul {
    width: 100%;
}
</style>

<script>
import api from "../APIClient/ColumnAPIService.js";
import CardFormSimpleAdd from "./CardFormSimpleAdd.vue";
export default {
    data() {
        return {
            cards: [],
        };
    },
    async created() {
        this.cards = await api.getCards(this.columnId);
    },
    props: {
        columnId: Number,
    },
    components: {
        CardFormSimpleAdd,
    },
    methods: {
        async addCard(cardName) {
            await api.createCard(this.columnId, { name: cardName });
            this.cards = await api.getCards(this.columnId);
        },
        async editCard() {
            this.cards = await api.getCards(this.columnId);
        },
    },
};
</script>
