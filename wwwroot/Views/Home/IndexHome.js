var IndexHome = {

    buscarListaMenuHome: function () {

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
                for (var i = 0; i < 4; i++) {

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

    }


}
IndexHome.buscarListaMenuHome();