"use strict";
var KTSigninGeneral = function () {
    var t, e, i;
    return {
        init: function () {
            t = document.querySelector("#kt_sign_in_form"), e = document.querySelector("#kt_sign_in_submit"), i = FormValidation.formValidation(t, {
                fields: {
                    email: {
                        validators: {
                            notEmpty: {
                                message: "Email address is required"
                            },
                            emailAddress: {
                                message: "The value is not a valid email address"
                            }
                        }
                    },
                    password: {
                        validators: {
                            notEmpty: {
                                message: "The password is required"
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger,
                    bootstrap: new FormValidation.plugins.Bootstrap5({
                        rowSelector: ".fv-row"
                    })
                }
            }), e.addEventListener("click", (function (n) {
                n.preventDefault(), i.validate().then((function (i) {
                    "Valid" == i ?
                        grecaptcha.ready(function () {
                            //if (grecaptcha.getResponse() === "") {
                            //    MessageBox("error", "Please validate the Google reCaptcha.");
                            //} else {
                                (e.setAttribute("data-kt-indicator", "on"), e.disabled = !0, setTimeout((function () {
                                    e.removeAttribute("data-kt-indicator"),
                                        //getFormData("#kt_sign_in_form"),
                                        UserLogin(t.querySelector('[name="email"]').value, t.querySelector('[name="password"]').value,e).then((function (e) {
                                            e.isConfirmed && (t.querySelector('[name="email"]').value = "", t.querySelector('[name="password"]').value = "")
                                        }))
                                }), 2e3)).then((function () {
                                    e.disabled = !1
                                }))
                            //}
                        }) : MessageBox("error", "Sorry, looks like there are some errors detected, please check login form.");
                }))
            }))
        }
    }
}();
KTUtil.onDOMContentLoaded((function () {
    KTSigninGeneral.init()
    //setInterval(() => {
    //    MessageBox("error", "BU mesaj 5 saniyede bir görünecek!");
    //},5000);
}));
function UserLogin(loginemail, loginpassword, e) {
    var loginDto = {
        Email: loginemail,
        Password: loginpassword,
    };
    $.ajax({
        url: "/Login/UserSignIn",
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(loginDto),
        success: function (response) {
            try {
                const obj = JSON.parse(response);
                if (obj.IsSuccessful == false) {
                    MessageBox("error", obj.Error.Errors[0])
                    e.disabled = !1
                }
                else {
                    var lastFourDigit = obj.Data.PhoneNumber.substr(obj.Data.PhoneNumber.length - 4);
                    window.location.href = "Login/_TwoStep?lastFourDigit=" + lastFourDigit;
                }
            } catch (e) {
                MessageBox("error", "Login Error.Please Contact with IT Departmant. Error Number : 1003");
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
function getFormData(dom_query) {
    var object = $(dom_query).serializeArray().reduce(function (obj, item) {
        var name = item.name.replace("[]", "");
        if (typeof obj[name] !== "undefined") {
            if (!Array.isArray(obj[name])) {
                obj[name] = [obj[name], item.value];
            } else {
                obj[name].push(item.value);
            }
        } else {
            obj[name] = item.value;
        }
        return obj;
    }, {});
    return JSON.stringify(object);
}