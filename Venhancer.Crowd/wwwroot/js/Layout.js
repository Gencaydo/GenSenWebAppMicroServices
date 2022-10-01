"use strict";
var LoginUserId;
var KTLayoutGeneral = function () {
    //GetCurrency();
    //GetIPAdress();
    return {
        init: function () {
            $.ajax({
                type: "POST",
                url: "/Home/GetUserAppDtoData",
                data: { "sessionName": "userAppDtoData" },
                success: function (response) {
                    if (response != null) {
                        const obj = JSON.parse(response);
                        const myArray = obj.Data.UserName.split(" ");
                        document.querySelector("#lblName1").innerHTML = myArray[0];
                        document.querySelector("#lblNameSurename1").innerHTML = document.querySelector("#lblNameSurename1").innerHTML = obj.Data.UserName;
                        document.querySelector("#lblEmailAdress1").innerHTML = document.querySelector("#lblEmailAdress2").innerHTML = obj.Data.Email;
                        LoginUserId = obj.Data.Id;
                    } else {
                        MessageBox("error", "User Data not found please contact with IT!");
                    }
                },
                failure: function (response) {
                    MessageBox("error", "User Data not found please contact with IT! Error Detail : " + response.responseText);
                },
                error: function (response) {
                    MessageBox("error", "User Data not found please contact with IT! Error Detail : " + response.responseText);
                }
            });
        }
    }
}();
KTUtil.onDOMContentLoaded((function () {
    KTLayoutGeneral.init();
    CheckNotificationCount();
    FillGamesForDropDownObject("kt_modal_Import_keys_form", "layoutgamename");
}));
function GetCurrency() {
    $.ajax({
        type: "POST",
        url: "/Home/GetCurrencyData",
        data: { "sessionName": "userAppDtoData" },
        success: function (response) {
            if (response != null) {
                const obj = JSON.parse(response);
                document.querySelector("#lbldolarcurrencyvalue").innerHTML = obj[0].CurrencySelling;
                document.querySelector("#lbleurocurrencyvalue").innerHTML = obj[3].CurrencySelling;
            } else {
                MessageBox("error", "User Data not found please contact with IT!");
            }
        },
        failure: function (response) {
            MessageBox("error", "User Data not found please contact with IT! Error Detail : " + response.responseText);
        },
        error: function (response) {
            MessageBox("error", "User Data not found please contact with IT! Error Detail : " + response.responseText);
        }
    });
}
function GetIPAdress() {
    $.getJSON("https://jsonip.com/?callback=?", function (data) {
        document.querySelector("#lblIPAdress").innerHTML = "IP ADRESS : " +  data.ip;
    });
}
function CheckNotificationCount() {
    var count = 0;
    setInterval(() => {
        count++;
        document.querySelector("#MyProjectsNotificationCount").innerHTML = count; 
    },5000);
}