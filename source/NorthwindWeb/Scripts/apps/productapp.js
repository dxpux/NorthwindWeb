var apiPost = function (url, data, success) {
    $.ajax({
        type: "POST",
        url: url,
        data: data,
        headers: {
            'RequestVerificationToken': window._antiForgeryToken,
        },
        success: success,
        error: function () {
            alert('api 通訊失敗');
        }
    })
}

var vm = new Vue({
    el: '#productApp',
    data: {
        products: [],
        categories: [],
        suppliers: [],
        addProduct: { ProductName: "", SupplierID: 1, CategoryID: 1, QuantityPerUnit: "", UnitPrice: 0 },
        modifyProduct: { ProductID: 0, ProductName: "", SupplierID: 1, CategoryID: 1, QuantityPerUnit: "", UnitPrice: 0 }
    },
    methods: {
        refreshProducts: function () {
            apiPost(
                window._urlGetProducts,
                null,
                function (data) {
                    if (data.Success == true) {
                        vm.products = data.Data;
                    } else {
                        alert(data.Message);
                    }
                });
        },
        refreshSuppliers: function () {
            apiPost(
                window._urlGetSuppliers,
                null,
                function (data) {
                    if (data.Success == true) {
                        vm.suppliers = data.Data;
                    } else {
                        alert(data.Message);
                    }
                });
        },
        refreshCategories: function () {
            apiPost(
                window._urlGetCategories,
                null,
                function (data) {
                    if (data.Success == true) {
                        vm.categories = data.Data;
                    } else {
                        alert(data.Message);
                    }
                });
        },
        newClick: function () {
            vm.addProduct.ProductName = "";
            vm.addProduct.QuantityPerUnit = "";
            vm.addProduct.CategoryID = vm.categories[0].CategoryID;
            vm.addProduct.SupplierID = vm.suppliers[0].SupplierID;
            vm.addProduct.UnitPrice = 0
        },
        onAddSubmit: function () {
            apiPost(
                window._urlAddProduct,
                vm.addProduct,
                function (data) {
                    if (data.Success == true) {
                        vm.refreshProducts();
                        $('#newItemDataPage').modal('hide');
                    } else {
                        alert(data.Message);
                    }
                });
        },
        modifyClick: function (product) {
            vm.modifyProduct.ProductID = product.ProductID;
            vm.modifyProduct.ProductName = product.ProductName;
            vm.modifyProduct.QuantityPerUnit = product.QuantityPerUnit;
            vm.modifyProduct.CategoryID = product.CategoryID;
            vm.modifyProduct.SupplierID = product.SupplierID;
            vm.modifyProduct.UnitPrice = product.UnitPrice;
        },
        onModifySubmit: function () {
            apiPost(
                window._urlModifyProduct,
                vm.modifyProduct,
                function (data) {
                    if (data.Success == true) {
                        vm.refreshProducts();
                        $('#updateItemDataPage').modal('hide');
                    } else {
                        alert(data.Message);
                    }
                });
        },
        discontinuedClick: function (product) {
            apiPost(
                window._urlDiscontinuedProduct,
                { productID: product.ProductID },
                function (data) {
                    if (data.Success == true) {
                        vm.refreshProducts();
                    } else {
                        alert(data.Message);
                    }
                });
        },
        continuedClick: function (product) {
            apiPost(
                window._urlContinuedProduct,
                { productID: product.ProductID },
                function (data) {
                    if (data.Success == true) {
                        vm.refreshProducts();
                    } else {
                        alert(data.Message);
                    }
                });
        }
    },
    mounted: function () {
        this.refreshProducts();
        this.refreshCategories();
        this.refreshSuppliers();
    }
});