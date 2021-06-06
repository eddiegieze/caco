<template>
    <div id="app">
        <div id="nav"><router-link to="/">Home</router-link></div>
        <router-view />
    </div>
</template>

<style lang="scss">
html,
body {
    margin: 0;
    padding: 0;
    background-color: #000000;
    background-image: url("/andrew-ridley-jR4Zf-riEjI-unsplash.jpg");
    background-size: cover;
    width: 100vw;
    height: 100vh;
}

h1 {
    display: inline;
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

.add-button {
    background-image: url("/icons/add-white.svg");
}

.column {
    border-radius: 0.3em;
    box-shadow: 3px 3px 5px #000;
    margin: 0.5em;
    background-color: #1b354d;
    width: 15em;
    min-width: 15em;
}
</style>
