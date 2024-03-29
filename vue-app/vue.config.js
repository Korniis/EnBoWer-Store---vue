const { defineConfig } = require('@vue/cli-service')

module.exports = defineConfig({
  transpileDependencies: true,
  devServer:{

    proxy:{
      "^/api":{

        target:"https://localhost:7245/api/",
        secure:false,
        changeOrigin : true,

      }

    }
  },
  pwa: {
    iconPaths: {
        favicon32: 'favicon.ico',
        favicon16: 'favicon.ico',
        appleTouchIcon: 'favicon.ico',
        maskIcon: 'favicon.ico',
        msTileImage: 'favicon.ico'
    }
}

})
