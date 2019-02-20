import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";

import "./styles/quasar.styl";
import iconSet from "quasar-framework/icons/ionicons";
import "quasar-extras/animate";
import "quasar-extras/ionicons";
import Quasar from "quasar";

Vue.use(Quasar, {
    config: {},
    iconSet: iconSet
});

import Vue2Filters from 'vue2-filters'

Vue.use(Vue2Filters)

Vue.config.productionTip = false;

new Vue({
    router,
    store,
    render: h => h(App)
}).$mount("#app");