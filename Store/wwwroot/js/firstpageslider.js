$(document).ready(
    function(){
      getlastproduct(6)
      getMaxProductLike(6)
    }
)
/**/
var swiper = new Swiper('.swiper', {
    slidesPerView: 3,
    direction: getDirection(),
    navigation: {
      nextEl: '.swiper-button-next',
      prevEl: '.swiper-button-prev',
    }
    
  });

  function getDirection() {
    var windowWidth = window.innerWidth;
    var direction = window.innerWidth <= 760 ? 'vertical' : 'horizontal';

    return direction;
  }

function addTicket(){
  var emailticket=document.getElementById('emailticket').value
  var IsFavorite = document.querySelectorAll('input[type="radio"][name="fav_language"]:checked');
  var param={
    isFav : parseInt(IsFavorite[0].value)
  }
	var input={
		Email:emailticket,
    IsFavorite:parseInt(IsFavorite[0].value)
	}
	callAjax("Ticket/addTicket",input,afterTicket,param,"POST")
}
function afterTicket(param){
  
  if(param.serverResponse == true)
  {
       if(param.isFav == 1){
           Swal.fire("سپاسگزاریم از ثبت نظر شما");
         }
      else{
          Swal.fire("در جهت بهبود سایت تلاش خواهیم کرد.");
        }
  }
  else{
         Swal.fire("متاسفانه تیکت شما ثبت نشد. لطفا دوباره تلاش کنید!");
  }
}
function getlastproduct(count){
  var param={
 
  }
  callAjax('Product/GetLastProducts',count,aftergetlastproduct,param,'post')
}
function aftergetlastproduct(param){
  var result ="";
    for(let i = 0;i< param.serverResponse.length;i++)
    {
          
                  result += ` <div class="swiper-slide" >
                                   <div class="product  mt-2 mb-2 me-2 ms-2">
                                          <img src="/axstore/${param.serverResponse[i].imageURL}" style="width: 90% !important; height:25vh;">
                                          <h5 class="mt-4"></h5>${param.serverResponse[i].productName}</h5>
                                          <p class="mt-4"> در انبار :  ${param.serverResponse[i].count} </p>
                                          <p class="mt-4 mb-4">قیمت :${param.serverResponse[i].orginalPrice} تومان </p>
                                          <a class="" href="/SingleProduct/${param.serverResponse[i].id}">مشاهده محصول</a>
                                    </div></div>
                                `
    }
    document.getElementById('123').innerHTML = result
}
function getMaxProductLike(count){
   var param={

   }
   callAjax('Product/GetMaxProductLike',count,afterMaxProductLike,param,'post')
}
function afterMaxProductLike(param){
  var result1="";
  for(let i=0;i<param.serverResponse.length;i++)
  {
      result1+=` <div class="swiper-slide" style="">
      <div class="product mt-2 mb-2 me-2 ms-2">
          <img src="/axstore/${param.serverResponse[i].imageURL}" style="width: 90% !important; height:25vh;">
          <h5 class="mt-4">${param.serverResponse[i].productName}</h5>
          <p class="mt-4">تعداد در انبار :  ${param.serverResponse[i].count} </p>
          <p class="mt-4 mb-4">قیمت : ${param.serverResponse[i].orginalPrice} تومان</p>
          <p class="mt-4 mb-4">${param.serverResponse[i].like} <i class="fa-solid fa-heart"></i></p>
          <a class=""href="/SingleProduct/${param.serverResponse[i].id}">مشاهده محصول</a>
          </div>
    </div>`
  }
  document.getElementById('slider2').innerHTML=result1
}