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
                    :itemId="card.id"
                    @item-deleted="deleteCard"
                    @item-edited="editCardName"
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
import columnApi from "../APIClient/ColumnAPIService.js";
import cardApi from "../APIClient/CardAPIService.js";
import InlineAdd from "./InlineAdd.vue";
import ColumnItem from "./ColumnItem.vue";
export default {
    data() {
        return {
            cards: [],
        };
    },
    async created() {
        this.cards = await columnApi.getCards(this.columnId);
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
            await columnApi.createCard(this.columnId, { name: cardName });
            this.cards = await columnApi.getCards(this.columnId);
        },
        async editCard() {
            this.cards = await columnApi.getCards(this.columnId);
        },
        async editCardName(cardId, cardName) {
            var card = this.cards.find((card) => card.id == cardId);
            card.name = cardName;
            await cardApi.update(cardId, card);
            this.cards = await columnApi.getCards(this.columnId);
        },
        async deleteCard(cardId) {
            await cardApi.delete(cardId);
            this.cards = await columnApi.getCards(this.columnId);
        },
    },
};
</script>
