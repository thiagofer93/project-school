<template>
  <div>
    <titulo texto="Aluno" />
    <input type="text" placeholder="Nome do aluno" v-model="nome" @keyup.enter="addAluno()" />
    <button class="btn btn-input" @click="addAluno()">Adicionar</button>
    <table>
      <thead>
        <th>Matrícula</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td>{{aluno.id}}</td>
          <td>{{aluno.nome}} {{aluno.sobrenome}}</td>
          <td>
            <button class="btn spicy" @click="remover(aluno)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>Nenhum aluno encontrado</tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_shared/Titulo";

export default {
  components: {
    Titulo
  },
  data() {
    return {
      title: "Aluno",
      nome: "",
      alunos: []
    };
  },
  created() {
    this.$http
      .get("http://localhost:3000/alunos")
      .then(res => res.json())
      .then(alunos => (this.alunos = alunos));
  },
  props: {},
  methods: {
    addAluno() {
      let alunoAdd = { nome: this.nome, sobrenome: "" };

      this.$http
        .post("http://localhost:3000/alunos", alunoAdd)
        .then(res => res.json())
        .then(aluno => {
          this.alunos.push(aluno);
          this.nome = "";
        });
    },
    remover(aluno) {
      this.$http.delete(`http://localhost:3000/alunos/${aluno.id}`).then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
input {
  border: 0;
  padding: 8px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}

.btn-input {
  border-radius: 0px;
  border-top-right-radius: 5px;
  border-bottom-right-radius: 5px;
  width: 110px;
  border: 0px;
  padding: 8px;
  font-size: 1.3em;
  background-color: rgb(116, 115, 115);
}

.btn-input:hover {
  padding: 8px;
  margin: 0px;
  border: 0px;
}
</style>
