"use strict";
// html etiketi adı ile elemente ulaşma. 
let mainElementi = document.getElementsByTagName("main")[0];
console.log(mainElementi)

// yeni bir html elementi tanımladık.  tip: string
let newSection = '<section class="kutu" id="kutu4">KUTU 4</section>';
// main elementinin sonuna yeni elementi ekledik.
mainElementi.innerHTML += newSection;

// id si kutu1 olan elementi getir.
let kutu1Elementi = document.getElementById("kutu1");
kutu1Elementi.innerHTML = "FARKLI KUTU"

kutu1Elementi.style= "background-color:#4475ff;";
