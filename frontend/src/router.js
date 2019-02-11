import Vue from "vue";
import Router from "vue-router";
import DefaultLayout from "./layouts/Default.vue";
import Home from "./views/Home.vue";
import About from "./views/About.vue";

Vue.use(Router);


function loadView(view) {
    return () =>
        import ( /* webpackChunkName: "view-[request]" */ `@/views/${view}.vue`);
}


export default new Router({
    routes: [{
        path: "/",
        component: DefaultLayout,
        children: [{
                path: "",
                name: "home",
                component: Home
            },
            {
                path: "/about",
                name: "about",
                component: About
            },
            {
                path: "/Empresas",
                name: "Empresas",
                component: loadView('Empresas/Empresas')
            }, {
                path: "/Empresas/Nuevo",
                name: "Empresas.Nuevo",
                component: loadView('Empresas/Nuevo')
            }
        ]
    }]
});