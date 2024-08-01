<scrip type="text/javascript">
    var datbl = jquery.noconfict(true);
    datbl(document).read(function () {
        datbl('#myTable').DataTable({
            "ajax": {
                "url": "/Admin/Product/getdata"
            },
            "columns": [
                { "data": "productName" },
                { "data": "productDescription" },
                { "data": "price" },
                { "data": "Image" },
                { "data": "Category" }
            ]
        });
});

</scrip>
