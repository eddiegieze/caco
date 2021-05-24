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
    color: #7ab1e9;
    background-color: #000000;
    height: 100%;
}

#nav {
    padding: 2em;
    height: 1em;
    background-color: rgb(22, 71, 90);
    a {
        font-weight: bold;
        color: #76b5f5;

        &.router-link-exact-active {
            color: #42b983;
        }
    }
}
.column {
    margin: 0.5em;
    background-color: #1b354d;
}

.cancel-button {
    background-image: url("/icons/cancel-white.svg");
}

.ok-button {
    background-image: url("/icons/ok-white.svg");
}

.edit-button {
    background-image: url("/icons/edit-white.svg");
}

.delete-button {
    background-image: url("/icons/delete-white.svg");
}
</style>
