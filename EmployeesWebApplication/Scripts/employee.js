$(function () {
    $('#BtnGetEmployees').on('click', function () {
        var id = $('#EmployeeId').val();
        var url = "http://localhost:63830/api/Employees";

        if (id !== '') url = url + "/" + id;

        var $employees = $('#Employees');
        $.ajax({
            url: url,
            type: 'GET',
            datatype: 'jsonp',
            success: function (employeesData) {
                if (employeesData !== null ) {
                    var $headers = $('<table>', { "class": 'table table-hover' }).append(
                        $('<thead>').append(
                            $('<tr>').append(
                                $('<th>', { html: "Id" }),
                                $('<th>', { html: "Name" }),
                                $('<th>', { html: "Contract type" }),
                                $('<th>', { html: "Role" }),
                                $('<th>', { html: "Hourly salary" }),
                                $('<th>', { html: "Monthly salary" }),
                                $('<th>', { html: "Annual salary" })
                            )
                        ),
                        $('<tbody>')
                    );

                    $employees.html($headers);

                    if (employeesData.length > 0) {
                        $.each(employeesData, function (i, item) {
                            var $row = employeeRow(item);
                            $employees.find('tbody').append($row);
                        });
                    } else {
                        $employees.find('tbody').append(employeeRow(employeesData));
                    }
                } else {
                    $employees.html($('<div>', { "class": 'alert alert-warning', "role": 'alert', html: "No employees has been found"}));
                }
            },
            error: function (xhr) {
                if (xhr.status === 404 ) {
                    $employees.html($('<div>', { "class": 'alert alert-warning', "role": 'alert', html: "No employees has been found" }));
                    return;
                }
                $employees.html($('<div>', { "class": 'alert alert-warning', "role": 'alert', html: "An error has ocurred" }));
            }
        });
    });
});

function employeeRow(employee) {
    var $row = $('<tr>').append(
        $('<td>', { html: employee.Id }),
        $('<td>', { html: employee.Name }),
        $('<td>', { html: employee.ContractTypeName }),
        $('<td>', { html: employee.RoleName }),
        $('<td>', { html: formatSalaryToCurrency(employee.HourlySalary) }),
        $('<td>', { html: formatSalaryToCurrency(employee.MonthlySalary) }),
        $('<td>', { html: formatSalaryToCurrency(employee.AnnualSalary) })
    );
    return $row;
}

function formatSalaryToCurrency(salary) {
    return "$"+salary.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
}
