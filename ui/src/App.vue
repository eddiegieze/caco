<template>
    <div id="app">
        <div id="nav"><router-link to="/">Home</router-link></div>
        <router-view />
    </div>
</template>

<style lang="scss">
html,
body {
    height: 100%;
    margin: 0;
    padding: 0;
}

ul {
    padding: 0;
}

li {
    list-style-type: none;
}

#app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    background-color: #c5d7e9;
    height: 100%;
}

#nav {
    padding: 2em;
    height: 1em;
    background-color: white;
    a {
        font-weight: bold;
        color: #2c3e50;

        &.router-link-exact-active {
            color: #42b983;
        }
    }
}
</style>
