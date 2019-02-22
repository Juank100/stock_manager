<template>
  <div>
    <q-list separator link v-if="empresas.length">
      <q-item
        v-for="empresa in empresas"
        :key="empresa.Id"
        :to="{name:'Empresas.Detail', params:{Id: empresa.Id}}"
      >
        <q-item-main :label="empresa.Nombre"/>
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
        label="Nueva Empresa"
        :to="{name:'Empresas.Nuevo'}"
      />
    </q-layout-footer>
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

