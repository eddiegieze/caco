<template>
    <div id="boards" class="column">
        <h1 class="h1">Boards</h1>
        <ul class="boardlist">
            <li v-for="board in boards" :key="board.id">
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
</template>

<style lang="scss">
.boardlist {
    width: 15em;
    margin: auto;
    background-color: #183757;
    padding: 0;
}
li {
    border: 0.1em solid;
    border-radius: 0.3em;
    margin: 0.3em;
}
a {
    color: #7ab1e9;
    text-decoration: none;
}
</style>

<script>
import api from "../APIClient/BoardAPIService.js";
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
