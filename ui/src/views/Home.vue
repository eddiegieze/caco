<template>
    <div class="home">
        <h1>Welcome home.</h1>
        <Boards />
        <Board />
    </div>
</template>

<script>
import Boards from "../components/Boards";
import Board from "../components/Board";

export default {
    name: "Home",
    components: {
        Boards,
        Board,
    },
};
</script>
