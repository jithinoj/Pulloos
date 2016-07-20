
(function () {

    var selectedCategory;

    $(function () {
        $("#toggler").change(CategoryChanged);
        $('#btnCreate').click(SaveData);


        $('.toggler').click(GetSubcategories);

    });

    function BindEventHandlers() {
        $('.list-group-item')
            .unbind('click')
            .click(CategorySelected);

        $('.list-group-item .btn-flat')
            .unbind('click')
            .click(ExpandCategory);
    }


    var GetSubcategories = function (event) {

        var categoryId = $(event.target.parentElement).find('.row_selector')[0].id;
        GetSubcategoriesByCategory(categoryId)
                    .then(function (categories) {

                        DisplaySubCategories(categories, categoryId);
                    });
    };


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

        var toggler = $('#' + categoryId);
        var container = toggler.parent().find('div');


        var list = $('#' + categoryId);
        var totalCount = categories.length;

        if (totalCount > 0) {

            var ul = document.createElement('ul');
            ul.className = "subcategory";

            for (var i = 0; i < totalCount; i++) {

                var category = categories[i];

                var content = '<li><span class="toggler">+</span>'
                + '<span class="category_name">' + category["CategoryName"] + '</span>'
                + '<span class="row_selector" id="' + category["CategoryId"] + '">Select</span>'
                + '<div class="innercategories"></div></li>';               


                $(ul).append(content);
            }

            toggler.parent().find('span:eq(0)').html('-');

            container.append(ul).hide()
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

