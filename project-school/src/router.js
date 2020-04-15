import Vue from 'vue';
import Router from 'vue-router';
import Alunos from "./components/aluno/Alunos.vue";
import AlunoDetalhe from "./components/aluno/AlunoDetalhe.vue";
import Professores from "./components/professor/Professores.vue";
import Sobre from "./components/sobre/Sobre.vue";

Vue.use(Router);

export default new Router({
    routes: [{
        path: '/professores',
        name: 'Professores',
        component: Professores
    },
    {
        path: '/alunosall',
        name: 'AlunosAll',
        component: Alunos
    },
    {
        path: '/alunos/:prof_id',
        name: 'Alunos',
        component: Alunos
    },
    {
        path: '/alunoDetalhe/:id',
        name: 'AlunoDetalhe',
        component: AlunoDetalhe
    },
    {
        path: '/sobre',
        name: 'Sobre',
        component: Sobre
    }
]
})