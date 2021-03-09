let vOne = new Vue({
    el: '#vue-one-app',
    data:{
        firstname: '',
        lastname: '',
        names: ['Florian','Gustav', 'Peter'],
        persons: [
            {name: 'Florian', age: 21},
            {name: 'Gustav', age: 51},
        ]
    }, 
    

    methods: {
    },

    computed:{
        fullname(){
            return `${this.firstname} ${this.lastname}`;
        }
    }
});


let vTwo = new Vue({
    el: '#vue-two-app',

    data: {
        string2: 'Hallo aus Vue Instance Nr 2'
    },

    methods: {
        changeData(){
            vOne.firstname = "Click wurde gesetzt";
        },
    },

});