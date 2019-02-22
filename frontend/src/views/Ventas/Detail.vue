<template>
  <div>
    <q-toolbar color="primary" inverted>
      <q-toolbar-title>Factura #</q-toolbar-title>
      <q-btn flat round dense icon="ion-more"/>
    </q-toolbar>
    <div class="row gutter-sm">
      <div class="col-md-12">
        <span>Cliente:</span>
        {{data.contacto.Nombre}}
      </div>
      <div class="col-md-12">
        <b>Fecha:</b>
        {{data.Fecha | formatDate}}
      </div>
    </div>
    <table class="q-my-md">
      <thead>
        <th>Descripción</th>
        <th class="text-right">Precio Unit</th>
        <th class="text-right">Cantidad</th>
      </thead>
      <tbody>
        <tr v-for="itf in data.Items_Facturas" :key="itf.Id">
          <td>{{itf.Item.Nombre}}</td>
          <td class="text-right">{{itf.Item.Precio_Venta | currency}}</td>
          <td class="text-right">{{itf.cantidad}} {{itf.Item.Medida.Nombre}}</td>
          <td class="text-right">{{itf.cantidad * itf.Item.Precio_Venta | currency}}</td>
        </tr>
        <tr>
          <td colspan="4"></td>
        </tr>
        <tr class="q-my-md">
          <td colspan="3" class="text-right">SubTotal:</td>
          <td></td>
        </tr>
        <tr>
          <td colspan="3" class="text-right">IVA:</td>
          <td></td>
        </tr>
        <tr>
          <td colspan="3" class="text-right">Total:</td>
          <td></td>
        </tr>
      </tbody>
    </table>
    <div class="q-ma-md">
      <q-btn outline class="adaptable-width" color="primary" icon="ion-download" label="Descargar Factura"/>
      <q-btn outline class="adaptable-width" color="primary" icon="ion-mail" label="Enviar Por Correo"/>
    </div>
  </div>
</template>


<script>
import axios from "axios";
export default {
  data() {
    return {
      data: {}
    };
  },
  created() {
    this.loadData();
  },
  methods: {
    loadData() {
      var url = `/API/Facturas/${this.$route.params.Id}`;
      axios.get(url).then(resp => (this.data = resp.data));
    }
  }
};
</script>

