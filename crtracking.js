(function () {

    // Define our constructor
    this.CRTracking = function () {

        var defaults = {
            clientID: '',
            clientURL: ''
        }

        if (arguments[0] && typeof arguments[0] === "object") {
            this.options = extendDefaults(defaults, arguments[0]);
        }

        var deviceInfo = {
            appCodeName: navigator.appCodeName,
            appName: navigator.appName,
            appVersion: navigator.appVersion,
            cookieEnabled: navigator.cookieEnabled,
            geolocation: navigator.geolocation,
            language: navigator.language,
            platform: navigator.platform,
            product: navigator.product,
            userAgent: navigator.userAgent,
            ip: getIP(),
            dateTime: new Date()
        };

        console.log(deviceInfo);

        //postData(JSON.stringify(deviceInfo));
    }

    function extendDefaults(source, properties) {
        var property;
        for (property in properties) {
            if (properties.hasOwnProperty(property)) {
                source[property] = properties[property];
            }
        }
        return source;
    }


    function getIP() {
        try {

            if (window.XMLHttpRequest) xmlhttp = new XMLHttpRequest();

            else xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.open("GET", "https://api.ipify.org?format=json", false);
            xmlhttp.send();

            if (xmlhttp.responseText) {
                return JSON.parse(xmlhttp.responseText).ip;
            }

            return null;
        } catch (e) {
            return null;
        }
    }

    function postData(data) {
        try {

            if (window.XMLHttpRequest) xmlhttp = new XMLHttpRequest();

            else xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.open("POST", "https://www.cartright.pk/php/firebase.php", false);
            xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
            xmlhttp.send(data);

            return null;
        } catch (e) {
            return null;
        }
    }

}());
