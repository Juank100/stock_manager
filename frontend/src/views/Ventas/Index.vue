<template>
  <div>
    <q-list separator link v-if="ventas.length">
      <q-item v-for="c in ventas" :key="c.Id">
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
        :to="{name:'Ventas.New'}"
      />
    </q-layout-footer>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      ventas: []
    };
  },
  created() {
    this.loadData();
  },
  methods: {
    loadData() {
      let url = "/API/Facturas/Ventas";
      axios.get(url).then(resp => {
        this.ventas = resp.data;
      });
    }
  }
};
</script>

