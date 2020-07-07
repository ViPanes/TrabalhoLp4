let IndexLogin = {

    usuario: "",
    btnLogarOnClick: function() {
        let emailUser = document.getElementById("email").value;
        let senhaUser = document.getElementById("senha").value;

        let dados = {
            email: emailUser,
            senha: senhaUser
        }
        
        var config = {
            method: "POST",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: 'include',
            body: JSON.stringify(dados) 
        };

        fetch("Login/Logar", config)
            .then(function (dadosJson) {
                var obj = dadosJson.json(); //deserializando
                return obj;
            })
            .then(function (dadosObj) {

                console.log(dadosObj);
                document.getElementById("divMsg").innerHTML = dadosObj.msg;
            })
            .catch(function () {

                document.getElementById("divMsg").innerHTML = "ERRO";
            })

    }



}