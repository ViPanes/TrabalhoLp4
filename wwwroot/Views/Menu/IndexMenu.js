var IndexMenu = {

    buscarListaMenu: function () {

        var config = {
            method: "GET",
            headers: { "Content-Type": "application/json; charset=utf-8" },
            credentials: 'include',
        };

        fetch("Menu/obterHamburgers", config)
            .then(function (dadosJson) {
                var obj = dadosJson.json();
                return obj;
            })
            .then(function (dadosObj) {

                var hamb = document.getElementById("listaMenu");
                var lista = `<div class="row">`;
                for (var i = 0; i < dadosObj.length; i++) {

                    if (i == dadosObj.length / 2 || i == 0) {
                        lista += `
                        <div class="col-xl-6 col-md-6 col-lg-6">
                            <div class="single_delicious d-flex align-items-center">
                                <div class="thumb">
                                    <img src="/lib/burger/img/burger/${i}.png" alt="">
                                </div>
                                <div class="info">
                                    <h3>${dadosObj[i].nome}</h3>
                                    <h4>${dadosObj[i].categoria}</h4>
                                    <p>${dadosObj[i].descricao}</p>
                                    <span>R$${dadosObj[i].preco}</span>
                                </div>
                            </div>
                        </div>`
                    }
                    else {
                        lista += `
                        <div class="col-md-6 col-lg-6">
                            <div class="single_delicious d-flex align-items-center">
                                <div class="thumb">
                                    <img src="/lib/burger/img/burger/${i}.png" alt="">
                                </div>
                                <div class="info">
                                    <h3>${dadosObj[i].nome}</h3>
                                    <h4>${dadosObj[i].categoria}</h4>
                                    <p>${dadosObj[i].descricao}</p>
                                    <span>R$${dadosObj[i].preco}</span>
                                </div>
                            </div>
                        </div>`
                    }


                }
                lista += `</div>`

                hamb.innerHTML = lista;

            })
            .catch(function () {

                document.getElementById("listaMenu").innerHTML = "ERRO JAVA SCRIPT!";
            })

    },

    buscarOnSelect: function (/*op*/) {
        /*var selecionado = document.getElementById("selectCategoria");
        var op = selecionado.options[selecionado.selectedIndex].text;*/
        var op = document.getElementById("selectCategoria").value;
        console.log(op);

        var config = {
            method: "GET",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: 'include',
        };

        fetch("Menu/obterHamburgers_Categoria?categoria=" + op, config)
            .then(function (dadosJson) {
                var obj = dadosJson.json();
                return obj;
            })
            .then(function (dadosObj) {

                var hamb = document.getElementById("listaMenu");
                var lista = `<div class="row">`;
                for (var i = 0; i < dadosObj.length; i++) {

                    if (i == dadosObj.length / 2 || i == 0) {
                        lista += `
                        <div class="col-xl-6 col-md-6 col-lg-6">
                            <div class="single_delicious d-flex align-items-center">
                                <div class="thumb">
                                    <img src="/lib/burger/img/burger/${i}.png" alt="">
                                </div>
                                <div class="info">
                                    <h3>${dadosObj[i].nome}</h3>
                                    <h4>${dadosObj[i].categoria}</h4>
                                    <p>${dadosObj[i].descricao}</p>
                                    <span>R$${dadosObj[i].preco}</span>
                                </div>
                            </div>
                        </div>`
                    }
                    else {
                        lista += `
                        <div class="col-md-6 col-lg-6">
                            <div class="single_delicious d-flex align-items-center">
                                <div class="thumb">
                                    <img src="/lib/burger/img/burger/${i}.png" alt="">
                                </div>
                                <div class="info">
                                    <h3>${dadosObj[i].nome}</h3>
                                    <h4>${dadosObj[i].categoria}</h4>
                                    <p>${dadosObj[i].descricao}</p>
                                    <span>R$${dadosObj[i].preco}</span>
                                </div>
                            </div>
                        </div>`
                    }


                }
                lista += `</div>`

                hamb.innerHTML = lista;

            })
            .catch(function () {

                document.getElementById("listaMenu").innerHTML = "ERRO JAVA SCRIPT!";
            })

    },


    buscarCategoria: function () {

        var config = {
            method: "GET",
            headers: { "Content-Type": "application/json; charset=utf-8" },
            credentials: 'include',
        };

        fetch("Menu/buscarCategorias", config)
            .then(function (dadosJson) {
                var obj = dadosJson.json();
                return obj;
            })
            .then(function (dadosObj) {

                var selectCategoria = document.getElementById("selectCategoria");
                var opcao = "<option value=''> </option>";
                for (var i = 0; i < dadosObj.length; i++) {
                    opcao += `<option value="${dadosObj[i]}">   ${dadosObj[i]}   </option>`;
                }

                selectCategoria.innerHTML = opcao;

            })
            .catch(function () {

                document.getElementById("divMsg").innerHTML = "ERRO JAVA SCRIPT!";
            })

    },


}
IndexMenu.buscarCategoria();
IndexMenu.buscarListaMenu()