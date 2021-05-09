<template>
  <v-toolbar
    dark
    color="teal"
  >
    <v-toolbar-title>State selection</v-toolbar-title>
    <v-autocomplete
      v-model="select"
      :loading="loading"
      :items="test"
      item-text="ort"
      :search-input.sync="search"
      cache-items
      class="mx-4"
      flat
      hide-no-data
      hide-details
      label="What state are you from?"
      solo-inverted
    ></v-autocomplete>
    <v-btn icon>
      <v-icon>mdi-dots-vertical</v-icon>
    </v-btn>
  </v-toolbar>
</template>

<script>
export default {
  data() {
    return {
      orte: [],
      test: [
  {
    "ort": "Bruchsal",
    "gemeinde": "Bruchsal"
  },
  {
    "ort": "Büchenau",
    "gemeinde": "Bruchsal"
  },
  {
    "ort": "Fasanenhof",
    "gemeinde": "Bruchsal"
  },
  {
    "ort": "Heidelsheim",
    "gemeinde": "Bruchsal"
  },
  {
    "ort": "Helmsheim",
    "gemeinde": "Bruchsal"
  },
  {
    "ort": "Obergrombach",
    "gemeinde": "Bruchsal"
  },
  {
    "ort": "Untergrombach",
    "gemeinde": "Bruchsal"
  },
  {
    "ort": "Stettfeld",
    "gemeinde": "Ubstadt-Weiher"
  },
  {
    "ort": "Ubstadt",
    "gemeinde": "Ubstadt-Weiher"
  },
  {
    "ort": "Weiher",
    "gemeinde": "Ubstadt-Weiher"
  },
  {
    "ort": "Zeutern",
    "gemeinde": "Ubstadt-Weiher"
  }
]
    }
  },


  created() {
    console.log(this.test);
       //fetch("https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords=ama&apikey={DB9GOPC6V9FBZ77N")
      //.then(response =>{
      //  this.orte = response.data;
      //  console.log(response.data);
      //  console.log(3);
      //  });

    var xmlHttp = new XMLHttpRequest();
    xmlHttp.onreadystatechange = function() { 
      if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
        this.orte = JSON.parse(xmlHttp.responseText).bestMatches;
        console.log(xmlHttp.responseText);
        }
    }
      xmlHttp.open("GET", "https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords=ama&apikey={DB9GOPC6V9FBZ77N", false); // true for asynchronous 
      xmlHttp.send(null);
  }
};


</script>