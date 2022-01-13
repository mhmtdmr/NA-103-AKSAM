"use strict";
// html etiketi adı ile elemente ulaşma. 
let mainElementi = document.getElementsByTagName("main")[0];
console.log(mainElementi);

// yeni bir html elementi tanımladık.  tip: string
let newSection = '<section class="kutu" id="kutu4">KUTU 4</section>';
// main elementinin sonuna yeni elementi ekledik.
mainElementi.innerHTML += newSection;

// id si kutu1 olan elementi getir.
let kutu1Elementi = document.getElementById("kutu1");
kutu1Elementi.innerHTML = "FARKLI KUTU";
kutu1Elementi.style= "background-color:#4475ff;";

// id si kutu2 olan elemente css sınıfı ekleme.
let kutu2Elementi = document.getElementById("kutu2");
kutu2Elementi.classList.add("kutuFark");

// id si kutu3 olan elementin css sınıfını silme.içeriğini değiştirme.
let kutu3Elementi = document.getElementById("kutu3");
kutu3Elementi.classList.remove("kutu");
kutu3Elementi.innerHTML = "KUTU<br/>DEĞİLİM<br/>BEN!!!";

let sayac = 0;
let sayacGoster = document.querySelector("section#kutu2 h3");
sayacGoster.innerHTML=sayac;

let sayacArtir = function(artis=1)
{
    // alert("ÇALIŞTIM");
    sayac = sayac+artis;
    sayacGoster.innerHTML = sayac;
}   
// Bir section içerisinde 20 tane buton tanımlayınız.
// her buton

"<button onclick='sayiGoster("+i+")') >"+i+"</button>"

