import Vue from "vue";
import VueRouter from "vue-router";
// @ts-ignore
import Home from "../views/Home.vue";
// @ts-ignore
import Board from "../components/Board.vue";
// @ts-ignore
import Card from "../components/Card.vue";

Vue.use(VueRouter);

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/board/:boardId",
        name: "board",
        component: Board,
        children: [
            {
                path: "card/:cardId",
                name: "card",
                component: Card,
            },
        ],
    },
];

const router = new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes,
});

export default router;
