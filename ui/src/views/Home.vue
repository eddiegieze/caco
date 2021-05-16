<template>
    <div class="home">
        <h1>Welcome to Cards & Columns</h1>
        <div id="mainboards">
            <Boards />
        </div>
    </div>
</template>

<style lang="scss">
.home {
    height: 70%;
}
#mainboards {
    width: 50em;
    margin: auto;
    display: flex;
    justify-content: center;
}
</style>

<script>
import Boards from "../components/Boards.vue";

export default {
    name: "Home",
    components: {
        Boards,
    },
};
</script>
