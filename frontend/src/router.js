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
    mode: "history",
    routes: [{
        path: "/",
        component: DefaultLayout,
        children: [{
                path: "",
                name: "home",
                component: Home,
                meta: {
                    title: "Inicio",
                    showBackButton: false
                }
            },
            {
                path: "/about",
                name: "about",
                component: About
            },
            {
                path: "/Empresas",
                name: "Empresas",
                component: loadView("Empresas/Empresas"),
                meta: {
                    title: "Empresas"
                }
            },
            {
                path: "/Empresas/Nuevo",
                name: "Empresas.Nuevo",
                component: loadView("Empresas/Nuevo"),
                meta: {
                    title: "Nueva Empresa"
                }
            },
            {
                path: "/Items",
                name: "Items",
                component: loadView("Items/Index"),
                meta: {
                    title: "Productos"
                }
            },
            {
                path: "/Items/New",
                name: "Items.New",
                component: loadView("Items/Upsert"),
                meta: {
                    title: "Nuevo Productos"
                }
            },
            {
                path: "/Contactos",
                name: "Contactos",
                component: loadView("Contactos/Index"),
                meta: {
                    title: "Contactos"
                }
            },
            {
                path: "/Contactos/New",
                name: "Contactos.New",
                component: loadView("Contactos/Upsert"),
                meta: {
                    title: "Nuevo Contactos"
                }
            },
        ]
    }]
});