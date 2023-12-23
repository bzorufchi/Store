$(document).ready(function () {
	GetShoppingCard()
	// DataTable initialisation
	//$('#example').DataTable(
	//	{
	//		"paging": false,
	//		"autoWidth": true,
	//		"footerCallback": function ( row, data, start, end, display ) {
	//			var api = this.api();
	//			nb_cols = api.columns().nodes().length;
	//			var j = 3;
	//			while(j < nb_cols){
	//				var pageTotal = api
 //               .column( j, { page: 'current'} )
 //               .data()
 //               .reduce( function (a, b) {
 //                   return Number(a) + Number(b);
 //               }, 0 );
 //         // Update footer
 //         $( api.column( j ).footer() ).html(pageTotal);
	//				j++;
	//			} 
	//		}
	//	}
	//);


});
function GetShoppingCard() {
	var param = {

	}
	var userId = localStorage.getItem("userid");
	callAjax(`Orders/GetShoppingCard/${userId}`, null, afterGetShoppingCard, param, 'post')
}
function afterGetShoppingCard(param) {
	var shopingcard = "";
	for (var i = 0; i < param.serverResponse.length; i++) {
		shopingcard += `
		 <tbody>
            <tr>
                <td>${i+1}</td>
                <td>${param.serverResponse[i].productName}</td>
                <td><button type="button" onclick="UpdateCount(${param.serverResponse[i].orderId},1)">+</button>${param.serverResponse[i].count}<button type="button"  onclick="UpdateCount(${param.serverResponse[i].orderId},-1)">-</button></td>
                <td>${param.serverResponse[i].fixedPrice}</td>
                <td><a class="bg-danger pt-1 pb-1 pe-3 ps-3 rounded rounded-2" onclick="DeleteOrder(${param.serverResponse[i].orderId})" style="text-decoration: none;color: white;">حذف از سبد</a></td>
            </tr>

        </tbody>
		`
      
	}
	document.getElementById('shopcard').innerHTML = shopingcard
}
function UpdateCount(OrderId, Number){
	var param = {

	}
	var input = {
		OrderId: OrderId,
		Number: Number
	}
	callAjax(`Orders/UpdateCount`, input, afterUpdateCount, param, 'post')
}
function afterUpdateCount(param) {
	window.location.reload();
}

function DeleteOrder(Orderid) {
	var input = { Id: Orderid }
	var param = {}
	callAjax(`Orders/Delete`, input, GetShoppingCard, param, 'post')
}