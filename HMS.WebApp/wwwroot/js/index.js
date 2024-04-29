function GetHelloWorld() {
    // XmlHttpRequest nesnesi oluşturulur.
    var xmlHttpRequest = new XMLHttpRequest();

    //console.log(xmlHttpRequest);

    xmlHttpRequest.onreadystatechange = function () {
        //console.log("ReadyState :" + xmlHttpRequest.readyState + " Status : " + xmlHttpRequest.status);
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("content").innerHTML = this.response;
            //console.log(this.response);
            //console.log(this.responseText);
            //console.log(this.responseType);
            //console.log(this.responseURL);
            //console.log(this.responseXML);
        }
    }

    //xmlHttpRequest.open("GET", "/HelloWorld.txt", true);

    xmlHttpRequest.open("GET", "/Home/GetHelloWorld", true);

    xmlHttpRequest.send();

}

function Karesi() {
    // XmlHttpRequest nesnesi oluşturulur.
    var xmlHttpRequest = new XMLHttpRequest();

    xmlHttpRequest.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("content").innerHTML = this.response;
        }
    }

    var sayi = document.getElementById("deger").value;

    xmlHttpRequest.open("GET", "/Home/Karesi?sayi=" + sayi, true);

    xmlHttpRequest.send();
}

function Login() {
    // XmlHttpRequest nesnesi oluşturulur.
    var xmlHttpRequest = new XMLHttpRequest();

    xmlHttpRequest.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("content").innerHTML = this.response;
        }
    }

    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    var params = "username=" + username + "&password=" + password

    xmlHttpRequest.open("POST", "/Home/Login", true);

    xmlHttpRequest.setRequestHeader('Content-Type', "application/x-www-form-urlencoded");

    xmlHttpRequest.send(params);
}

function Color(element, value) {
    //console.log(element.value);
    //console.log(value);

    // XmlHttpRequest nesnesi oluşturulur.
    var xmlHttpRequest = new XMLHttpRequest();

    xmlHttpRequest.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("ColorContent").innerHTML = this.response;
        }
    }

    xmlHttpRequest.open("GET", "/Home/Color?color=" + value, true);


    xmlHttpRequest.send();
}

function GetModel(value) {
    var xmlHttpRequest = new XMLHttpRequest();

    xmlHttpRequest.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("CarModels").innerHTML = this.response;
        }
    }

    xmlHttpRequest.open("GET", "/Home/CarModels/" + value, true);


    xmlHttpRequest.send();
}