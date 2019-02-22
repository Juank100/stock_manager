<template>
  <div>
    <div class="full-widt text-center q-ma-md" v-if="loading">
      <q-spinner-hourglass color="primary" :size="100"/>
    </div>

    <div class="row">
      <div class="col-xs-11">{{data.Nombre}}</div>
      <div class="col-xs-1">
        <q-btn icon="ion-more"/>
      </div>
    </div>

    <q-list separator link>
      <q-list-header>POS</q-list-header>
      <q-item
        v-for="empresa in pos"
        :key="empresa.Id"
        :to="{name:'Empresas.Detail', params:{Id: empresa.Id}}"
      >
        <q-item-main :label="empresa.Nombre"/>
      </q-item>
      <div class="blank q-ma-md">
        <p>No existen datos para mostrar.</p>
      </div>
    </q-list>
    <div class="q-ma-md">
      <q-btn class="full-width q-ma-md" color="primary" icon="ion-add" label="Agregar POS" outline/>
    </div>

    <q-list separator link>
      <q-list-header>Resolución Facturación</q-list-header>
      <q-item
        v-for="empresa in pos"
        :key="empresa.Id"
        :to="{name:'Empresas.Detail', params:{Id: empresa.Id}}"
      >
        <q-item-main :label="empresa.Nombre"/>
      </q-item>
      <div class="blank q-ma-md">
        <p>No existen datos para mostrar.</p>
      </div>
    </q-list>
    <div class="q-ma-md">
      <q-btn
        class="full-width q-ma-md"
        color="primary"
        icon="ion-add"
        label="Agregar Resolución"
        :to="{name:'Resolucion.New', query:{Id_Empresa: data.Id}}"
        outline
      />
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      loading: true,
      pos: [],
      data: {}
    };
  },
  created() {
    this.loadData();
  },
  methods: {
    loadData() {
      this.loading = true;
      var url = `/API/Empresas/${this.$route.params.Id}`;
      axios.get(url).then(resp => {
        (this.data = resp.data);
        this.loading = false
        });
    }
  }
};
</script>
