<template>
  <div class="col-8 offset-2">
    <router-link class="btn btn-secondary btn-sm" to="/">&lt; Back</router-link>
    <h1>New Customer</h1>
    <div class="alert alert-warning" v-if="error">{{ error }}</div>
    <div v-if="isBusy">Loading...</div>
    <form novalidate @submit.prevent="onSave()">
      <div class="form-group">
        <label for="companyName">Company</label>
        <input type="text" name="companyName" class="form-control" v-model="customer.companyName" />
      </div>
      <div class="form-group">
        <label for="contactName">Contact</label>
        <input type="text" name="contactName" class="form-control" v-model="customer.contactName" />
      </div>
      <div class="form-group">
        <label for="phone">Phone</label>
        <input type="text" name="phone" class="form-control" v-model="customer.phone" />
      </div>
      <div class="form-group">
        <label for="addressLine1">Address</label>
        <input type="text" name="addressLine1" class="form-control" v-model="customer.addressLine1" />
      </div>
      <div class="form-group">
        <label for="addressLine2"></label>
        <input type="text" name="addressLine2" class="form-control" v-model="customer.addressLine2" />
      </div>
      <div class="form-group">
        <label for="cityTown">City/Town</label>
        <input type="text" name="cityState" class="form-control" v-model="customer.cityTown" />
      </div>
      <div class="form-group">
        <label for="stateProvince">State/Province</label>
        <input type="text" name="stateProvince" class="form-control" v-model="customer.stateProvince" />
      </div>
      <div class="form-group">
        <label for="postalCode">Postal Code</label>
        <input type="text" name="postalCode" class="form-control" v-model="customer.postalCode" />
      </div>
      <div class="form-group">
        <label for="country">Country</label>
        <select name="country" class="form-control" v-model="customer.country" >
          <option selected>United States</option>
          <option>Canada</option>
        </select>
      </div>
      <div class="form-group">
        <input type="submit" class="btn btn-success" value="Save"/>
        <router-link class="btn btn-secondary" to="/">Cancel</router-link>
      </div>
    </form>
  </div>
</template>
<script>
  export default {
    data() {
      return {
        customer: {},
        error: "",
        isBusy: false
      };
    },
    mounted() {

    },
    methods: {
      onSave() {
        this.isBusy = true;
        this.$store.dispatch("addCustomer", this.customer)
          .then(() => this.$router.push("/"))
          .catch(() => this.error = "Failed to save")
          .finally(() => this.isBusy = false);
      }
    }
  }
</script>