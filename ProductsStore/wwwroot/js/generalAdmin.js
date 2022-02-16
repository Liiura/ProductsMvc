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
        container.on("click", "button[data-action-product=updateProduct]", function () {
            event.preventDefault();
            UpdateProduct()
        })
        container.on("click", "button[data-action-product=searchByFilter]", function () {
            event.preventDefault();
            searchByFilter()
        })
        container.on("click", "button[data-action-product=clearSearch]", function () {
            event.preventDefault();
            $("#filterHome")[0].reset()
            searchByFilter()
        })
    }
    async function SaveProduct() {
        formElement.validate();
        if (formElement.valid()) {
            const payload = await AjaxRequestToInsertProduct()
            if (payload.isSuccess) {
                formElement.trigger("reset");
                window.location.href = payload.redirectToUrl
            }
        }
    }
    async function searchByFilter() {
        let response = await AjaxRequestToSearchByFilter()
        $("#dataContainer").html(response);
    }
    async function UpdateProduct() {
        $("#productEditForm").validate();
        if ($("#productEditForm").valid()) {
            const payload = await AjaxRequestToUpdateProduct();
            if (payload.isSuccess) {
                window.location.href = payload.redirectToUrl
            }
        }
    }
    function UserException(message) {
        this.message = message;
        this.name = "UserException";
    }
    async function AjaxRequestToSearchByFilter() {
        try {
            let result = await $.ajax({
                url: baseControllerUrl + "RenderProductsCardWithFilter",
                type: "POST",
                data: $("#filterHome").serialize()
            })
            return result;
        } catch (e) {
            let objectException = new UserException("Server error");
            throw objectException;
        }
    }
    async function AjaxRequestToInsertProduct() {
        try {
            let result = await $.ajax({
                url: baseControllerUrl +"InsertProduct",
                type: "POST",
                data: formElement.serialize()
            })
            return result;
        } catch (e) {
            let objectException = new UserException("Server error");
            throw objectException;
        }
    }
    async function AjaxRequestToUpdateProduct() {
        try {
            let result = await $.ajax({
                url: baseControllerUrl + "UpdateProductInformation",
                type: "POST",
                data: $("#productEditForm").serialize()
            })
            return result;
        } catch (e) {
            let objectException = new UserException("Server error");
            throw objectException;
        }
    }
    return {
        init,
    };
})