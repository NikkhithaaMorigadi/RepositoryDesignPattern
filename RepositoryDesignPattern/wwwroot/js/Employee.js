$(document).ready(function () {
    $('#btnSubmit').click(function () {
        var employeeObj = {}
        employeeObj = {
            EmployeeID: $('#eid').val(),
            Name: $('#name').val(),
            Gender: $('#gender').val(),
            Salary: $('#salary').val(),
            Dept: $('#dept').val()
        };
        var empid = $('#eid').val();

        $.ajax({
            data: {
                emp: employeeObj,
                id: empid
            },
            url: "/Home/Edit",
            type: "Post",
            dataType: "json",
            success: function (model) {
                swal({
                    title: "Edit",
                    text: "Successfully Edited",
                    type: "success",
                    button: "OK",
                })
                    .then(okay => {
                        if (okay) {
                            window.location.href = "/Home/Index";
                        }
                    });
            }
        })
    });
    $('#btnCreate').click(function () {
            var employeeObj1 = {}
            employeeObj1 = {
                EmployeeID: $('#eid').val(),
                Name: $('#name').val(),
                Gender: $('#gender').val(),
                Salary: $('#salary').val(),
                Dept: $('#dept').val()
            };

            $.ajax({
                data: {
                    emp: employeeObj1
                },
                url: "/Home/CreateEmp",
                type: "Post",
                dataType: "json",
                success: function (model) {
                    swal({

                        title: "Create",
                        text: "Successfully Created",
                        icon: "success",
                        button: "OK"
                    })
                        .then(okay => {
                            if (okay) {
                                window.location.href = "/Home/Index";
                            }
                        });
                   
                }

               
            });
        
        });
    });



    function edit(EmployeeID) {
        window.location.href = "/Home/Edit?eid=" + EmployeeID;
    }
    function deleteemp(EmployeeID) {
        swal({
            title: "Delete",
            text: "Are you sure want to Delete?",
            icon: "warning",
            buttons: true,

        })
            .then((willDelete) => {
                if (willDelete) {
                    $.ajax({
                        data: { eid: EmployeeID },
                        url: "/Home/Delete",
                        type: "Get",
                        dataType: "json",
                        success: function (model) {

                            window.location.href = "/Home/Index";
                        }

                    });
                }
                else {
                }
                       
                    });
                }
                
           
