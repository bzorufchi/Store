$(document).ready(
    function () {
        
    }
)

function searchProductsByStr() {
    var input = document.getElementById('textsearch').value;
    var param = {

    }
    callAjax('Product/searchProductsByStr', input, aftersearchProductsByStr, param, 'post')
}
function aftersearchProductsByStr(param) {
    var search = "";

    for (let i = 0; i < param.serverResponse.length; i++) {
        search += `
                  <div class="col-3 mt-5" mb-5">
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
                        <a  href="/SingleProduct/${param.serverResponse[i].id}" asp-controller="Home" asp-action="SingleProduct"
                        style="   background-color:rgb(255, 0, 98);
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
    document.getElementById('search').innerHTML = search
}