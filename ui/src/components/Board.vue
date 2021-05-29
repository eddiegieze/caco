<template>
    <div class="workspace">
        <Boards />
        <div v-for="column in columns" :key="column.id" class="column">
            <InlineEdit
                :itemName="column.name"
                :itemId="column.id"
                @item-deleted="deleteColumn"
                @item-edited="editColumnName"
            >
                <h1>{{ column.name }}</h1>
            </InlineEdit>
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
.workspace {
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
import boardApi from "../APIClient/BoardAPIService.js";
import columnApi from "../APIClient/ColumnAPIService.js";
import Column from "./Column.vue";
import Boards from "./Boards.vue";
import InlineAdd from "./InlineAdd.vue";
import InlineEdit from "./InlineEdit.vue";
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
            this.columns = await boardApi.getColumns(
                this.$route.params.boardId
            );
        },
        async addColumn(columnName) {
            await boardApi.createColumn(this.$route.params.boardId, {
                name: columnName,
            });
            this.fetchData();
        },
        async editColumnName(columnId, columnName) {
            await columnApi.update(columnId, { name: columnName });
            this.fetchData();
        },
        async deleteColumn(columnId) {
            await columnApi.delete(columnId);
            this.fetchData();
        },
    },
    components: {
        Column,
        Boards,
        InlineAdd,
        InlineEdit,
    },
};
</script>
