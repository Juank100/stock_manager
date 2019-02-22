<template>
  <div class="q-pa-md">
    <div class="row gutter-xs">
      <div class="col-xs-12 col-md-12">
        <q-input v-model="model.Nombre" float-label="Nombre"/>
      </div>
      <div class="col-xs-12 col-md-4">
        <q-select
          v-model="model.Id_Tipo_Persona"
          :options="TIPO_PERSONAS"
          float-label="Tipo Persona"
        />
      </div>
      <div class="col-xs-12 col-md-4">
        <q-select
          v-model="model.Tipo_Documento"
          :options="TIPO_DOCUMENTO"
          float-label="Tipo Documento"
        />
      </div>
      <div class="col-xs-9 col-md-3">
        <q-input type="number" v-model="model.Documento" float-label="Documento"/>
      </div>
      <div class="col-xs-3 col-md-1">
        <q-input
          type="number"
          v-model="model.Dig_Verificacion"
          float-label="Dig"
          :disable="model.Tipo_Documento != 'N'"
        />
      </div>
      <div class="col-xs-12 col-md-8">
        <q-input v-model="model.Direccion" float-label="Dirección"/>
      </div>
      <div class="col-xs-12 col-md-4">
        <q-input type="tel" v-model="model.Telefono" float-label="Telefono"/>
      </div>
    </div>
    <q-btn class="q-my-md full-width" label="Guardar" color="primary" @click="saveData"/>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      testId: null,
      model: {
        Tipo_Documento: "N"
      },
      TIPO_DOCUMENTO: [
        { value: 0, label: "Cedula" },
        { value: 1, label: "Cedula de Extranjeria" },
        { value: 2, label: "Nit" },
        { value: 3, label: "Pasaporte" }
      ],
      TIPO_PERSONAS: [
        { value: 0, label: "Persona Natural" },
        { value: 1, label: "Persona Juridica" }
      ]
    };
  },
  methods: {
    saveData() {
      let url = "/API/Empresas";
      axios
        .post(url, this.model)
        .then(resp => console.log(resp))
        .catch(error => console.error(error.resp));
    }
  }
};
</script>

