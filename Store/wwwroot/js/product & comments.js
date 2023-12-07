$(document).ready(
	function () {
		GetShowSingleProduct(parseInt(window.location.pathname.split('/')[2]))
		GetProductComments(parseInt(window.location.pathname.split('/')[2]))
    }
)
function GetShowSingleProduct(count){
var param={

}
callAjax('Product/GetShowSingleProducts',count,afterShowSingleProduct,param,'post')
}
function afterShowSingleProduct(param){
var resultp="";
  
	resultp += `<div style="width: 50%;" class="">
		<img class="mt-5" src="/axstore/${param.serverResponse.imageURL}" style="border-radius: 5px;margin-right:15%;width:50%;height:50vh;">
		</div>
		<div style="width: 50%;" class="mt-5">
				<p>نام محصول :${param.serverResponse.productName} </p>
				<p>اطلاعات محصول :${param.serverResponse.productDescription} </p>
				<p>قیمت محصول : ${param.serverResponse.orginalPrice}</p>
				<p>قیمت تخفیف :${param.serverResponse.discountPrice} </p>
				<p>کشور :${param.serverResponse.countryId} </p>
				<p>برند : ${param.serverResponse.brandId}</p>
				<p>دسته بندی محصول : ${param.serverResponse.categoryId}</p>
				<p>موجود :${param.serverResponse.isActive} </p>
				<p>تعداد : ${param.serverResponse.count}</p>
				<p class="mb-5">پسندیده شده: ${param.serverResponse.Like}</p>
				<a href="#" class="bg-success text-white pt-2 pb-2 ps-4 pe-4  rounded rounded-2" style="font-size:12px;"><img class="ms-2" width="20" height="20"  src="https://img.icons8.com/ios-filled/50/FFFFFF/plus.png" alt="plus"/>افزودن به سبد خرید</a>
			</div>`

document.getElementById('singleproduct').innerHTML = resultp
}
function GetProductComments(ProductId){
var param={

}
callAjax('Comments/GetProductComments',ProductId,afterGetProductComments,param,'post')
}
function afterGetProductComments(param){
var Comments=` <h5 class="me-5 mt-5 text-primary">نظرات کاربران درباره این محصول</h5>
`;
for(var i=0;i<param.serverResponse.length;i++){
	if(i%2==0){
		Comments +=`<div class="mt-4 me-3 bg-light pt-3 pb-3">
		<h6 class="mt-3 me-4" style="color: #45526e;">نام کاربری :${param.serverResponse[i].username}  </h6>
		<p class="mt-3 me-4" style="font-size: 13px;">نظر : ${param.serverResponse[i].text}</p>
	</div> `
	}
	else{
		Comments +=` <div class="mt-4 me-3 bg-white pt-3 pb-3">
		<h6 class="mt-3 me-4" style="color: #45526e;">نام کاربری :${param.serverResponse[i].username}  </h6>
		<p class="mt-3 me-4" style="font-size: 13px;">نظر : ${param.serverResponse[i].text}</p>
	</div>`
	}
}
Comments += `
<div>
    <h5 class="me-4 mt-4">ثبت نظر توسط شما</h5>
    <!-- <label class="me-3 mt-3">ایمیل</label>
        <input id="emailticket" type="text"  style="width:22%"> -->
    <form action="" class="mt-2 me-3 bg-white pt-3 pb-3">
        <textarea id="text" name="text" rows="4" cols="70"></textarea>
        <br>
        <a class="mt-2 me-2 pt-2 pb-2 ps-4 pe-4 bg-success text-white rounded rounded-2" type="submit"  style="border: none;"onclick="addcomment()">ثبت نظر</a>
</div>
`
document.getElementById('comments').innerHTML=Comments



}

function addcomment(){
	var comment=document.getElementById('text').value
	var param={

	  }
	var input={
		Text:comment,
		UserId:4,
		ProductId: parseInt(window.location.pathname.split('/')[2])
	}  
	callAjax("Comments/Addcomments",input,afteraddcomments,param,"POST")
	}
	
function afteraddcomments(param){
	if(param.serverResponse==true){
		location.reload()
	}
	else{
		Swal.fire("متاسفانه نظر شما ثبت نشد");
	}
}