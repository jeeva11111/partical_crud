//// populating the student list



//$(document).ready(function () {
//    //    BindSchoolData();
//    loadCountries();


//    $("#Country").change(function () {
//        var countryId = $(this).val();
//        if (countryId) {
//            $.ajax({
//                type: "GET",
//                url: "/DropDown/GetCountries",
//                data: { countryId: countryId },
//                success: function (data) {
//                    populateDropdown("#State", data);
//                }
//            });
//        }
//    });

//    function loadCountries() {
//        $.ajax({
//            type: "GET",
//            url: "/DropDown/GetCountries",
//            success: function (data) {
//                populateDropdown("#Country", data);
//            }
//        });
//    }

//    function populateDropdown(selector, data) {
//        var dropdown = $(selector);
//        dropdown.empty();
//        $.each(data, function (index, item) {
//            dropdown.append($("<option />").val(item.Id).text(item.StateName));
//        });
//    }
//});


//$("#file-uploading-img").on("change", function () {
//    var currentObject = $(this);
//    var files = currentObject[0].files;

//    if (files.length > 0) {
//        var filename = files[0].name;
//        var extension = filename.substr(filename.lastIndexOf("."));
//        var allowedExtensionsRegx = /(\.jpg|\.jpeg|\.png|\.gif)$/i;

//        var isAllowed = allowedExtensionsRegx.test(extension);

//        if (isAllowed) {
//            $("#successMessage").show('modal')
//            $("#errorMessage").hide('modal')

//        } else {
//            $("#errorMessage").show('modal')
//            $("#successMessage").hide('modal')
//            currentObject.val("");
//            return false;
//        }
//    }
//});


//// fetching the data
//function BindSchoolData() {
//    $.ajax({
//        url: "school/GetDetails",
//        type: "GET",
//        success: function (result) {
//            $('#divcontentMain').html(result);
//        },
//        error: function (errormessage) {
//            console.log(errormessage.statusCode)
//        }
//    });
//}

//// close
//$(document).on('click', '.close', function () {
//    $("#AddUpdateModelPopup").modal('hide');
//});

//$("#Uploadfile").on("click", function () {
//    var currentObject = $(this);
//    var files = currentObject[0].files;

//    if (files.length > 0) {
//        var filename = files[0].name;
//        var extension = filename.substr(filename.lastIndexOf("."));
//        var allowedExtensionsRegx = /(\.jpg|\.jpeg|\.png|\.gif)$/i;
//        var isAllowed = allowedExtensionsRegx.test(extension);

//        if (isAllowed) {
//            alert("File type is valid for the upload");
//        }
//        else {
//            alert("Invalid File Type.");
//            currentObject.val("");
//            return false;
//        }
//    }
//});

//// Model popUp
//function OpenAddPopup() {
//    $.ajax({
//        url: "/School/AddModel",
//        type: "GET",
//        success: function (result) {
//            $('#divcontent').empty();
//            $('#divcontent').html(result);
//            $('#AddUpdateModelPopup').modal('show');
//        },
//        error: function (key, status) {
//            console.log(status)
//        }
//    })
//}


//// Adding a new student
//function AddStudent() {
//    var formData = new FormData();
//    formData.append("Name", $("#Name").val());
//    formData.append("Email", $("#Email").val());
//    formData.append("Department", $("#Department").val());
//    formData.append("Image", $("#Image")[0].files[0]);

//    var check = validation();
//    if (check) {
//        $.ajax({
//            url: "/School/AddModel",
//            data: formData,
//            type: "POST",
//            dataType: 'Json',
//            processData: false,
//            contentType: false,
//            success: function (result) {
//                BindSchoolData();
//                $('#AddUpdateModelPopup').modal('hide');
//            },
//            error: function (error) {
//                console.log(error.responseText);
//            }
//        });
//    }
//}




//function UpdateStudent() {
//    var StudentObj = {
//        Id: $("#Id").val(),
//        Name: $("#Name").val(),
//        Email: $("#Email").val(),
//        Department: $("#Department").val(),
//        ImageData: $("#Image").val(),
//    }

//    if (StudentObj.Id <= 0 || !StudentObj.Id) {
//        alert("Invalid Id");
//        return false;
//    }

//    var check = validation();
//    if (!check) {
//        $.ajax({
//            url: "/school/UpdateStudent/",
//            data: StudentObj,
//            dataType: "json",
//            type: "PUT",
//            success: function (data) {
//                BindSchoolData();
//                $('#AddUpdateModelPopup').modal('hide');
//            },
//            error: function (error) {
//                alert(error.responseText);
//            }
//        });
//    }
//}


//function OpenUpdatePopup(Id) {
//    $.ajax({
//        url: '/School/UpdateStudent?Id=' + Id,
//        dataType: "HTML",
//        type: "GET",
//        success: function (result) {
//            $('#divcontent').empty();
//            $('#divcontent').html(result);
//            $('#AddUpdateModelPopup').modal('show');
//        },
//        error: function (xht, status) {
//            alert(status);
//        }
//    })
//}


//// function for Delete
//function DeleteStudent(Id) {
//    var ans = confirm("Are you sure you want to delete ? ");
//    if (ans) {
//        $.ajax({
//            url: "/School/DeleteModel?Id=" + Id,
//            type: "POST",
//            contentType: "application/json;charset=UTF-8",
//            dataType: "Json",
//            success: function (result) {
//                BindSchoolData();
//            }, error: function (error) {
//                alert(error.responseText)
//            }
//        })
//    }
//}


//// search funcnility
//function changeEvent() {
//    $("#textSearch").keyup(function () {
//        var typedValue = $(this).val().toLowerCase();

//        var noDataFoundMessage = $("#noDataFoundMessage");

//        if (typedValue === "") {
//            $('tbody tr').show();
//            noDataFoundMessage.hide();
//            return;
//        }

//        var matchingRows = $('tbody tr').filter(function () {
//            return $(this).text().toLowerCase().search(new RegExp(typedValue, "i")) >= 0;
//        });

//        matchingRows.show();
//        $('tbody tr').not(matchingRows).hide();

//        if (matchingRows.length === 0) {
//            noDataFoundMessage.show();
//        } else {
//            noDataFoundMessage.hide();
//        }
//    });
//}

//function validation() {
//    var name = $("#Name").val();
//    var email = $("#Email").val();
//    var Department = $("#Department").val();
//    var Image = $("#Image")[0].files[0];

//    var vaild = true;
//    if (name == '' || name.trim() == ' ') {
//        vaild = false;
//        $("#NameVali").text("please enter the name");
//    }
//    else {
//        $("#NameVali").text("");
//    }
//    if (email == '') {
//        $("#EmailVali").text("please enter the Email");
//        vaild = false;
//    }
//    else if (!emailvalidate(email)) {
//        vaild = false;
//        $("#EmailVali").text("please enter the vaild Email");
//    }
//    else {
//        $("#EmailVali").text("");
//    }

//    if (Department == '') {
//        $("#DepartmentVali").text("please enter the Department");
//        vaild = false;
//    }

//    else {
//        $("#DepartmentVali").text("");
//    }

//    var image = $("#Image").val();
//    if (!image) {
//        alert("Image is required.");
//        vaild = false;
//    }
//    return vaild;
//}

//function emailvalidate(email) {
//    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
//    var s = emailRegex.test(email)
//    return s;
//}





//$(document).ready(function () {
//    loadCountries();
//    $("#Country").change(function () {
//        var countryId = $(this).val();
//        if (countryId) {
//            loadStates(countryId);
//        }
//    });

//    function loadCountries() {
//        $.ajax({
//            type: "GET",
//            url: "/DropDown/GetCountries",
//            success: function (data) {
//                populateDropdown("#Country", data);
//            }
//        });
//    }

//    function loadStates(countryId) {
//        $.ajax({
//            type: "GET",
//            url: "/DropDown/GetStatesByCountry",
//            data: { countryId: countryId },
//            success: function (data) {
//                populateDropdown("#State", data);
//            }
//        });
//    }

//    function populateDropdown(selector, data) {
//        var dropdown = $(selector);
//        dropdown.empty();
//        $.each(data, function (index, item) {
//            dropdown.append($("<option />").val(item.Id).text(item.StateName));
//        });
//    }
//});


$(document).ready(function () {
    const inputUsername = $("#inputUsername").val();
    console.log(inputUsername)
});


function GetState() {
    $.get("/DropDown/GetState",
        {
            CountryID: $("#Country").val()
        },
        function (data) {
            $("#StatePartial").html(data)
        }
    )
}


function UserModelAdder() {

    $.ajax({
        url: '/Form/GetTheForm',
        type: 'GET',
        success: function (res) {
            $("#UserAdderModelContainer").html(res)
            $("#UserModelAdd").modal('show');
        }, error: function (xhr, status, error) {
            console.log(error);
        }
    })
}





$('#country-list').on('change', function () {
    var countryId = $(this).val();
    $.ajax({
        url: '/Form/GetStates',
        type: 'GET',
        data: { id: countryId },
        success: function (data) {
            $('#state-id').empty();
            $('#state-id').append($('<option>').text('Please select a state'));
            $.each(data, function (index, state) {
                $('#state-id').append($('<option>').val(state.id).text(state.stateName));
            });
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
});


// State dropdown change event
$('#state-id').change(function () {
    var stateId = $(this).val();
    $.ajax({
        url: '/Form/GetCities',
        type: 'GET',
        data: { id: stateId },
        success: function (res) {
            $('#city-list').empty();
            $('#city-list').append($('<option>').text('Please select a city'));
            $.each(res, function (idx, val) {
                $('#city-list').append($('<option>').val(val.id).text(val.cityName));
            });
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
});

// Submit form event
$("#createForm").on('submit', function (e) {
    e.preventDefault();
    let formdata = new FormData(this);
    $.ajax({
        url: '/Form/PostForm',
        type: 'POST',
        contentType: false,
        processData: false,
        data: formdata,
        success: function (Res) {
            console.log("model hiden")
            $("#userModel").modal('hide');
        },
        error: function (res) {
            console.log(res);
        }
    });
});

$("#userFileUpload").on('submit', function (e) {
    e.preventDefault();

    let formData = new FormData(this);
    $.ajax({
        url: '/Form/PostNewUser',
        type: 'POST',
        contentType: false,
        processData: false,
        data: formData,
        success: function (res) {
            $("#UserModelAdd").modal('hide');
            console.log("model hiden")


            $("#userFileUpload")[0].reset();
            console.log("Form fields reset");
        }, error: function (res) { console.log(res) }
    })
})

function Typo() {

    // while (true) {
    $.ajax({
        url: '/ImageUploads/PopTester',
        type: 'GET',
        contentType: 'Application/json',
        success: function () {

            $("#Content").modal('show');

        }, error: function (error) {
            console.log(error)
        }
    })
    // }
}









// Edit the model based on closest input box
$("#tblCategory .Edit").on("click", function () {

    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            $(this).find("input").show();
            $(this).find("label").hide();
        }
    });
    // row.find(".Edit").hide();
    row.find(".Update").show();
    row.find(".Cancel").show();
    row.find(".Delete").hide();
    $(this).hide();
});

// Update the input box with the closest input box
$("#tblCategory .Update").on('click', function () {
    var row = $(this).closest("tr");

    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            $(this).find("input").hide();
            $(this).find("label").show();
        }
    })

    // Collect form data
    var formData = new FormData();
    formData.append("Id", parseInt(row.find(".categoryId").find("label").html()));
    formData.append("Name", row.find(".categoryTitle").find("label").html());
    formData.append("Process", row.find(".processTitle").find("label").html());

    // Get the file input value
    var fileInput = row.find('input[type="file"]')[0];
    var file = fileInput.files[0];
    formData.append("FormFile", file);

    $.ajax({
        type: "POST",
        url: "/Course/Edit",
        data: formData,
        processData: false,
        contentType: false,
        success: function () {

          
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
});



$("#tblCategory .Delete").on('click', function () {

    var row = $(this).closest('tr');
    var Id = parseInt(row.find(".categoryId").find("label").html())
    $(this).hide();
    row.hide();

    $.ajax({
        type: 'POST',
        url: '/Course/Delete',
        data: { Id: Id },
        success: function () {
            console.info("delete")
        }, error: function () {
            console.log("unable to delete")
        }
    })
})

$("#tblCategory .Cancel").on('click', function () {
    var row = $(this).closest('tr')

    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var lable = $(this).find("label")
            var input = $(this).find("input")
            lable.html(input.val())
            input.hide();
            lable.show();
        }
    })

    //  row.find("input").hide()
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Update").hide();
    $(this).hide();
})





