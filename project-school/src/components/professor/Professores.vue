<template>
  <div>
    <titulo texto="Professores" />
    <table>
      <thead>
        <th>Código</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="professores.length">
        <tr v-for="(professor, index) in professores" :key="index">
          <td class="col-small">{{professor.id}}</td>
          <router-link
            :to="`/alunos/${professor.id}`"
            tag="td"
            style="cursor: pointer"
          >{{professor.nome}} {{professor.sobrenome}}</router-link>
          <td class="col-small" style="text-align: center; width:20%">{{professor.qtdAlunos}}</td>
        </tr>
      </tbody>
      <tfoot v-else>Nenhum professor encontrado</tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_shared/Titulo";

export default {
  data() {
    return {
      professores: [],
      alunos: []
    };
  },
  components: {
    Titulo
  },
  created() {
    this.$http
      .get("http://localhost:3000/alunos")
      .then(res => res.json())
      .then(alunos => {
        this.alunos = alunos;
        this.carregarProfessores();
      });
  },
  props: {},
  methods: {
    alunosByProfessor() {
      this.professores.forEach((professor, index) => {
        professor = {
          id: professor.id,
          nome: professor.nome,
          qtdAlunos: this.alunos.filter(
            aluno => aluno.professor.id == professor.id
          ).length
        };

        this.professores[index] = professor;
      });
    },
    carregarProfessores() {
      this.$http
        .get("http://localhost:3000/professores")
        .then(res => res.json())
        .then(professores => {
          this.professores = professores;
          this.alunosByProfessor();
        });
    }
  }
};
</script>

<style scoped>
</style>