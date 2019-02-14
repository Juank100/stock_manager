<template>
  <div>
    <q-list separator link v-if="contactos.length">
      <q-item v-for="c in contactos" :key="c.Id">
        <q-item-main :label="c.nombre"/>
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
        label="Nuevo Contacto"
        :to="{name:'Contactos.New'}"
      />
    </q-layout-footer>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      contactos: []
    };
  },
  created() {
    this.loadData();
  },
  methods: {
    loadData() {
      let url = "/API/Contactos";
      axios.get(url).then(resp => {
        this.contactos = resp.data;
      });
    }
  }
};
</script>

