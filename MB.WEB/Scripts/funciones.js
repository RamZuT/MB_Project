function mostrarTipoCambio(elemento) {
    if (elemento.value == 1) {
    mostrar();
    } else if (elemento.value == 2 || elemento.value == '') {
    ocultar();
    }
}
function mostrar() {
    document.getElementById('hidden').style.display = "block";
}

function ocultar() {
    document.getElementById('hidden').style.display = "none";
}
