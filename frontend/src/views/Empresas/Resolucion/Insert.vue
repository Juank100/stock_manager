<template>
  <div id="InsertResolucion"></div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {

      model: {}
    }
  },
  methods: {
    save() {
      this.model.Id_Empresa = this.$route.query.Id_Empresa;
      let url = "/API/ResolucionFacturacion";
      axios
        .post(url, this, model)
        .then(resp => {
          console.log(resp);
          this.$router.go(-1);
        })
        .catch(error => console.error(error.resp));
    }
  }
}
</script>
