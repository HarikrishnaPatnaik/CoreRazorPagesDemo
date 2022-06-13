function deleteEmployee(id) {
    if (confirm("Do you want to delete employee with id: " + id + "?")) {
        var deleteData = {
            Id: id,
            FirstName: $("txtDeleteFName").val(),
            LastName: $("txtDeleteLName").val(),
            Email: $("txtDeleteEmail").val(),
            Gender: $("txtDeleteGender").val(),
            Salary: $("txtDeleteSalary").val()
        };
        alert(deleteData);
        $.ajax({
            url: "/Employees/Delete",
            method: "POST",
            data: deleteData,
            type:"Json",
            success: function (response, status) {
                alert('Record deleted successfully, Redirecting to Home page.');
            },
            error: function (response) {
                alert('Error occurred while deleting.')
            }
        });
    }
    else
        return false;
}