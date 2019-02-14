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
      <q-list no-border link inset-delimiter>
        <q-list no-border link inset-delimiter>
          <q-list-header>POS</q-list-header>
          <q-item to="/" exact>
            <q-item-side icon="ion-home"/>
            <q-item-main label="Inicio"/>
          </q-item>

          <q-item-separator/>

          <q-list-header>Configuration</q-list-header>
          <q-item to="/Empresas">
            <q-item-side icon="ion-business"/>
            <q-item-main label="Empresas"/>
          </q-item>
          <q-item to="/Contactos">
            <q-item-side icon="ion-contacts"/>
            <q-item-main label="Contactos"/>
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

<style></style>
