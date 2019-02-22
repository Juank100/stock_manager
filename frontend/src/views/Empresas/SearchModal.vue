<template>
  <q-modal
    ref="searchModal"
    class="no-padding"
    v-model="visible"
    :content-css="{minWidth: '80vw', minHeight: '80vh'}"
  >
    <q-modal-layout>
      <q-toolbar slot="header" inverted>
        <q-btn flat round dense @click="visible = false" icon="ion-arrow-back"/>
        <q-toolbar-title>{{title}}</q-toolbar-title>
      </q-toolbar>

      <!-- <q-toolbar slot="header" inverted>
        <q-search class="full-width" inverted v-model="search" color="none"/>
      </q-toolbar> -->

      <div>
        <q-list separator highlight>
          <q-item
            v-for="n in filteredData"
            :key="`c-${n.Id}`"
            @click.native="selectItem(n)"
            v-ripple.mat
          >
            <q-item-main :label="n.Nombre"/>
          </q-item>
        </q-list>
      </div>
    </q-modal-layout>
  </q-modal>
</template>


<script>
import axios from "axios";
export default {
  props: ["visible", "title", "dataUrl", "value"],
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
    },
    selectItem(item) {
      this.$emit("input", item);
      this.$refs.searchModal.hide();
    },
    show() {
      this.$refs.searchModal.show();
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

