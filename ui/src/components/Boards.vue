<template>
    <div id="dashboard">
        <h1 class="h1">Boards</h1>
        <div class="main">
            <ul id="example-1">
                <li v-for="board in boards" :key="board">
                    {{ board.name }} ({{ board.id }})
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
import api from "@/BoardAPIService";
export default {
    data() {
        return {
            boards: [],
        };
    },
    async created() {
        this.boards = await api.getAll();
    },
};
</script>
