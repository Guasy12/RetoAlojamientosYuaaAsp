
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
    }).on('changeDate', function (selected) {
        var maxDate = new Date(selected.date.valueOf());
        $('#fechaInicio').datepicker('setEndDate', maxDate);
    });
});

$(function () {
    $('[id*=tbFechaNacimiento]').datepicker({
        startDate: new Date('01/01/1990'),
        changeMonth: true,
        changeYear: true,
        yearRange: "-100:+100",
        format: "dd/mm/yyyy",
        language: "es"
    });
});
