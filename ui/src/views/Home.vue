<template>
    <div class="home">
        <h1>Welcome to Cards & Columns</h1>
        <div id="mainboards">
            <Boards :editable="false" />
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

li {
    a {
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
        padding: 0 2em 0 2em;
        display: block;
    }
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
