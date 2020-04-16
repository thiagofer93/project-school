<template>
  <div v-if="!loading">
    <titulo :texto="`Aluno: ${aluno.nome}`" :btnVoltar="isEdit">
      <button v-show="!isEdit" class="btn btn-right titan-size clean-sky" @click="editar()">Editar</button>
    </titulo>
    <table>
      <tbody>
        <tr>
          <td class="col-small">Matrícula:</td>
          <td>
            <label>{{aluno.id}}</label>
          </td>
        </tr>
        <tr>
          <td class="col-small">Nome:</td>
          <td>
            <input v-if="isEdit" v-model="aluno.nome" type="text" />
            <label v-else>{{aluno.nome}}</label>
          </td>
        </tr>
        <tr>
          <td class="col-small">Sobrenome:</td>
          <td>
            <input v-if="isEdit" v-model="aluno.sobrenome" type="text" />
            <label v-else>{{aluno.sobrenome}}</label>
          </td>
        </tr>
        <tr>
          <td class="col-small">Data Nascimento:</td>
          <td>
            <input v-if="isEdit" v-model="aluno.dataNasc" type="text" />
            <label v-else>{{aluno.dataNasc}}</label>
          </td>
        </tr>
        <tr>
          <td class="col-small">Professor:</td>
          <td>
            <select v-if="isEdit" v-model="aluno.professor.id">
              <option
                v-for="professor in professores"
                :key="professor.id"
                :value="professor.id"
              >{{ professor.nome }}</option>
            </select>
            <label v-else>{{aluno.professor.nome}}</label>
          </td>
        </tr>
      </tbody>
    </table>

    <div style="margin-top: 10px">
      <div v-if="isEdit">
        <button class="btn btn-right grassy" @click="salvar()">Salvar</button>
        <button class="btn btn-left sandy" @click="cancelar()">Cancelar</button>
      </div>
    </div>
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
      professores: [],
      aluno: {},
      id: this.$route.params.id,
      isEdit: false,
      loading: true
    };
  },
  created() {
    this.carregarProfessor();
  },
  methods: {
    editar() {
      this.isEdit = !this.isEdit;
    },
    salvar() {
      let alunoEditar = {
        id: this.aluno.id,
        nome: this.aluno.nome,
        sobrenome: this.aluno.sobrenome,
        dataNasc: this.aluno.dataNasc,
        professorId: this.aluno.professor.id
      };

      this.$http
        .put(`http://localhost:5000/api/aluno/${alunoEditar.id}`, alunoEditar)
        .then(res => res.json())
        .then(aluno => (this.aluno = aluno));
      this.cancelar();
    },
    cancelar() {
      this.isEdit = false;
    },
    carregarProfessor() {
      this.$http
        .get(`http://localhost:5000/api/professor`)
        .then(res => res.json())
        .then(professores => {
          this.professores = professores;
          this.carregarAluno();
        });
    },
    carregarAluno() {
      this.$http
        .get(`http://localhost:5000/api/aluno/${this.id}`)
        .then(res => res.json())
        .then(aluno => {
          this.aluno = aluno;
          this.loading = false;
        });
    }
  }
};
</script>

<style scoped>
.col-small {
  width: 20%;
}

input,
select {
  margin: 0px;
  padding: 5px 10px;
  font-size: 0.9em;
  border: 1px solid silver;
  border-radius: 5px;
  font-family: Montserrat;
  background-color: rgb(245, 245, 245);
  width: 95%;
}

select {
  height: 38px;
  width: 100%;
}
</style>