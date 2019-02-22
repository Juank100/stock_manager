<template>
  <div class="q-pa-md">
    <div class="row gutter-xs">
      <div class="col-xs-12 col-md-12 tex">
        <q-input type="text" v-model="model.Nombre" float-label="Nombre"/>
      </div>
      <div class="col-xs-12 col-md-4">
        <q-input type="text" v-model="model.Codigo" float-label="Código"/>
      </div>
      <div class="col-xs-12 col-md-4">
        <q-select
          v-model="model.Tipo_Valoracion"
          :options="TIPO_VALORACION"
          float-label="Tipo Valoración"
        />
      </div>
      <div class="col-xs-12 col-md-4">
        <q-select
          v-model="model.Tipo_Precio_Venta"
          :options="TIPO_PRECIO_VENTA"
          float-label="Tipo Precio Venta"
        />
      </div>
      <div class="col-xs-12 col-md-4">
        <q-input type="number" v-model="model.Precio_Venta" align="right" float-label="Precio"/>
      </div>

      <div class="col-xs-12 col-md-4">
        <q-input
          type="number"
          v-model="model.IVA"
          float-label="IVA"
          min="0"
          max="100"
          align="right"
          suffix="%"
        />
      </div>

      <div class="col-md-4 col-xs-12">
        <q-input v-model="model.Medida.Nombre" float-label="Medida">
          <q-autocomplete :min-characters="2" :static-data="{field: 'nombre', list: ListaMedidas}"/>
        </q-input>
      </div>
      <div class="col-xs-12 col-md-12">
        <q-input type="textarea" v-model="model.Descripcion" float-label="Descripción"/>
      </div>
    </div>
    <q-btn class="q-my-md full-width" label="Guardar" color="primary" @click="saveData"/>
  </div>
</template>

<script>
import axios from "axios";

export default {
  // components: { SearchModal },
  data() {
    return {
      testId: null,
      medidas: [],
      model: {
        Medida: { Nombre: null },
        Tipo_Valoracion: window.TIPO_VALORACION.PRECIO_PROMEDIO,
        Tipo_Precio_Venta: window.TIPO_PRECIO_VENTA.PRECIO_FIJO
      }
    };
  },
  created() {
    this.loadData();
  },
  methods: {
    loadData() {
      let url = "/API/Medidas";
      axios.get(url).then(resp => (this.medidas = resp.data));
    },
    saveData() {
      let url = "/API/Items";
      axios
        .post(url, this.model)
        .then(resp => {
          console.log(resp);
          this.$router.go(-1);
        })
        .catch(error => console.error(error.resp));
    },
    enumToSelect(enums) {
      return Object.entries(enums).map(function(e) {
        let Capitalize = e[0].replace("_", " ").toLowerCase();
        return { label: Capitalize, value: e[1] };
      });
    }
  },
  computed: {
    TIPO_VALORACION() {
      return this.enumToSelect(window.TIPO_VALORACION);
    },
    TIPO_PRECIO_VENTA() {
      return this.enumToSelect(window.TIPO_PRECIO_VENTA);
    },
    ListaMedidas() {
      return this.medidas.map(p => ({
        values: p.Id,
        label: p.nombre,
        nombre: p.nombre
      }));
    }
  }
};
</script>

