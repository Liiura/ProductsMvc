var loginEditor = (function () {
    const baseControllerUrl = baseUrl+"Login/";
    const formElement = $("#loginForm")
    function init(container) {
        bindEvents(container);
    }
    function bindEvents(container) {
        container.on("click", "button[data-action-login=login]", function () {
            event.preventDefault();
            SignIn();
        });
        container.on("keypress", "#Password", function (e) {
            if (e.which == 13) {
                SignIn();
                return false;
            }
        });
    }
    //function SignIn() {
    //    formElement.validate();
    //    if (formElement.valid()) {
    //        AjaxSignInRequest()
    //    }
    //}
    //function AjaxSignInRequest() {
    //    $.ajax({
    //        url: baseControllerUrl + "SignIn",
    //        type: "Post",
    //        data: formElement.serialize(),
    //        success: function (data) {
    //            console.log(data);
    //        }
    //    });
    //}
    async function SignIn() {
        formElement.validate();
        if (formElement.valid()) {
            const result = await AjaxSignInRequest();
            console.log(result);
        }
    }
    async function AjaxSignInRequest() {
        let result;

        try {
            result = await $.ajax({
                url: baseControllerUrl + "SignIn",
                type: 'POST',
                data: formElement.serialize()
            });

            return result;
        } catch (error) {
            console.error(error);
        }
    }
    return {
        init,
    };
})