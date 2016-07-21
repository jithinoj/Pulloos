
(function () {

    $(function () {

        $("#toggler").change(CategoryChanged);

        $('.toggler').click(GetSubcategories);

        BindEventHandlers();

    });

    function BindEventHandlers() {
        $('.toggler')
            .unbind('click')
            .click(GetSubcategories);

        $('.row_selector')
            .unbind('click')
            .click(CategorySelected);
    }


    var GetSubcategories = function (event) {

        var toggler = $(event.target);

        var categoryId = $(event.target.parentElement).find('.row_selector')[0].id;

        if (toggler.hasClass('glyphicon-circle-arrow-down')) {

            var categoryId = $(event.target.parentElement).find('.row_selector')[0].id;

            GetSubcategoriesByCategory(categoryId)
                        .then(function (categories) {

                            DisplaySubCategories(categories, categoryId);
                        });
        }
        else {

            toggler.addClass('glyphicon-circle-arrow-down');

            $(event.target.parentElement).find('div.innercategories:first')
                .slideUp('medium', function () {

                $(event.target.parentElement).find('div.innercategories:first').html('');
            });
        }
    };
    
    var CategoryChanged = function (event) {

        var categoryId = $(event.target).val();
        $('#SelectedCategory').val(categoryId);

        GetSubcategoriesByCategory(categoryId)
                    .done(function (categories) {

                        DisplayCategories(categories);
                    });
    };

    var CategorySelected = function (event) {

        $('#SelectedCategory').val(event.target.id);

        $('.row_selector').removeClass('glyphicon-check').addClass('glyphicon-unchecked');
        $('#' + event.target.id).removeClass('glyphicon-unchecked').addClass('glyphicon-check');
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

                var content = '<li><span class="toggler glyphicon glyphicon-circle-arrow-down"></span>'
                + '<span class="category_name">' + category["CategoryName"] + '</span>'
                + '<span class="row_selector glyphicon glyphicon-unchecked" id="' + category["CategoryId"] + '"></span>'
                + '<div class="innercategories"></div></li>';               


                $(ul).append(content);
            }

            toggler.parent().find('span:eq(0)').removeClass('glyphicon-circle-arrow-down').addClass('glyphicon-circle-arrow-up');

            container.append(ul).hide()
                            .slideDown('medium');

            BindEventHandlers();
        }
    }
    

})();

