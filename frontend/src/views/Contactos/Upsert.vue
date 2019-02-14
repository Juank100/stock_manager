<template>
  <div class="q-pa-md">
    <div class="row gutter-xs">
      <div class="col-xs-12 col-md-4">
        <q-select
          v-model="model.Tipo_Contacto"
          :options="TIPO_CONTACTO"
          float-label="Tipo Contacto"
        />
      </div>
      <div class="col-xs-12 col-md-4">
        <q-select v-model="model.Tipo_Persona" :options="TIPO_PERSONA" float-label="Tipo Persona"/>
      </div>
      <div class="col-xs-12 col-md-12">
        <q-input v-model="model.Nombre" float-label="Nombre"/>
      </div>
      <div class="col-xs-12 col-md-4">
        <q-select
          v-model="model.Tipo_Documento"
          :options="TIPO_DOCUMENTOS"
          float-label="Tipo Documento"
        />
      </div>
      <div class="col-xs-12 col-md-4">
        <q-input type="number" v-model="model.Documento" float-label="Documento"/>
      </div>
      <div class="col-xs-12 col-md-8">
        <q-input type="email" v-model="model.Dir_Elec" float-label="Correo Electronico"/>
      </div>
      <div class="col-xs-12 col-md-4">
        <q-input type="tel" v-model="model.Telefono" float-label="Telefono"/>
      </div>
      <div class="col-xs-12 col-md-4">
        <q-input type="tel" v-model="model.Celular" float-label="Celular"/>
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
      model: {
        Tipo_Documento: window.TIPO_DOCUMENTOS.CEDULA,
        Tipo_Contacto: window.TIPO_CONTACTO.CLIENTE,
        Tipo_Persona: window.TIPO_PERSONA.NATURAL
      }
    };
  },
  methods: {
    saveData() {
      let url = "/API/Contactos";
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
    TIPO_DOCUMENTOS() {
      return this.enumToSelect(window.TIPO_DOCUMENTOS);
    },
    TIPO_CONTACTO() {
      return this.enumToSelect(window.TIPO_CONTACTO);
    },
    TIPO_PERSONA() {
      return this.enumToSelect(window.TIPO_PERSONA);
    }
  }
};
</script>

