let employee = JSON.parse(sessionStorage.getItem('employeeUser'));
let user = document.getElementById("user")


function handleOnLoad()
{
    console.log(employee);
    user.appendChild(document.createTextNode(employee[0].fName)); 
}

function handleOnClick()
{
    location.href = "AddCustomer.html"
}