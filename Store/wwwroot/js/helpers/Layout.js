$(document).ready(function () {
    var roleid = localStorage.getItem("roleid");
    var time = localStorage.getItem("time");
    var userid = localStorage.getItem("userid");

    if (new Date(time) < new Date()) {
        document.getElementById('logout').style.display = 'block'
        document.getElementById('login').style.display = 'none'
        document.getElementById('login2').style.display = 'none'
        document.getElementById("adminpanel").style.display = 'none'
        localStorage.removeItem("roleid");
        localStorage.removeItem("time");
        localStorage.removeItem("userid");
    }
    else {
        document.getElementById('logout').style.display = 'none'
        document.getElementById('login').style.display = 'block'
        document.getElementById('login2').style.display = 'block'
        var settings = {
            "url": "http://localhost:5208/api/User/GetUserFullName",
            "method": "POST",
            "timeout": 0,
            "headers": {
                "Content-Type": "application/json"
            },
            "data": JSON.stringify({
                "Id": parseInt(localStorage.getItem("userid"))
            }),
        };

        $.ajax(settings).done(function (response) {
            document.getElementById("fullname").innerText = response + ' خوش آمدید'
        });
        if (roleid == 1) {
            document.getElementById("adminpanel").style.display = 'block'
        } else {
            document.getElementById("adminpanel").style.display = 'none'

        }
    }
});
function logout() {
    localStorage.removeItem("roleid");
    localStorage.removeItem("time");
    localStorage.removeItem("userid");
    window.location.reload()
}