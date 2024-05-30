
$(document).ready(function () {
    var dataToSend = [];
    var table = $('#tbDetails').DataTable({
        language: {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": " _START_ a _END_ de _TOTAL_",
            "infoEmpty": "",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": " _MENU_ ",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
    })

    $('#addButton').on('click', function () {
        var dayDuration = $('#DayDuration').val();
        var priceDay = $('#PriceDay').val();
        var rentalDeposit = $('#RentalDeposit').val();
        var idCar = $('#IdCar option:selected').text();
        var idInvoice = $('#IdInvoice').val();

        table.row.add([
            dayDuration,
            priceDay,
            rentalDeposit,
            idCar,
            idInvoice
        ]).draw(false);
    });



    $('#submit-button').on('click', function () {
        table.rows().every(function () {
            var rowData = this.data();
            dataToSend.push(rowData);
        });

        $.ajax({
            type: "POST",
            url: "./Create",
            contentType: "application/json",
            data: JSON.stringify({ TbInvoiceDetails: dataToSend }),
            success: function (response) {
                alert("Data successfully sent to the server!");
                // Handle success response
            },
            error: function (error) {
                console.log(error);
                // Handle error response
            }
        });
    });
});
