var generalAdminEditor = (function () {
    const baseControllerUrl = baseUrl + "Home/";
    const formElement = $("#productForm");
    function init(container) {
        bindEvents(container)
    }
    function bindEvents(container) {
        container.on("click", "button[data-action-product=saveProduct]", function () {
            event.preventDefault();
            SaveProduct();
        })
    }
    async function SaveProduct() {
        formElement.validate();
        if (formElement.valid()) {
            AjaxRequestToInsertProduct()
            formElement.trigger("reset");
        }
    }
    function UserException(message) {
        this.message = message;
        this.name = "UserException";
    }
    async function AjaxRequestToInsertProduct() {
        try {
            await $.ajax({
                url: baseControllerUrl +"InsertProduct",
                type: "POST",
                data: formElement.serialize()
            })
        } catch (e) {
            let objectException = new UserException("Server error");
            throw objectException;
        }
    }
    return {
        init,
    };
})