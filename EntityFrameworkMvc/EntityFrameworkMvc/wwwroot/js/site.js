function deleteAuthorFunction(id) {
    if (confirm('Are you sure you want to delete Author?')) {
        $.ajax({
            type: 'POST',
            url: '/Author/Delete/' + id,
            dataType: 'json',
            success: function (result) {
                alert(result.message); // Başarılı veya başarısız mesajlarına göre düzenleyebilirsiniz
                location.reload(true); // Sayfayı yenileme
            },
            error: function (xhr) {
                alert("Hata oluştu: " + xhr.responseText);
            }
        });
    }
}

function deleteAuthorProfileFunction(id) {
    if (confirm('Are you sure you want to delete AuthorProfile?')) {
        $.ajax({
            type: 'POST',
            url: '/AuthorProfile/Delete/' + id,
            dataType: 'json',
            success: function (result) {
                alert(result.message); // Başarılı veya başarısız mesajlarına göre düzenleyebilirsiniz
                location.reload(true); // Sayfayı yenileme
            },
            error: function (xhr) {
                alert("Hata oluştu: " + xhr.responseText);
            }
        });
    }
}

function deleteBookFunction(id) {
    if (confirm('Are you sure you want to delete Book?')) {
        $.ajax({
            type: 'POST',
            url: '/Book/Delete/' + id,
            dataType: 'json',
            success: function (result) {
                alert(result.message); // Başarılı veya başarısız mesajlarına göre düzenleyebilirsiniz
                location.reload(true); // Sayfayı yenileme
            },
            error: function (xhr) {
                alert("Hata oluştu: " + xhr.responseText);
            }
        });
    }
}

function deletePublisherFunction(id) {
    if (confirm('Are you sure you want to delete Publisher?')) {
        $.ajax({
            type: 'POST',
            url: '/Publisher/Delete/' + id,
            dataType: 'json',
            success: function (result) {
                alert(result.message); // Başarılı veya başarısız mesajlarına göre düzenleyebilirsiniz
                location.reload(true); // Sayfayı yenileme
            },
            error: function (xhr) {
                alert("Hata oluştu: " + xhr.responseText);
            }
        });
    }
}

