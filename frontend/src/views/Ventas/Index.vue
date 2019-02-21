<template>
  <div>
    <div class="full-width text-center q-pa-lg" v-if="loading">
      <q-spinner-hourglass color="primary" :size="100"/>
    </div>

    <q-list separator link v-else-if="ventas.length">
      <q-item v-for="c in ventas" :key="c.id" :to="{name:'Ventas.Detail', params:{Id: c.id}}">
        <q-item-main>
          <q-item-tile label>{{c.contacto.nombre}}</q-item-tile>
          <q-item-tile sublabel class="row">
            <div class="col-xs-6">items</div>
          </q-item-tile>
        </q-item-main>
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
      loading: true,
      ventas: []
    };
  },
  created() {
    this.loadData();
  },
  methods: {
    loadData() {
      this.loading = true;
      let url = "/API/Facturas/Ventas";
      axios.get(url).then(resp => {
        this.ventas = resp.data;
        this.loading = false;
      });
    }
  }
};
</script>

