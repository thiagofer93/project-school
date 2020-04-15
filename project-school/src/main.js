import Vue from 'vue'
import App from './App.vue'
import Router from './router'
import VueResource from 'vue-resource'

Vue.config.productionTip = false
Vue.use(VueResource)

new Vue({
  router: Router,
  render: h => h(App),
}).$mount('#app')
