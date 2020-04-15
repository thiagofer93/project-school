<template>
  <div id="app">
    <Nav></Nav>
    <div class="margin-principal">
      <router-view :key="$route.fullPath"></router-view>
    </div>
  </div>
</template>

<script>
import Nav from "./components/_nav/Nav.vue";

export default {
  name: "App",
  components: {
    Nav
  }
};
</script>

<style>
@import url("http://fonts.googleapis.com/css?family=Montserrat:400,700");

body {
  background-color: #eee;
  font-family: "Montserrat", sans-serif;
  display: grid;
  justify-items: center;
}

.margin-principal {
  width: 50%;
  margin: auto;
}

body {
  margin: 0;
  height: 100%;
}

#app {
  width: 100%;
}

table {
  margin: 0px;
  padding: 0px;
  list-style-type: none;
  width: 100%;
}

table thead th {
  background-color: rgb(184, 208, 216) !important;
  font-size: 1.2em;
  padding: 10px 0px;
  text-align: center !important;
}

table tr td {
  padding: 20px;
  font-size: 1.3em;
  background-color: #e0edf4;
  margin-bottom: 2px;
  color: #3e5252;
}

.col-small {
  width: 5%;
  text-align: right;
  background-color: rgb(125, 217, 245);
  font-weight: bold;
}

.spicy {
  background-color: #f35442;
}

.clean-sky {
  background-color: rgb(76, 186, 249);
}

.grassy {
  background-color: rgb(79, 196, 68);
}

.sandy {
  background-color: rgb(249, 186, 92);
}

.btn {
  border: 1px solid black;
  color: white;
  cursor: pointer;
  padding: 10px 20px;
  font-weight: bold;
  border-radius: 5px;
  border-bottom: 2px solid black;
  font-size: 0.8em;
}

.btn:hover {
  text-shadow: 1px 1px 1px black;
  margin-top: 1px;
  border-bottom: 1px solid black;
}

.btn-right {
  float: right;
}
.btn-left {
  float: left;
}

.titan-size {
  font-size: 1.4em !important;
}
</style>
