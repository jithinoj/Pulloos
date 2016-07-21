
/*
 * 
 * 
 * If You are using the "_CategorySelector.cshtml" partial view, the selected category will be inside a hidden feild with name "SelectedCategory".
 * 
 * "_CategorySelector.cshtml" partial view requires the jquery plugin to work as expected. It has also dependency on bootstrap. 
 */

(function () {

    $(function () {
       
        $('#btnCreate').click(SaveData);       

    });

    function SaveData() {

        var CategoryId = $('#CategoryId').val();
        var CategoryName = $('#CategoryName').val();
        var ParentCategory = $('#SelectedCategory').val();

        var categoryDetail = {

            CategoryId: CategoryId,
            CategoryName: CategoryName,
            ParentCategory: ParentCategory
        };

        return $.ajax({
            url: '/Category/Create',
            type: "POST",
            data: JSON.stringify(categoryDetail),
            contentType: 'application/json',
            dataType: 'json'
        })
            .done(function () {

                window.location.href = "/";
            })
            .fail(function (err) {

                console.log(err);
            });

    }

})();