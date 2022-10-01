"use strict";
var KTSigninTwoSteps = function () {
    var t, n;
    return {
        init: function () {
            t = document.querySelector("#kt_sing_in_two_steps_form"), (n = document.querySelector("#kt_sing_in_two_steps_submit")).addEventListener("click", (function (e) {
                e.preventDefault();
                var i = !0,
                    o = [].slice.call(t.querySelectorAll('input[maxlength="1"]'));
                o.map((function (t) {
                    "" !== t.value && 0 !== t.value.length || (i = !1)
                })), !0 === i ? (n.setAttribute("data-kt-indicator", "on"), n.disabled = !0, setTimeout((function () {
                    n.removeAttribute("data-kt-indicator"), n.disabled = !1,
                        VerifyTwoStep(t).then((function (t) {
                            t.isConfirmed && o.map((function (t) {
                                t.value = ""
                            }))
                        }))
                }), 2e3)) : MessageBox("error", "Please enter valid securtiy code and try again.")
                    .then((function () {
                        KTUtil.scrollTop()
                    }))
            }))
        }
    }
}();
KTUtil.onDOMContentLoaded((function () {
    KTSigninTwoSteps.init();
    SetPageParameters();
}));
var elts = document.getElementsByClassName('form-control form-control-solid h-60px w-60px fs-2qx text-center border-primary border-hover mx-1 my-2')
Array.from(elts).forEach(function (elt) {
    elt.addEventListener("keyup", function (event) {
        // Number 13 is the "Enter" key on the keyboard
        if (event.keyCode === 13 || elt.value.length == 1) {
            // Focus on the next sibling
            elt.nextElementSibling.focus()
        }
        // Number 13 is the "Enter" key on the keyboard
        if (event.keyCode === 8 || elt.value.length == -1) {
            // Focus on the next sibling
            elt.previousElementSibling.focus()
        }
    });
})
function VerifyTwoStep(verificationcode) {
    var verificationcodereal = "";
    for (const element of verificationcode) {
        if (element.value != "") {
            verificationcodereal += element.value;
        }
    }
    $.ajax({
        url: "Login/TwoStepVerification",
        type: 'POST',
        data: { "verificationcode": verificationcodereal },
        success: function (response) {
            const obj = JSON.parse(response);
            if (obj.IsSuccessful == true) {
                var Email = obj.Data.Email;
                window.location.href = "Login/_ThirdStep?Email=" + Email;
            }
            else {
                MessageBox("error", "Verification code not correct. Please try again!");
            }
        },
        error: function (response) {
            MessageBox("error", "Sorry, Service not working., Please contact with IT department.");
        }
    });
}
function SetPageParameters() {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    var lastFourDigit = urlParams.get('lastFourDigit');
    if (lastFourDigit != null) {
        document.querySelector("#lblMobilePhoneDigit").innerHTML = "*********" + lastFourDigit;
    }
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