<template>
    <div class="card-list">
        <ul>
            <li v-for="card in cards" :key="card.id">
                <ColumnItem
                    :linkTo="{
                        name: 'card',
                        params: { cardId: card.id },
                    }"
                    :itemName="card.name"
                />
            </li>
            <li><InlineAdd @item-added="addCard" /></li>
            <router-view @card-edited="editCard"></router-view>
        </ul>
    </div>
</template>

<style lang="scss">
.card-list {
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
import InlineAdd from "./InlineAdd.vue";
import ColumnItem from "./ColumnItem.vue";
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
        InlineAdd,
        ColumnItem,
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
