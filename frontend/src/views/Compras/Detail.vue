<template>
  <div></div>
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

