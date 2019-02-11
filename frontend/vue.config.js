const path = require("path")

module.exports = {
    outputDir: "../stock_manager/wwwroot/",
    chainWebpack: config => {
        // aspnet uses the other hmr so remove this one
        config.plugin("html").tap(([options]) => [
            Object.assign(options, {
                filename: path.resolve("../stock_manager/Views/Home/Index.cshtml")
            })
        ]);
    },
    pluginOptions: {
        quasar: {
            theme: "ios",
            importAll: true
        }
    },
    transpileDependencies: [/[\\\/]node_modules[\\\/]quasar-framework[\\\/]/]
}