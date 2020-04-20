db = firebase.database().ref('//');

db.on('value',function(data){
    $("#estatus").html(data.val().estatus);
});

