
    const data = {
        labels: ["January", "February", "March", "April", "May", "June"],
        datasets: [
            {
                label: "Sales",
                backgroundColor: "rgba(255, 99, 132, 0.2)",
                borderColor: "rgba(255, 99, 132, 1)",
                borderWidth: 1,
                hoverBackgroundColor: "rgba(255, 99, 132, 0.4)",
                hoverBorderColor: "rgba(255, 99, 132, 1)",
                data: [65, 59, 80, 81, 56, 55]
            }
        ]
    };

    const options = {
        scales: {
            yAxes: [
                {
                    ticks: {
                        beginAtZero: true
                    }
                }
            ]
        }
    };

     const ctx = document.getElementById("myChart").getContext("2d");
        const myChart = new Chart(ctx, {
          type: "line",
          data: data,
          options: options
        });

