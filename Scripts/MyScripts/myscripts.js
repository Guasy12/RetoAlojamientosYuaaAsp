
$(function () {
    $('[id*=fechaInicio]').datepicker({
        startDate: new Date(),
        changeMonth: true,
        changeYear: true,
        format: "dd/mm/yyyy",
        language: "es"
    }).on('changeDate', function (selected) {
        var minDate = new Date(selected.date.valueOf());
        $('#fechaFin').datepicker('setStartDate', minDate);
    });

});
$(function () {
    $('[id*=fechaFin]').datepicker({
        changeMonth: true,
        changeYear: true,
        format: "dd/mm/yyyy",
        language: "es"
    });
});

$(function () {
    $('#tbFechaNacimiento').datepicker({
        startDate: '-100y',
        changeMonth: true,
        changeYear: true,
        yearRange: "1950:2015",
        format: "dd/mm/yyyy",
        language: "es"
    });
});
