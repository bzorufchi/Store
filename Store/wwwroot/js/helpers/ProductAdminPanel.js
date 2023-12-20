$(document).ready(
    function () {
        GetShowAllProducts(0)
        GetAllCategory();
        GetAllCountry();
        GetAllBrands();
    }
)
var newimg = ''
$('input[type=file]').change(function () {
    var file1 = $('#ImageURL').prop("files")[0];

    formData = new FormData();
    formData.append('file',file1);

    $.ajax({
        type: "POST",
        url: '/Upload/UploadFiles',
        contentType: 'multipart/form-data',
        contentType: false,
        processData: false,
        data: formData,
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (result) {
            newimg = result
        }
    })
});
function GetShowAllProducts(count) {
    var param = {

    }
    callAjax('Product/ProductAdminPanel', count, afterShowAllProducts, param, 'post')
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
                        <a  href="/SingleProduct/${param.serverResponse[i].id}" asp-controller="Home" asp-action="SingleProduct"
                        style="   background-color:green;
                        color:white;
                        font-size: 11px; 
                        padding: 10px 15px;
                        border-radius: 5px;">مشاهده محصول</a>

                        <a onclick="DeleteProduct(${param.serverResponse[i].id})"  
                        style="background-color:red;
                        color:white;
                        font-size: 11px; 
                        padding: 10px 15px;
                        border-radius: 5px;">حذف محصول</a>
                    </div>
                  </div>
                </div>
                </div>
        `
    }
    document.getElementById('show').innerHTML = showp
}
function DeleteProduct(id) {
    var param = {
        
    }
    var input = {
        Id: id
    }
    callAjax('Product/Delete', input, afterDeleteProduct, param, 'post')
}
function afterDeleteProduct(param) {
    if (param.serverResponse == 0) {
        Swal.fire(" محصول حذف نشد،مجدد تلاش کنید.");
    }
    else {
        Swal.fire("محصول با موفقیت حذف شد.");
        window.location.reload()
    }
}


function AddProduct() {
    var Brand = parseInt(document.getElementById('Brands').value)
    var Country = parseInt(document.getElementById('Country').value)
    var Category = parseInt(document.getElementById('categoryes').value)
    var NameProduct = document.getElementById('NameProduct').value
    var ProductDes = document.getElementById('ProductDes').value
   // var ImageURL = document.getElementById('ImageURL').value
    var orginalPrice = parseInt(document.getElementById('orginalPrice').value)
    var DiscountPrice = parseInt(document.getElementById('DiscountPrice').value)
    var IsActive = parseInt(document.getElementById('IsActive').value)
    var Count = parseInt( document.getElementById('Count').value)

    var param = {

    }
    var input = {
     
        BrandId: Brand,
        CountryId: Country,
        CategoryId: Category,
        ProductName: NameProduct,
        ProductDescription: ProductDes,
        ImageURL: newimg,
        OrginalPrice: orginalPrice,
        DiscountPrice: DiscountPrice,
        IsActive: IsActive,
        Count: Count,
       
    }
    callAjax('Product/AddProduct', input, afterAddProduct, param, 'post')
}
function afterAddProduct(param) {
    if (param.serverResponse == 0) {
        Swal.fire(" محصول اضافه نشد،مجدد تلاش کنید.");
    }
    else {
        Swal.fire("محصول با موفقیت اضافه شد.");
        window.location.reload()
    }
}

function GetAllCategory() {
    var param = {

    }
    callAjax('Product/GetAllCategory', {} , afterGetAllCategory, param, 'post')
}
function afterGetAllCategory(param){
    var category = "";
    for (let i = 0; i < param.serverResponse.length; i++) {
        category += `
       <option value="${param.serverResponse[i].id}">${param.serverResponse[i].name}</option>
        `
    }
    document.getElementById('categoryes').innerHTML = category
}


function GetAllCountry() {
    var param = {

    }
    callAjax('Product/GetAllCountry', {} , afterGetAllCountry, param, 'post')
}
function afterGetAllCountry(param) {
    var Country = "";
    for (let i = 0; i < param.serverResponse.length; i++) {
        Country += `
       <option value="${param.serverResponse[i].id}">${param.serverResponse[i].name}</option>
        `
       
    }
    document.getElementById('Country').innerHTML = Country
}

function GetAllBrands() {
    var param = {

    }
    callAjax('Product/GetAllBrands', {} , afterGetAllBrands, param, 'post')
}
function afterGetAllBrands(param) {
    var Brands = "";
    for (let i = 0; i < param.serverResponse.length; i++) {
        Brands += `
       <option value="${param.serverResponse[i].id}">${param.serverResponse[i].name}</option>
        `
    }
        document.getElementById('Brands').innerHTML = Brands
}

