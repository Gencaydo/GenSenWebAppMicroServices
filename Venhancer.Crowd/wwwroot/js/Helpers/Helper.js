"use strict";
function FillGamesForDropDownObject(formname,objectname) {
    var a = document.getElementById('' + formname + '');
    var b = a.querySelector("[name=" + CSS.escape(objectname) + "]");
    var gameDto = {
        QueryId: 2,
        Name: "Query",
        KeyTypeId: 1,
        DefaultBuyingPrice: 10,
        DefaultSellingPrice: 10
    };
    $.ajax({
        url: "/Game/GetAllGames",
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(gameDto),
        success: function (response) {
            if (response != null) {
                try {
                    const obj = JSON.parse(response);
                    if (obj.Errors != null) {
                        MessageBox("error", obj.Errors[0]);
                    }
                    else {
                        $.each(obj.Data, function () {
                            var newGameNameObject = new Option(this.Name, this.Id, true, true);
                            b.append(newGameNameObject);
                        });
                    }
                } catch (e) {
                    MessageBox("error", "Error.Please Contact with IT Departmant. Error Number : 1014");
                }
            }
        },
        error: function (response) {
            MessageBox("error", "Sorry, Service not working., Please contact with IT department. Error Detail :" + response.message);
        }
    });
}
function FillCustomersForDropDownObject(formname, objectname) {
    var a = document.getElementById('' + formname + '');
    var b = a.querySelector("[name=" + CSS.escape(objectname) + "]");
    var gameDto = {
        QueryId: 2,
        Name: "aa",
        Email: "g@g.com",
        KeyTypeId: 1,
        StatusId: 1,
        AddressLine1:"gg"
    };
    $.ajax({
        url: "/Customer/GetAllCustomers",
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(gameDto),
        success: function (response) {
            if (response != null) {
                try {
                    const obj = JSON.parse(response);
                    if (obj.Errors != null) {
                        MessageBox("error", obj.Errors[0]);
                    }
                    else {
                        $.each(obj.Data, function () {
                            var newCustomerNameObject = new Option(this.Name, this.Id, true, true);
                            b.append(newCustomerNameObject);
                        });
                    }
                } catch (e) {
                    MessageBox("error", "Error.Please Contact with IT Departmant. Error Number : 1015");
                }
            }
        },
        error: function (response) {
            MessageBox("error", "Sorry, Service not working., Please contact with IT department. Error Detail :" + response.message);
        }
    });
}
function FillSuppliersForDropDownObject(formname, objectname) {
    var a = document.getElementById('' + formname + '');
    var b = a.querySelector("[name=" + CSS.escape(objectname) + "]");
    var supplierDto = {
        Name: "ss",
        Email: "ss",
        AddressLine1: "ss",
        BuyingPrice: 10,
        SellingPrice: 10
    };
    $.ajax({
        url: "/Supplier/GetAllSuppliers",
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(supplierDto),
        success: function (response) {
            if (response != null) {
                try {
                    const obj = JSON.parse(response);
                    if (obj.Errors != null) {
                        MessageBox("error", obj.Errors[0]);
                    }
                    else {
                        $.each(obj.Data, function () {
                            var newCustomerNameObject = new Option(this.Name, this.Id, true, true);
                            b.append(newCustomerNameObject);
                        });
                    }
                } catch (e) {
                    MessageBox("error", "Error.Please Contact with IT Departmant. Error Number : 1015");
                }
            }
        },
        error: function (response) {
            MessageBox("error", "Sorry, Service not working., Please contact with IT department. Error Detail :" + response.message);
        }
    });
}
function MessageBox(MessageType, MessageText) {
    Swal.fire({
        text: MessageText,
        icon: MessageType,
        buttonsStyling: !1,
        confirmButtonText: "Ok, got it!",
        customClass: {
            confirmButton: "btn btn-primary"
        }
    })
}