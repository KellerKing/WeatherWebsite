let vOne = new Vue({
    el: '#app',
    data:{
        username: '', //2 way
        password: '',
        feedback: ' ',

        users: [
            {name: 'Bruno', password: 'Java'},
            {name: 'Klaus', password: 'Cisco'},
            {name: 'Hackerman', password: '123456'},
        ]
    }, 
    

    methods: {
        checkPassword(password) {
          return this.users.filter((user) => password === user.password);
        },
        checkUsername(username){
            return this.users.filter(user => user.name === username);
        },

        checkCredentials(event) {
          event.preventDefault();
          if (this.checkUsername(this.username) && this.checkPassword(this.password).length !== 0) {
            alert('Erfolgreich eingeloggt');
          } else {
            alert('Kein erfolg beim eingeloggen');
          }
        },
      },
    });