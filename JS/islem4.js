function Topla(s1,s2)
{
    return Number(s1)+Number(s2);
}

function Cikar(s1,s2)
{
    return Number(s1)-Number(s2);
}

function Carp(s1,s2)
{
    return Number(s1)*Number(s2);
}
function Bol(s1,s2=1) // s2 varsayılan olarak 2
{
    if(s2!=0)
    {
        return Number(s1)/Number(s2);
    }
    else
    {
        return false;
    }
}

let s1 = prompt("s1:","");
let s2 = prompt("s2:","");
let sayilar = [s1,s2];

for(let i=0;i<sayilar.length-1;i++)
{
    console.log(Topla(sayilar[i],sayilar[i+1]));
}
