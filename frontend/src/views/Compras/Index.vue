<template>
  <div>
    <q-list separator link v-if="compras.length">
      <q-item v-for="c in compras" :key="c.Id">
        <q-item-main :label="c.Id"/>
      </q-item>
    </q-list>
    <div class="blank q-ma-md" v-else>
      <p>No existen datos para mostrar.</p>
    </div>

    <div class="q-my-md q-pa-md"></div>
    <q-layout-footer class="q-pa-sm" reveal>
      <q-btn
        class="full-width"
        color="primary"
        icon="ion-add"
        label="Nuevo"
        :to="{name:'Compras.New'}"
      />
    </q-layout-footer>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      compras: []
    };
  },
  created() {
    this.loadData();
  },
  methods: {
    loadData() {
      let url = "/API/Facturas/Compras";
      axios.get(url).then(resp => {
        this.compras = resp.data;
      });
    }
  }
};
</script>

