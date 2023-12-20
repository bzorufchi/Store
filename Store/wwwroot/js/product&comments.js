//$(document).ready(
//	function () {
//		GetShowSingleProduct(parseInt(window.location.pathname.split('/')[2]))
//		GetProductComments(parseInt(window.location.pathname.split('/')[2]))
//    }
//)
//function GetShowSingleProduct(count){
//var param={

//}
//callAjax('Product/GetShowSingleProducts',count,afterShowSingleProduct,param,'post')
//}
//function afterShowSingleProduct(param){
//var resultp="";

//	resultp += `<div style="width: 50%;" class="">
//		<img class="mt-5" src="/axstore/${param.serverResponse.imageURL}" style="border-radius: 5px;margin-right:15%;width:50%;height:50vh;">
//		</div>
//		<div style="width: 50%;" class="mt-5">
//				<p>نام محصول :${param.serverResponse.productName} </p>
//				<p>اطلاعات محصول :${param.serverResponse.productDescription} </p>
//				<p>قیمت محصول : ${param.serverResponse.orginalPrice}</p>
//				<p>قیمت تخفیف :${param.serverResponse.discountPrice} </p>
//				<p>کشور :${param.serverResponse.countryId} </p>
//				<p>برند : ${param.serverResponse.brandId}</p>
//				<p>دسته بندی محصول : ${param.serverResponse.categoryId}</p>
//				<p>موجود :${param.serverResponse.isActive} </p>
//				<p>تعداد : ${param.serverResponse.count}</p>
//				<p class="mb-5">پسندیده شده: ${param.serverResponse.Like}</p>
//				<a href="#" class="bg-success text-white pt-2 pb-2 ps-4 pe-4  rounded rounded-2" style="font-size:12px;"><img class="ms-2" width="20" height="20"  src="https://img.icons8.com/ios-filled/50/FFFFFF/plus.png" alt="plus"/>افزودن به سبد خرید</a>
//			</div>`

//document.getElementById('singleproduct').innerHTML = resultp
//}
//function GetProductComments(ProductId){
//var param={

//}
//callAjax('Comments/GetProductComments',ProductId,afterGetProductComments,param,'post')
//}
//function afterGetProductComments(param){
//var Comments=` <h5 class="me-5 mt-5 text-primary">نظرات کاربران درباره این محصول</h5>
//`;
//for(var i=0;i<param.serverResponse.length;i++){
//	if(i%2==0){
//		Comments +=`<div class="mt-4 me-3 bg-light pt-3 pb-3">
//		<h6 class="mt-3 me-4" style="color: #45526e;">نام کاربری :${param.serverResponse[i].username}  </h6>
//		<p class="mt-3 me-4" style="font-size: 13px;">نظر : ${param.serverResponse[i].text}</p>
//	</div> `
//	}
//	else{
//		Comments +=` <div class="mt-4 me-3 bg-white pt-3 pb-3">
//		<h6 class="mt-3 me-4" style="color: #45526e;">نام کاربری :${param.serverResponse[i].username}  </h6>
//		<p class="mt-3 me-4" style="font-size: 13px;">نظر : ${param.serverResponse[i].text}</p>
//	</div>`
//	}
//}
//Comments += `
//<div>
//    <h5 class="me-4 mt-4">ثبت نظر توسط شما</h5>
//    <!-- <label class="me-3 mt-3">ایمیل</label>
//        <input id="emailticket" type="text"  style="width:22%"> -->
//    <form action="" class="mt-2 me-3 bg-white pt-3 pb-3">
//        <textarea id="text" name="text" rows="4" cols="70"></textarea>
//        <br>
//        <a class="mt-2 me-2 pt-2 pb-2 ps-4 pe-4 bg-success text-white rounded rounded-2" type="submit"  style="border: none;"onclick="addcomment()">ثبت نظر</a>
//</div>
//`
//document.getElementById('comments').innerHTML=Comments



//}

//function addcomment(){
//	var comment=document.getElementById('text').value
//	var param={

//	  }
//	var input={
//		Text:comment,
//		UserId:4,
//		ProductId: parseInt(window.location.pathname.split('/')[2])
//	}
//	callAjax("Comments/Addcomments",input,afteraddcomments,param,"POST")
//	}

//function afteraddcomments(param){
//	if(param.serverResponse==true){
//		location.reload()
//	}
//	else{
//		Swal.fire("متاسفانه نظر شما ثبت نشد");
//	}
//}

var productid = 0;
var userid = 0;
$(document).ready(


	function () {
		userid = parseInt(localStorage.getItem("userid"));
		if (isNaN(userid) || userid == undefined) {userid=0 }
	productid = parseInt(window.location.pathname.split('/')[2])
		GetShowSingleProduct(productid)
		GetProductComments(productid)
	}
)

function GetShowSingleProduct(count) {
	var param = {

	}
	callAjax('Product/GetShowSingleProducts', count, afterShowSingleProduct, param, 'post')
}
var productName = "";
function afterShowSingleProduct(param) {
	var resultp = "";

	resultp += `<div style="width: 50%;" class="">
		<img class="mt-5" src="/axstore/${param.serverResponse.imageURL}" style="border-radius: 5px;margin-right:15%;width:60%;height:60vh;">
		</div>
		<div style="width: 50%;" class="mt-5">
				<p style="font-size:13px;">نام محصول :${param.serverResponse.productName} </p>
				<p style="font-size:13px;">اطلاعات محصول :${param.serverResponse.productDescription} </p>
				<p style="font-size:13px;">قیمت محصول : ${param.serverResponse.orginalPrice}</p>
				<p style="font-size:13px;">قیمت تخفیف :${param.serverResponse.discountPrice} </p>
				<p style="font-size:13px;">کشور :${param.serverResponse.countryId} </p>
				<p style="font-size:13px;">برند : ${param.serverResponse.brandId}</p>
				<p style="font-size:13px;">دسته بندی محصول : ${param.serverResponse.categoryId}</p>
				<p style="font-size:13px;">موجود :${param.serverResponse.isActive} </p>
				<p style="font-size:13px;">تعداد : ${param.serverResponse.count}</p>
				<p  style="font-size:13px;"class="mb-5">پسندیده شده: ${param.serverResponse.Like}</p>
				<a  onclick="InsertShoppingCard(${productid})" class=" text-white pt-2 pb-2 ps-4 pe-4  rounded rounded-2" style="font-size:12px;background-color: #FF414D;
				"><img class="ms-2" width="20" height="20"  
				src="https://img.icons8.com/ios-filled/50/FFFFFF/plus.png"  alt="plus"/>افزودن به سبد خرید</a>
			</div>`
	productName = param.serverResponse.productName;
	document.getElementById('singleproduct').innerHTML = resultp
}

function GetProductComments(ProductId) {
	var param = {

	}
	callAjax('Comments/GetProductComments', ProductId, afterGetProductComments, param, 'post')
}
function afterGetProductComments(param) {
	var Comments = ` <h6 class="me-5 mt-5" style="color:#4FB783">نظرات کاربران درباره این محصول</h6>
`;
	for (var i = 0; i < param.serverResponse.length; i++) {
		if (i % 2 == 0) {
			Comments += `<div class="mt-4 me-3  pt-3 pb-3" style="background-color: #C8E6F5;">
		<h6 class="mt-3 me-4" style="color: #45526e;">نام کاربری :${param.serverResponse[i].username}  </h6>
		<p class="mt-3 me-4" style="font-size: 13px;">نظر : ${param.serverResponse[i].text}</p>
	</div> `
		}
		else {
			Comments += ` <div class="mt-4 me-3 bg-white pt-3 pb-3">
		<h6 class="mt-3 me-4" style="color: #45526e;">نام کاربری :${param.serverResponse[i].username}  </h6>
		<p class="mt-3 me-4" style="font-size: 13px;">نظر : ${param.serverResponse[i].text}</p>
	</div>`
		}
	}
	Comments += `
<div>
    <h5 class="me-4 mt-4" style="color: #7F78D2;">ثبت نظر توسط شما</h5>
    <!-- <label class="me-3 mt-3">ایمیل</label>
        <input id="emailticket" type="text"  style="width:22%"> -->
    <form action="" class="mt-2 me-3 bg-white pt-3 pb-3">
        <textarea id="text" name="text" rows="4" cols="70"></textarea>
        <br>
        <a class="mt-2 me-2 pt-2 pb-2 ps-4 pe-4 text-white rounded rounded-2" style="background-color: #07A4B5;" type="submit"  style="border: none;"onclick="addcomment()">ثبت نظر</a>
</div>
`
	document.getElementById('comments').innerHTML = Comments
}
function InsertShoppingCard(productId) {

	if (userid < 1) {
		Swal.fire("لطفا لاگین کنید");
		return;
	}

	var param = {

	}
	var input = {
		ProductId: productId,
		UserId: userid
	}
	callAjax("Orders/InsertOrderToShppoingCard", input, afterInsertShoppingCard, param, "POST")
}
function afterInsertShoppingCard(param) {
	console.log(param);
	//if (param.serverResponse == true) {
	//	swal.fire("محصول با موفقیت به سبد خرید شما اضافه شد.");
	//}
	//else {
	//	swal.fire("محصول به سبد خرید اضافه نشد!مجدد تلاش کنید.");

	//}
	if (param.serverResponse == true) {
		swal.fire(` ${productName} با موفقیت به سبد خرید شما اضافه شد.`);
	}
	else {
		swal.fire("محصول به سبد خرید اضافه نشد!مجدد تلاش کنید.");
	}

}
function addcomment() {
	var comment = document.getElementById('text').value

	if (comment.length < 4) {
		Swal.fire("متن کامنتی بگذارید");
		return;
	}

	if (userid < 1) {
		Swal.fire("لطفا لاگین کنید");
		return;
	}

	var param = {

	}
	var input = {
		Text: comment,
		UserId: userid,
		ProductId: productid
	}
	callAjax("Comments/Addcomments", input, afteraddcomments, param, "POST")
}

function afteraddcomments(param) {
	if (param.serverResponse == true) {
		location.reload()
	}
	else {
		Swal.fire("متاسفانه نظر شما ثبت نشد");
	}
}