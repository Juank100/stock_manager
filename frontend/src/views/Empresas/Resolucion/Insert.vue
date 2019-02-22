<template>
  <div id="InsertResolucion q-pa-md">
    <div class="row gutter-md">
      <div class="col-xs-12 col-md-4">
        <q-input type="text" v-model="model.Prefijo" float-label="Prefijo"/>
      </div>
      <div class="col-xs-12 col-md-4">
        <q-input type="number" v-model="model.Desde" align="right" float-label="Desde"/>
      </div>
      <div class="col-xs-12 col-md-4">
        <q-input type="number" v-model="model.Hasta" align="right" float-label="Hasta"/>
      </div>
    </div>

    <q-layout-footer class="q-pa-sm" reveal>
      <q-btn
        class="adaptable-width"
        color="secondary"
        icon="ion-add"
        label="Guardar"
        :loading="saving"
        @click="save"
      />
    </q-layout-footer>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      saving: false,
      model: {}
    }
  },
  methods: {
    save() {
      this.saving = true;
      this.model.Id_Empresa = this.$route.query.Id_Empresa;
      let url = "/API/ResolucionFacturacion";
      axios
        .post(url, this.model)
        .then(resp => {
          console.log(resp);
          this.$router.go(-1);
          this.saving = false;
        })
        .catch(error => console.error(error.resp));
    }
  }
}
</script>
