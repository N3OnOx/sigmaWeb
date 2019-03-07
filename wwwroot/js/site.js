function mostrarHora() {
    momentoActual = new Date()
    hora = momentoActual.getHours()
    minuto = momentoActual.getMinutes()
    segundo = momentoActual.getSeconds()

    horaImprimible = hora + ":" + minuto + ":" + segundo

    document.getElementById("hora").innerHTML = horaImprimible;

    setTimeout("mostrarHora()", 1000)
}