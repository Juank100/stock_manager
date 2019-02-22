<template>
  <div>
    <q-list separator link v-if="items.length">
      <q-item v-for="i in items" :key="i.id">
        <q-item-main>
          <q-item-tile label>{{i.nombre}}</q-item-tile>
          <q-item-tile sublabel class="row">
            <div class="col-xs-6">Stock: {{i.stock}}</div>
            <div class="col-xs-6">Precio Venta: {{i.precio_Venta | currency}}</div>
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
        class="full-width"
        color="primary"
        icon="ion-add"
        label="Nuevo"
        :to="{name:'Items.New'}"
      />
    </q-layout-footer>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      items: []
    };
  },
  created() {
    this.loadData();
  },
  methods: {
    loadData() {
      let url = "/API/Items";
      axios.get(url).then(resp => {
        this.items = resp.data;
      });
    }
  }
};
</script>

