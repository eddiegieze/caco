<template>
    <div id="board">
        <h1 class="h1">Columns</h1>
        <div class="main">
            <ul>
                <li v-for="column in columns" :key="column">
                    {{ column.name }}
                    <Column :columnId="column.id" />
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
import api from "@/ColumnAPIService";
import Column from "../components/Column";
export default {
    data() {
        return {
            columns: [],
        };
    },
    async created() {
        this.columns = await api.getAll(this.$route.params.boardId);
    },
    components: {
        Column,
    },
};
</script>
