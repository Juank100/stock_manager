<template>
  <div>
    <div class="full-width text-center q-pa-lg" v-if="loading">
      <q-spinner-hourglass color="primary" :size="100"/>
    </div>
    <q-list separator link v-else-if="empresas.length">
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
        class="adaptable-width"
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
      loading: true,
      empresas: []
    };
  },
  created() {
    this.loadData();
  },
  methods: {
    loadData() {
      this.loading = true;
      let url = "/API/Empresas";
      axios.get(url).then(resp => {
        this.loading = false;
        this.empresas = resp.data;
      });
    }
  }
};
</script>

