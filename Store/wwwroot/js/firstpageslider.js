
$(document).ready(
    function(){
      getlastproduct(4)
      getMaxProductLike(4)
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
          
                  result += `
                  <div class="col-3">
                  <div class="card text-black ms-1 text-center pb-3">
                    <img src="/axstore/${param.serverResponse[i].imageURL}"
                      class="card-img-top" alt="Apple Computer" />
                    <div class="card-body">
                      <div class="text-center">
                        <h6 class="card-title mt-2">نام محصول :${param.serverResponse[i].productName} </h6>
                        <p class="text-muted mb-3 mt-3">تعداد :${param.serverResponse[i].count} </p>
                      </div>
                      <div>
                        <div class="mt-3 mb-4">
                         <p>قیمت :${param.serverResponse[i].orginalPrice} </p>
                        </div>
                        <a  href="/SingleProduct/${param.serverResponse[i].id}" asp-controller="Home" asp-action="SingleProduct" style="background-color:rgb(255, 0, 98);
                        color:white;
                        font-size: 11px; 
                        padding: 10px 15px;
                        border-radius: 5px;">مشاهده محصول</a>
                    </div>
                  </div>
                
                </div>
                </div>
          `
                                
    }
    document.getElementById('123').innerHTML = result
}
function getMaxProductLike(count){
   var param={

   }
   callAjax('Product/GetMaxProductLike',count,afterMaxProductLike,param,'post')
}

function Searchproducte() {
    var input = document.getElementById('textsearch').value;
    window.location.href = "/search/"+input
}

function afterMaxProductLike(param){
  var result1="";
  for(let i=0;i<param.serverResponse.length;i++)
  {
      result1+=` 
      <div class=" col-3">
      <div class="card text-black ms-1 text-center pb-3">
        <img src="/axstore/${param.serverResponse[i].imageURL}"
          class="card-img-top" alt="Apple Computer" />
        <div class="card-body">
          <div class="text-center">
            <h6 class="card-title mt-2">نام محصول :${param.serverResponse[i].productName} </h6>
            <p class="text-muted mb-3 mt-3">تعداد :${param.serverResponse[i].count} </p>
          </div>
          <div>
            <div class="mt-3 mb-4">
             <p>قیمت :${param.serverResponse[i].orginalPrice} </p>
            </div>
            <p class="mt-4 mb-4"><img width="30" height="30" src="https://img.icons8.com/ios-filled/50/FA5252/like--v1.png" alt="like--v1"/> پسندیده شده : ${param.serverResponse[i].like} </p>
            <a  href="/SingleProduct/${param.serverResponse[i].id}" asp-controller="Home" asp-action="SingleProduct" style="background-color:rgb(255, 0, 98);
            color:white;
            font-size: 11px; 
            padding: 10px 15px;
            border-radius: 5px;">مشاهده محصول</a>
        </div>
      </div>
    
    </div>
    </div>
      `
  }
  document.getElementById('slider2').innerHTML=result1
}