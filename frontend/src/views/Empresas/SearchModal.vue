<template>
  <q-modal
    class="no-padding"
    v-model="visible"
    :content-css="{minWidth: '80vw', minHeight: '80vh'}"
  >
    <q-modal-layout>
      <q-toolbar slot="header">
        <q-btn flat round dense @click="visible = false" icon="ion-arrow-back"/>
        <q-toolbar-title>{{title}}</q-toolbar-title>
      </q-toolbar>

      <q-toolbar slot="footer">
        <q-search class="full-width" inverted v-model="search" color="none"/>
      </q-toolbar>

      <div>
        <q-list separator link>
          <q-item v-for="n in filteredData" :key="`c-${n.Id}`">
            <q-item-main :label="n.nombre"/>
          </q-item>
        </q-list>
      </div>
    </q-modal-layout>
  </q-modal>
</template>


<script>
import axios from "axios";
export default {
  props: ["visible", "title", "dataUrl"],
  data() {
    return {
      search: "",
      data: []
    };
  },
  created() {
    this.loadData();
  },
  methods: {
    loadData() {
      axios.get(this.dataUrl).then(resp => {
        this.data = resp.data;
      });
    }
  },
  computed: {
    filteredData() {
      if (!this.search) return this.data;
      return this.data.filter(d => d.includes(this.search));
    }
  }
};
</script>

