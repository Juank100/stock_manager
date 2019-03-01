<template>
  <q-layout view="lHh Lpr lFf">
    <q-layout-header>
      <q-toolbar color="primary" :glossy="$q.theme === 'mat'" :inverted="$q.theme === 'ios'">
        <q-btn
          flat
          round
          dense
          icon="ion-ios-arrow-back"
          @click="$router.go(-1)"
          v-if="showBackButton"
        />
        <q-toolbar-title>{{title}}</q-toolbar-title>
        <q-btn flat dense round @click="leftDrawerOpen = !leftDrawerOpen" icon="ion-menu"/>
      </q-toolbar>
    </q-layout-header>

    <q-layout-drawer v-model="leftDrawerOpen">
      <img src="/images/logo_empresa.png" class="logo">
      <q-list no-border link inset-delimiter>
        <q-list no-border link inset-delimiter>
          <q-item to="/" exact>
            <q-item-side icon="ion-home"/>
            <q-item-main label="Inicio"/>
          </q-item>

          <q-item-separator/>

          <q-item to="/Compras">
            <q-item-side icon="ion-paper"/>
            <q-item-main label="Compras"/>
          </q-item>
          <q-item to="/Empresas">
            <q-item-side icon="ion-business"/>
            <q-item-main label="Empresas"/>
          </q-item>
          <q-item to="/Contactos">
            <q-item-side icon="ion-contacts"/>
            <q-item-main label="Contactos"/>
          </q-item>
          <q-item to="/Items">
            <q-item-side icon="ion-cube"/>
            <q-item-main label="Productos"/>
          </q-item>
          <q-item to="/Ventas">
            <q-item-side icon="ion-cart"/>
            <q-item-main label="Ventas"/>
          </q-item>
        </q-list>
      </q-list>
    </q-layout-drawer>

    <q-page-container>
      <router-view/>

      <q-page-sticky position="bottom-right" :offset="[18, 18]">
        <q-fab color="primary" icon="ion-add" direction="up">
          <q-btn round color="secondary" icon="ion-person-add" :to="{name: 'Contactos.New'}"/>
          <q-btn round color="secondary" icon="ion-paper"/>
        </q-fab>
      </q-page-sticky>
    </q-page-container>
  </q-layout>
</template>

<script>
import { openURL } from "quasar";

export default {
  name: "LayoutDefault",
  data() {
    return {
      leftDrawerOpen: this.$q.platform.is.desktop
    };
  },
  methods: {
    openURL
  },
  computed: {
    title() {
      return this.$route.meta.title || "vacio";
    },
    showBackButton() {
      return this.$route.meta.showBackButton || true;
    }
  }
};
</script>

<style>
.logo {
  max-width: 100%;
}
</style>
