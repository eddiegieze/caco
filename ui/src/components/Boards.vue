<template>
    <div id="boards">
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
    background-color: #bcddff;
    padding: 0;
    border: 0.1em solid;
    border-radius: 0.3em;
}

.boardlist li {
    list-style-type: none;
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
