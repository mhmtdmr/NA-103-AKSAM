        ///////////////////////////////////
        //       Function Expressions  ////
        ///////////////////////////////////
        // Tek satırda fonskiyon tanımlamamızı sağlar.

        // // let sayHello = function(){alert("Hello");}

        // // tanımladık.
        // let sayHello = () => "Hello"
        // let sumExp = (a, b) => a + b; // toplamı döndüren func. exp.

        // sayHello();
        // alert(sumExp(45,45));


        // /////////////////////////////////////
        // ////       maps-sets             ////
        // /////////////////////////////////////

        // let map = new Map();
        // map.set('anahtar','değer');
        // map.set('şehir','şehr-i İstanbul');

        // // alert(map.get('şehir'));
        // alert(map['şehir']);

        // // map.set('şehir','Kütahya'); // yoksa ekler varsa değiştirir.
        
        // for (let key of map.keys())
        // {
        //     console.log(key)
        // }
        // for (let val of map.values())
        // {
        //     console.log(val)
        // }
        // for (let ent of map.entries())
        // {
        //     console.log(ent)
        // }




        /////////////////////////////////////
        ////          objects            ////
        /////////////////////////////////////
        // tanımladık.

        // let user = new Object();
        // let user = {}
        // let user = {
        //     name:"Mehmet",
        //     birthyear:1988,
        //     age:function()
        //     {
        //      return (new Date().getFullYear())-this.birthyear;
        //     },
        //     nativeLang:String()
        // }
        
        // console.log(user.name);
        // console.log(user.age());
        // user.nativeLang = "Turkish";
        // console.log(user.nativeLang);


        // user.isteacher = true; // objeye özellik ekleme
        // console.log(user.isteacher); 

        // delete user.age; // objeden özellik silme
        // console.log(user.age);
        // console.log(user);

        // let ogrenci = "Ahmet";
        // console.log(typeof ogrenci)
        // ogrenci = {
        //     name:"Ahmet",
        //     surname:"Güzelses"
        // }
        // console.log(ogrenci);
        // console.log(typeof user)
        // console.log(typeof ogrenci)
        // console.log(ogrenci["surname"]) // obje özelliğini okuduk
        // console.log(ogrenci.surname)
        // ogrenci.surname="Gürses" // obje özelliğini değiştirdik.
        // console.log(ogrenci.surname)



        // == ve === farkı
        let a = 45;
        let b = "45";
        let checkData = a==b; // Değerler eşitse true
        let checkDataWithType = a===b; // Değerler ve tipler eşitse true
        


        