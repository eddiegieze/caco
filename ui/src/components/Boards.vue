<template>
    <div id="boards" class="column">
        <h1>Boards</h1>
        <div class="boards-container">
            <ul class="boardlist">
                <li v-for="board in boards" :key="board.id">
                    <InlineEdit
                        :itemName="board.name"
                        :itemId="board.id"
                        @item-deleted="deleteBoard"
                        @item-edited="editBoard"
                        v-if="editable"
                    >
                        <router-link
                            :to="{
                                name: 'board',
                                params: { boardId: board.id },
                            }"
                        >
                            {{ board.name }}
                        </router-link>
                    </InlineEdit>
                    <div v-else>
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
                <li v-if="editable">
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
import InlineEdit from "./InlineEdit.vue";
import InlineAdd from "./InlineAdd.vue";
export default {
    data() {
        return {
            boards: [],
        };
    },
    components: {
        InlineEdit,
        InlineAdd,
    },
    async created() {
        this.fetchData();
    },
    props: {
        editable: {
            type: Boolean,
            default: true,
        },
    },
    methods: {
        async fetchData() {
            this.boards = await api.getAll();
        },
        async addBoard(boardName) {
            await api.create({ name: boardName });
            this.fetchData();
        },
        async deleteBoard(boardId) {
            await api.delete(boardId);
            this.fetchData();
        },
        async editBoard(boardId, boardName) {
            await api.update(boardId, { name: boardName });
            this.fetchData();
        },
    },
};
</script>
