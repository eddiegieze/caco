<template>
  <div class="home">
    <h1>Welcome home.</h1>
    <Boards />
  </div>
</template>

<script>
import Boards from "../components/Boards";

export default {
  name: "Home",
  components: {
    Boards,
  },
};
</script>
