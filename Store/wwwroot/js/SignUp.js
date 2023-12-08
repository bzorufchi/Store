$(document).ready(function () {
	$(".veen .rgstr-btn button").click(function () {
		$('.veen .wrapper').addClass('move');
		
		$(".veen .login-btn button").removeClass('active');
		$(this).addClass('active');
	});
	$(".veen .login-btn button").click(function () {
		$('.veen .wrapper').removeClass('move');
		
		$(".veen .rgstr-btn button").removeClass('active');
		$(this).addClass('active');
	});
});

function Login(){
	var username=document.getElementById('username').value
	var password=document.getElementById('password').value
	var param={}
	var input={
		UserName:username,
		Password:password
	}
	callAjax("User/Login",input,AfterLogin,param,"POST")
}
function AfterLogin(param) {
	if (param.serverResponse.userid > 0) {
		localStorage.setItem('userid', param.serverResponse.userid);
		localStorage.setItem('roleid', param.serverResponse.roleId);
		localStorage.setItem('time', param.serverResponse.expTime);
		location.replace('/');
	}
	else {
		Swal.fire("ورود نامعتبر");
	}
}

function Register(){
	var name=document.getElementById('name').value
	var familyname=document.getElementById('familyname').value
	var phonenumber=document.getElementById('phonenumber').value
	var username=document.getElementById('usernameregister').value
	var password=document.getElementById('passwordregister').value
	var param={}
	var input={
		FirstName:name,
		FamilyName:familyname,
		PhoneNumber:phonenumber,
		UserName:username,
		Password:password
	}
	callAjax("User/AddUser",input,AfterRegister,param,"POST")
}
function AfterRegister(param){
	if (param.serverResponse == true) {
        alert("با موفقیت ثبت شد");
    } else {
        alert("ناموفق");
    }
}