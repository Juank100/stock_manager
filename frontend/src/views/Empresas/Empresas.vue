<template>
  <div>
    <q-list separator link>
      <q-item v-for="empresa in empresas" :key="empresa.Id">
        <q-item-main :label="empresa.nombre"/>
      </q-item>
    </q-list>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      empresas: []
    };
  },
  created() {
    this.loadData();
  },
  methods: {
    loadData() {
      let url = "/API/Empresas";
      axios.get(url).then(resp => {
        this.empresas = resp.data;
      });
    }
  }
};
</script>

