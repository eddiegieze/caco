<template>
    <div id="dashboard">
        <h1 class="h1">Boards</h1>
        <div class="main">
            <ul class="boardlist">
                <li v-for="board in boards" :key="board">
                    <router-link
                        :to="{
                            name: 'board',
                            params: { boardId: board.id },
                        }"
                    >
                        {{ board.name }}
                    </router-link>
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
