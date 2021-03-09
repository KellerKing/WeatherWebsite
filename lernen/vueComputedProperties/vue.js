new Vue({
    el: '#app',
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