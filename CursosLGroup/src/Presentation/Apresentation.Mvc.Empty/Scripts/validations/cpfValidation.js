
//Aqui iremos criar metodos de validação
//usando jquery.validator
//$ => jquery
//Valor => valor do input
//element => Dom
//param => Parametros passados via servidor
//O metodo irá validar o Cpf para cada evento de teclado
$.validator.addMethod("cpfvalidation", function (valor, element, param) {
    return validaCPF(valor);
});

$.validator.unobtrusive.adapters.addBool("cpfvalidation"); //inicializador do addMethod.  

function validaCPF(s) {
    var i;
    var l = '';
    for (i = 0; i < s.length; i++) if (!isNaN(s.charAt(i))) l += s.charAt(i);
    s = l;
    if (s.length != 11) return false;
    var c = s.substr(0, 9);
    var dv = s.substr(9, 2);
    var d1 = 0;
    for (i = 0; i < 9; i++) d1 += c.charAt(i) * (10 - i);
    if (d1 == 0) return false;
    d1 = 11 - (d1 % 11);
    if (d1 > 9) d1 = 0;
    if (dv.charAt(0) != d1) return false;
    d1 *= 2;
    for (i = 0; i < 9; i++) d1 += c.charAt(i) * (11 - i)
    d1 = 11 - (d1 % 11);
    if (d1 > 9) d1 = 0;
    if (dv.charAt(1) != d1) return false;
    return true;
}