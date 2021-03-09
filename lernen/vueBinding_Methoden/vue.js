new Vue({
    el: '#app',
    data:{
        person: {
            name: 'Luca',
            height: 188
        },
        webseite: 'https://www.google.de/',

        htmlTag: '<a href = https://www.google.de/> Tag aus Vue </a>',
    }, 
    

    methods: {
        sayHi: function() {
            return 'Hallo Welt'
        },
        sayHiWithParams: function(greeting){
            return greeting + this.person.name
        }
    },
});