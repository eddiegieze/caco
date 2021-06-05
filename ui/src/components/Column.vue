<template>
    <div class="card-list">
        <ul>
            <li v-for="card in cards" :key="card.id">
                <InlineEdit
                    :itemName="card.name"
                    :itemId="card.id"
                    @item-deleted="deleteCard"
                    @item-edited="editCardName"
                >
                    <router-link
                        :to="{
                            name: 'card',
                            params: { cardId: card.id },
                        }"
                        class="ud-content"
                    >
                        {{ card.name }}
                    </router-link>
                </InlineEdit>
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
import InlineEdit from "./InlineEdit.vue";
import InlineAdd from "./InlineAdd.vue";
export default {
    data() {
        return {
            cards: [],
        };
    },
    async created() {
        this.fetchData();
    },
    props: {
        columnId: Number,
    },
    components: {
        InlineEdit,
        InlineAdd,
    },
    methods: {
        async fetchData() {
            this.cards = await columnApi.getCards(this.columnId);
        },
        async addCard(cardName) {
            try {
                await columnApi.createCard(this.columnId, { name: cardName });
            } catch (err) {
                alert("Failed to update card.");
            }
            this.fetchData();
        },
        async editCard() {
            this.fetchData();
        },
        async editCardName(cardId, cardName) {
            var card = this.cards.find((card) => card.id == cardId);
            card.name = cardName;
            try {
                await cardApi.update(cardId, card);
            } catch (err) {
                alert("Failed to update card.");
            }
            this.fetchData();
        },
        async deleteCard(cardId) {
            await cardApi.delete(cardId);
            this.fetchData();
        },
    },
};
</script>
