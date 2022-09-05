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