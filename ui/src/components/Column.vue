<template>
    <div id="column">
        <div class="main">
            <ul>
                <li v-for="card in cards" :key="card.id">
                    <router-link
                        :to="{
                            name: 'card',
                            params: { cardId: card.id },
                        }"
                    >
                        {{ card.name }}
                    </router-link>
                </li>
                <li><CardFormSimpleAdd @card-added="addCard" /></li>
                <li><router-view></router-view></li>
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
    },
};
</script>
