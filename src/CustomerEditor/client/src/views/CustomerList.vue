<template>
  <div>
    <div class="alert alert-warning" v-if="error.length > 0">{{ error }}</div>
    <div v-if="isBusy">Loading...</div>
    <h1>Customer List</h1>
    <div class="row mb-2">
      <router-link to="/newCustomer" class="btn btn-secondary">Add New</router-link>
    </div>
    <div class="row">
      <table class="table table-bordered table-hover">
        <thead class="thead-dark">
          <tr>
            <th>Company</th>
            <th>Contact</th>
            <th>Phone Number</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="c in customers" :key="c.id">
            <td>{{ c.companyName }}</td>
            <td>{{ c.contactName }}</td>
            <td>{{ c.phone }}</td>
            <td>
              <button class="btn btn-sm btn-secondary">Edit</button>&nbsp;
              <button class="btn btn-sm btn-secondary">Delete</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>
<script>
  import { mapState } from 'vuex'
  export default {
    data() {
      return {
        isBusy: false,
        error: ""
      }
    },
    computed: {
      ...mapState(['customers'])
    },
    mounted() {
      this.isBusy = true;
      this.$store.dispatch('load')
        .then(() => this.isBusy = false)
        .catch(() => this.error = "Failed to load data")
        .finally(() => this.isBusy = false);
    }
  };
</script>
