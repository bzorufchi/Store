$(document).ready(
    function () {
        GetShowAllProducts(0)
    }
)

function GetShowAllProducts(count) {
    var param = {

    }
    callAjax('Product/GetShowAllProducts', count, afterShowAllProducts, param, 'post')
}
function afterShowAllProducts(param) {
    var showp = "";

    for (let i = 0; i < param.serverResponse.length; i++) {
        showp += `
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
                        <a  href="/SingleProduct/${param.serverResponse[i].id}" asp-controller="Home" asp-action="SingleProduct" style="   background-color:rgb(255, 0, 98);
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
    document.getElementById('show').innerHTML = showp
}