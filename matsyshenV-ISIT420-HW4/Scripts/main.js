// change uri to orders
var salespersonURI = 'api/SalesPerson';
var storeURI = 'api/Store';
var cdMarkupURI = 'api/CdSales';


$(document).ready(function ()
{
    EmployeeList();
    StoreList();
});

function EmployeeList()
{
    // Send an AJAX request
    $.getJSON(salespersonURI)
        .done(function (data) {

            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {

                // Add a list item for the product.
                $('<option>', { text: item, value: item }).appendTo($('#employees'));
            });
            console.log("Employees: " + data);
        });
}

function StoreList()
{
    // Send an AJAX request
    $.getJSON(storeURI)
        .done(function (data) {

            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {

                // Add a list item for the product.
                $('<option>', { text: item, value: item }).appendTo($('#stores'));
            });
            console.log("Stores: " + data);
        });
}

function TopMarkups()
{
    // Send an AJAX request
    $.getJSON(cdMarkupURI)
        .done(function (data) {

            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {

                // Add a list item for the product.
                $('<li>', { text: formatItem(item) }).appendTo($('#markupsOutput'));
            });
        });
}

function formatItem(item)
{
    return 'City: ' + item.City + ', Count: ' + item.Count;
}

function EmployeePerformance()
{
    let select = document.getElementById("employees");
    let salesPersonID = select.options[select.selectedIndex].value;
    // Send an AJAX request
    $.getJSON("api/SalesPersonSales?employeeName=" + salesPersonID)
        .done(function (data) {
            // On success, 'data' contains a list of products.
            document.getElementById("employeeSalesOutput").innerText = "That employee sold $" + data + " for the year";
        });
}

function StorePerformance()
{
    let select = document.getElementById("stores");
    let storeID = select.options[select.selectedIndex].value;
    // Send an AJAX request
    $.getJSON("api/StoreSales?storeCity=" + storeID)
        .done(function (data) {
            // On success, 'data' contains a list of products.
            document.getElementById("storeSalesOutput").innerText = "That store sold $" + data + " for the year";
        });
}