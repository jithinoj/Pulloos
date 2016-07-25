(function () {

    $(function () {

        $('#submit').click(SavePost);
    });

    function SavePost() {

        var PostId = $('#PostId').val();
        var Title = $('#Title').val();
        var Description = $('#Description').val();
        var ExpirationDate = $('#ExpirationDate').val();        
        var CategoryId = $('#SelectedCategory').val();

        var postDetail = {

            PostId: PostId,
            Title: Title,
            Description: Description,
            ExpirationDate: ExpirationDate,
            CategoryId: CategoryId
        };

        return $.ajax({
            url: '/Posts/Create',
            type: "POST",
            data: JSON.stringify(postDetail),
            contentType: 'application/json',
            dataType: 'json'
        })
        .done(function (data) {

            window.location.href = "/Posts/Index";
        })
        .fail(function (err) {

            console.log(err);
        });
    }

})();