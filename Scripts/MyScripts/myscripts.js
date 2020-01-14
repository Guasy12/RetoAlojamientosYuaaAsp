$(function () {
    $('[id*=fechaInicio]').datepicker({
        changeMonth: true,
        changeYear: true,
        format: "dd/mm/yyyy",
        language: "es"
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