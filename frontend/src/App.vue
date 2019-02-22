<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<style>
.adaptable-width {
  margin-right: 1em;
}

@media only screen and (max-width: 767px) {
  .adaptable-width {
    width: 100%;
    margin-right: 0;
    margin-bottom: 1em;
  }
}

.blank {
  padding: 1em;
  border: 2px dashed #cccccc;
  text-align: center;
  color: #999;
}

table {
  width: 100%;
  text-align: left;
}

.center-v {
  display: flex;
  align-items: center;
}

.back-white {
  background-color: white;
}
</style>

