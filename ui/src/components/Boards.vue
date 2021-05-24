<template>
    <div id="boards" class="column">
        <h1>Boards</h1>
        <div class="boards-container">
            <ul class="boardlist">
                <li v-for="board in boards" :key="board.id">
                    <div>
                        <router-link
                            :to="{
                                name: 'board',
                                params: { boardId: board.id },
                            }"
                        >
                            {{ board.name }}
                        </router-link>
                    </div>
                </li>
                <li v-if="showAddButton">
                    <InlineAdd @item-added="addBoard" />
                </li>
            </ul>
        </div>
    </div>
</template>

<style lang="scss">
.boards-container {
    display: flex;
    align-items: center;
    justify-content: center;
}

.boardlist {
    width: 15em;
    padding: 0;

    li {
        background-color: #185754;
    }

    a {
        color: #7ae2e9;
    }

    a.router-link-active {
        color: #ffffff;
    }
}

#boards {
    background-color: #1b434d;
}

li {
    border: 0.1em solid;
    border-radius: 0.3em;
    margin: 0.3em;
    background-color: #183757;
    height: 2em;
    div {
        padding-top: 0.3em;
    }
}

a {
    color: #7ab1e9;
    text-decoration: none;
}
</style>

<script>
import api from "../APIClient/BoardAPIService.js";
import InlineAdd from "./InlineAdd.vue";
export default {
    data() {
        return {
            boards: [],
        };
    },
    components: {
        InlineAdd,
    },
    async created() {
        this.boards = await api.getAll();
    },
    props: {
        showAddButton: {
            type: Boolean,
            default: true,
        },
    },
    methods: {
        async addBoard(boardName) {
            await api.create({ name: boardName });
            this.boards = await api.getAll();
        },
    },
};
</script>
