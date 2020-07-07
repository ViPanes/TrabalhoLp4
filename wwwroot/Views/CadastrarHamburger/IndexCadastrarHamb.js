var IndexCadastrarHamb = {

    btnCadastrarOnClick: function () {

        var nomeProd = document.getElementById("nomeProd").value;
        var descricaoProd = document.getElementById("descricao").value;
        var precoProd = document.getElementById("preco").value;
        var selecionado = document.getElementById("selectCategoria");
        var categoriaProd = selecionado.options[selecionado.selectedIndex].text;

        if (nomeProd.trim() == "") {
            document.getElementById("divMsg").innerHTML = "Informe o nome!";
        }
        else
            if (descricaoProd.trim() == "") {

                document.getElementById("divMsg").innerHTML = "Descreva o produto!";
            }
            else
                if (precoProd.trim() == "") {

                    document.getElementById("divMsg").innerHTML = "Informe o preço!";
                }
                else {

                    var dados = {
                        nomeProd,
                        descricaoProd,
                        precoProd,
                        categoriaProd
                    }

                    var config = {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json; charset=utf-8"
                        },
                        credentials: 'include',
                        body: JSON.stringify(dados) 
                    };

                    fetch("CadastrarHamburger/Inserir", config)
                        .then(function (dadosJson) {
                            var obj = dadosJson.json();
                            return obj;
                        })
                        .then(function (dadosObj) {

                            if (!dadosObj.operacao) {
                                document.getElementById("divMsg").innerHTML = dadosObj.msg;
                            }
                            else {
                                var id = dadosObj.id;

                                var fd = new FormData();
                                fd.append("foto", document.getElementById("foto").files[0]);
                                fd.append("id", id);

                                var configFD = {
                                    method: "POST",
                                    headers: {
                                        "Accept": "application/json"
                                    },
                                    body: fd
                                }

                                fetch("CadastrarHamburger/Foto", configFD)
                                    .then(function (dadosJson) {
                                        var obj = dadosJson.json();
                                        return obj;
                                    })
                                    .then(function (dadosObj) {
                                        document.getElementById("divMsg").innerHTML = "CADASTRO COMPLETO!";
                                    })
                                    .catch(function () {

                                        document.getElementById("divMsg").innerHTML = "Erro na Foto!";
                                    })
                            }
                        })
                        .catch(function () {

                            document.getElementById("divMsg").innerHTML = "ERRO JS!";
                        })
                }
    },

    buscarCategoria: function () {

        var config = {
            method: "GET",
            headers: { "Content-Type": "application/json; charset=utf-8" },
            credentials: 'include',
        };

        fetch("CadastrarHamburger/buscarCategorias", config)
            .then(function (dadosJson) {
                var obj = dadosJson.json(); 
                return obj;
            })
            .then(function (dadosObj) {

                var selectCategoria = document.getElementById("selectCategoria");
                var opcao = "<option value=''></option>";
                for (var i = 0; i < dadosObj.length; i++)
                {
                    opcao += `<option value="${dadosObj[i]}">   ${dadosObj[i]}   </option>`;
                }

                selectCategoria.innerHTML = opcao;

            })
            .catch(function () {

                document.getElementById("divMsg").innerHTML = "ERRO JAVA SCRIPT!";
            })

    }


}
IndexCadastrarHamb.buscarCategoria();