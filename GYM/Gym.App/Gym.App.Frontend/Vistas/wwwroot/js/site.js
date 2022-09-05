// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

//Javascript Jesus para formulario
var array = document.getElementsByClassName('formularioInput');
for (var i = 0; i < array.length; i++){
    array[i].addEventListener('keyup', function(){
        if (this.value.length >= 1){
            this.nextElementSibling.classList.add('fijar');
        } else{
            this.nextElementSibling.classList.remove('fijar');
        }
    }); 
}