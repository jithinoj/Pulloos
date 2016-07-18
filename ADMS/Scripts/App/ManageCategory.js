
(function () {

    var selectedCategory;

    $(function () {
        $("#ParentCategory").change(CategoryChanged);
        $('#btnCreate').click(SaveData);
    });

    function BindEventHandlers() {
        $('.list-group-item')
            .unbind('click')
            .click(CategorySelected);

        $('.list-group-item .btn-flat')
            .unbind('click')
            .click(ExpandCategory);
    }



    var CategoryChanged = function (event) {

        var categoryId = $(event.target).val();
        selectedCategory = categoryId;

        GetSubcategoriesByCategory(categoryId)
                    .done(function (categories) {

                        DisplayCategories(categories);
                    });
    };

    var CategorySelected = function (event) {

        selectedCategory = event.target.id;
        $('.selected').removeClass('selected');
        $('#' + selectedCategory).addClass('selected');
    };

    var ExpandCategory = function (event) {

        event.stopPropagation();
        var categoryId = event.target.parentElement.id;

        if (event.target.innerHTML == "+") {
            
            GetSubcategoriesByCategory(categoryId)
                    .done(function (categories) {

                        DisplaySubCategories(categories, categoryId);
                    });
        }
        else {

            event.target.innerHTML = '+';

            $('#' + categoryId).find('ul').slideUp('medium', function () {
                $('#' + categoryId).find('ul').remove();
            });
        }
    };



    function GetSubcategoriesByCategory(categoryId) {

        return $.ajax({
            url: '/Category/GetSubcategories?category=' + categoryId,
            type: "POST",
            contentType: 'application/json',
            dataType: 'json'
        })
        .fail(function (err) {
            console.log(err);
        });
    }

    function DisplayCategories(categories) {
        var list = $('#SubCategories');
        var totalCount = categories.length;

        if (totalCount > 0) {
            for (var i = 0; i < totalCount; i++) {

                var category = categories[i];

                list.append('<li class="list-group-item" id="' + category["CategoryId"] + '" ><span class="btn-flat" >+</span>' + category["CategoryName"] + '</li>')
                                        .hide().slideDown('medium');
            }

            BindEventHandlers();
        }
        else {
            list.html('');
        }
    }

    function DisplaySubCategories(categories, categoryId) {

        var list = $('#' + categoryId);
        var totalCount = categories.length;

        if (totalCount > 0) {

            var ul = document.createElement('ul');

            for (var i = 0; i < totalCount; i++) {

                var category = categories[i];

                $(ul).append('<li class="list-group-item" id="' + category["CategoryId"] + '" ><span class="btn-flat" >+</span>' + category["CategoryName"] + '</li>');
            }
            list.find('span').html('-');

            list.append(ul).hide()
                            .slideDown('medium');

            BindEventHandlers();
        }
    }


    function SaveData() {

        var CategoryId = $('#CategoryId').val();
        var CategoryName = $('#CategoryName').val();
        var ParentCategory = selectedCategory;

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

