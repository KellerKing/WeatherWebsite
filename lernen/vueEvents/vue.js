new Vue({
    el: '#app',
    data:{
        someValue: 32,
    }, 
    

    methods: {
        add: function() {
            this.someValue++;
        }
    },
});