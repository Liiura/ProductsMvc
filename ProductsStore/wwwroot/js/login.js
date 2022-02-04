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
    async function SignIn() {
        formElement.validate();
        if (formElement.valid()) {
            const result = await AjaxSignInRequest();
            Success(result);
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
    function Success(data) {
        if (data.isSuccess) {
            window.location.href = baseUrl+"Admin/Home/";
        }
    }
    return {
        init,
    };
})