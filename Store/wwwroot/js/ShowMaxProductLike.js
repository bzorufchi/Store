$(document).ready(
    function () {
        GetShowProductLike(20)
    }
)
function GetShowProductLike(count) {
    var param = {

    }
    callAjax('Product/GetMaxProductLike', count, afterShowProductLike, param, 'post')
}
function afterShowProductLike(param) {
    var showLike = "";
    for (let i = 0; i<param.serverResponse.length; i++) {
        showLike += `
     <div class=" col-3 mt-5" mb-5">
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
    document.getElementById('showLike').innerHTML = showLike
}