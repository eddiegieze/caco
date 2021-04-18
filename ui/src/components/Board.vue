<template>
    <div class="main">
        <Boards />
        <div v-for="column in columns" :key="column.id">
            {{ column.name }}
            <Column :columnId="column.id" />
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
        border: solid 0.1em rgb(150, 148, 148);
        border-radius: 0.3em;
    }
}
</style>

<script>
import api from "@/ColumnAPIService";
import Column from "../components/Column";
import Boards from "../components/Boards";
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
            this.columns = await api.getAll(this.$route.params.boardId);
        },
    },
    components: {
        Column,
        Boards,
    },
};
</script>
