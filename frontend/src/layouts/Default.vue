<template>
  <q-layout view="lHh Lpr lFf">
    <q-layout-header>
      <q-toolbar color="primary" :glossy="$q.theme === 'mat'" :inverted="$q.theme === 'ios'">
        <q-btn
          flat
          dense
          round
          @click="leftDrawerOpen = !leftDrawerOpen"
          aria-label="Menu"
          icon="ion-menu"
        />

        <q-toolbar-title>Stock Manager</q-toolbar-title>
      </q-toolbar>
    </q-layout-header>

    <q-layout-drawer
      v-model="leftDrawerOpen"
      :content-class="$q.theme === 'mat' ? 'bg-grey-2' : null"
    >
      <q-list no-border link inset-delimiter>
        <q-list no-border link inset-delimiter>
          <q-list-header>POS</q-list-header>
          <q-item to="/" exact>
            <q-item-side icon="ion-home"/>
            <q-item-main label="Inicio"/>
          </q-item>
          <q-item to="/about">
            <q-item-side icon="ion-ios-information-circle-outline"/>
            <q-item-main label="Empresas"/>
          </q-item>

          <q-item-separator/>

          <q-list-header>Configuration</q-list-header>
          <q-item to="/about">
            <q-item-side icon="ion-information-outline"/>
            <q-item-main label="Empresas"/>
          </q-item>
        </q-list>
      </q-list>
    </q-layout-drawer>

    <q-page-container>
      <router-view/>

      <q-page-sticky position="bottom-right" :offset="[18, 18]">
        <q-fab color="primary" icon="ion-add" direction="up">
          <q-btn round color="secondary" icon="ion-person-add"/>
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
  }
};
</script>

<style></style>
