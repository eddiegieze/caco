<template>
    <div class="home">
        <h1 class="welcome">Welcome to Cards & Columns</h1>
        <div id="mainboards">
            <Boards :editable="false" />
        </div>
        <div class="backgroundsource">
            Photo by
            <a
                href="https://unsplash.com/@aridley88?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText"
                >Andrew Ridley</a
            >
            on
            <a
                href="https://unsplash.com/s/photos/geometric-pattern?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText"
                >Unsplash</a
            >
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
        padding: 0 1em 0 1em;
        display: block;
    }
}

.column {
    h1 {
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
        padding: 0 1em 0 1em;
        display: block;
    }
}

.welcome {
    text-shadow: 3px 4px 2px #000;
    color: #b1d8ff;
}

.backgroundsource {
    color: black;
    a {
        color: rgb(59, 59, 59);
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
