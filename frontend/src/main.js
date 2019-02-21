import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";

import "./styles/quasar.styl";
import iconSet from "quasar-framework/icons/ionicons";
import "quasar-extras/animate";
import "quasar-extras/ionicons";
import Quasar from "quasar";
import Vue2Filters from 'vue2-filters'
import moment from 'moment';

Vue.use(Quasar, {
    config: {},
    iconSet: iconSet
});


Vue.use(Vue2Filters);



Vue.filter('formatDate', function(value) {
    if (value) {
        return moment(String(value)).format('MM/DD/YYYY hh:mm')
    }
})

Vue.config.productionTip = false;

new Vue({
    router,
    store,
    render: h => h(App)
}).$mount("#app");;