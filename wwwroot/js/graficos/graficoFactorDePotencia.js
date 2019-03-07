var canvas = document.getElementById("graficoFactorDePotencia");
var ctx = canvas.getContext('2d');

// Global Options:
Chart.defaults.global.defaultFontColor = 'white';
Chart.defaults.global.defaultFontSize = 16;

// Data with datasets options
var data = {
    labels: ["1Feb", "2Feb", "3Feb", "4Feb", "5Feb", "6Feb", "7Feb"],
    datasets: [{
            label: "Fase R",
            fill: true,
            borderColor: "lime",
            data: [0.1, 0.0, 0.2, 0.3, 0.1, 0.5, 0.2],
        },
        {
            label: "Fase S",
            fill: true,
            borderColor: "lightblue",
            data: [0.2, 0.4, 0.1, 0.1, 0.2, 0.7, 0.4],
        },
        {
            label: "Fase T",
            fill: true,
            borderColor: "tomato",
            data: [0.5, 0.3, 0.2, 0.1, 0.7, 0.6, 0.5],
        }
    ]



};
// Chart declaration with some options:
var myFirstChart = new Chart(ctx, {
    type: 'line',
    data: data,
    options: {
        title: {
            fontSize: 20,
            display: true,
            text: 'Factor de Potencia'
        }
    }
})