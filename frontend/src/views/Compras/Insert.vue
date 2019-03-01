<template>
  <div class="q-pa-md">
    <div class="row gutter-xs">
      <div class="col-xs-12 col-md-4">
        <q-input v-model="model.Num" float-label="Num"/>
      </div>
      <div class="col-xs-12 col-md-6">
        <q-input
          v-model="contacto.Nombre"
          type="text"
          float-label="Proveedor"
          @click="selectContact"
          readonly
        />
      </div>
      <div class="col-xs-12 col-md-6">
        <q-input
          v-model="empresa.Nombre"
          type="text"
          float-label="POS"
          @click="openempresa"
          readonly
        />
      </div>
    </div>

    <div class="q-my-lg"></div>

    <div class="q-my-lg" v-if="items.length">
      <div class="row q-my-md" v-for="i in items" :key="i.producto.Id">
        <div class="col-xs-12 col-md-12">
          <q-btn icon="ion-close"/>
          {{i.producto.Nombre}}
        </div>
        <div class="col-xs-6 col-md-4 center-v">
          <span>
            <b>Stock:</b>
            {{i.producto.Stock}} {{i.producto.Medida.Nombre}}
          </span>
        </div>
        <div class="col-xs-12 col-md-4">
          <q-input
            v-model="i.Precio"
            type="number"
            align="right"
            float-label="Precio Compra"
            prefix="$"
          />
        </div>
        <div class="col-xs-12 col-md-4">
          <q-input
            v-model="i.Cantidad"
            type="number"
            align="right"
            float-label="Cantidad"
            :suffix="i.producto.Medida.Nombre"
          />
        </div>
      </div>
    </div>

    <q-btn
      class="q-my-md full-wIdth"
      label="Agregar Producto"
      color="primary"
      outline
      @click="agregarProducto"
    />

    <q-layout-footer class="q-pa-sm back-white" reveal>
      <span class="float-left center-v">
        <b>Total:</b> 0.0
      </span>
      <q-btn class="float-right" label="Guardar" color="primary" @click="saveData"/>
    </q-layout-footer>

    <SearchModal ref="ClienteModal" title="Contactos" data-url="/API/Contactos" v-model="contacto"/>

    <SearchModal ref="posModal" title="pos" data-url="/API/Empresas/" v-model="empresa"/>
    <SearchModal
      ref="ProductosModal"
      title="Productos"
      data-url="/API/Items"
      v-model="currProducto"
      @input="addProducto"
    />
  </div>
</template>

<script>
import axios from "axios";
import SearchModal from "../Empresas/SearchModal";

export default {
  components: { SearchModal },
  data() {
    return {
      empresa: {},
      items: [],
      Cantidad: 0,
      contacto: {},
      currProducto: {},
      showSelectContactModal: false,
      model: {
        Tipo_Factura: window.TIPO_FACTURA.COMPRA
      }
    };
  },
  created() {
    // this.getNextConsecutivo()
  },
  methods: {
    saveData() {
      this.model.Id_Contacto = this.contacto.Id;
      let data = {
        Factura: this.model,
        Items: this.items
      };
      let url = "/API/Facturas";
      axios
        .post(url, data)
        .then(resp => {
          console.log(resp);
          this.$router.go(-1);
        })
        .catch(error => console.error(error.resp));
    },
    selectContact() {
      this.$refs.ClienteModal.show();
    },
    openempresa() {
      this.$refs.posModal.show();
    },
    agregarProducto() {
      this.$refs.ProductosModal.show();
    },
    addProducto(a) {
      this.items.push({ producto: a, Cantidad: 1 });
    },
    enumToSelect(enums) {
      return Object.entries(enums).map(function(e) {
        let Capitalize = e[0].replace("_", " ").toLowerCase();
        return { label: Capitalize, value: e[1] };
      });
    }
  },
  computed: {
    TIPO_FACTURA() {
      return this.enumToSelect(window.TIPO_FACTURA);
    }
  }
};
</script>


<style scoped>
table {
  width: 100%;
  text-align: left;
}

.center-v {
  display: flex;
  align-items: center;
}

.back-white {
  background-color: white;
}
</style>


