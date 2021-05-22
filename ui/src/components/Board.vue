<template>
    <div class="main">
        <Boards />
        <div v-for="column in columns" :key="column.id" class="column">
            {{ column.name }}
            <Column :columnId="column.id" />
        </div>
        <div id="add-column" class="column">
            <ul>
                <li>
                    <InlineAdd @item-added="addColumn" />
                </li>
            </ul>
        </div>
    </div>
</template>

<style lang="scss">
.main {
    display: flex;
    align-items: stretch;
    justify-content: flex-start;
    height: calc(100% - 5em);
    div {
        border-radius: 0.3em;
    }
}

#add-column {
    height: 4.3em;
}
</style>

<script>
import api from "../APIClient/BoardAPIService.js";
import Column from "./Column.vue";
import Boards from "./Boards.vue";
import InlineAdd from "./InlineAdd.vue";
export default {
    data() {
        return {
            columns: [],
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
            this.columns = await api.getColumns(this.$route.params.boardId);
        },
        async addColumn(columnName) {
            await api.createColumn(this.$route.params.boardId, {
                name: columnName,
            });
            this.fetchData();
        },
    },
    components: {
        Column,
        Boards,
        InlineAdd,
    },
};
</script>
