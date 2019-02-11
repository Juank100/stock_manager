<template>
  <div>
    <q-btn
      class="q-my-md q-ml-md"
      color="primary"
      size="full-width"
      label="Nueva Empresa"
      icon="ion-add"
      :to="{name: 'Empresas.Nuevo'}"
    />
    <q-list separator link>
      <q-list-header>Empresas</q-list-header>
      <q-item>
        <q-item-main label="Empresa Prueba"/>
      </q-item>
      <q-item>
        <q-item-main label="Empresa Prueba"/>
      </q-item>
      <q-item>
        <q-item-main label="Empresa Prueba"/>
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
        this.data = resp.data;
      });
    }
  }
};
</script>

