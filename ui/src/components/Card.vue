<template>
    <div id="board">
        <h1 class="h1">{{ card.name }}</h1>
        <p>{{ card.description }}</p>
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
//import api from "@/CardAPIService";
export default {
    props: {
        card: Object,
    },
};
</script>
