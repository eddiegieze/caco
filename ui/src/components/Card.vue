<template>
    <div id="board">
        <h1 class="h1">Card</h1>
        <div class="main">
            <ul>
                <li v-for="prop in card" :key="prop">
                    {{ prop }}
                </li>
            </ul>
        </div>
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
