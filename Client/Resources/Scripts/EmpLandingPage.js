let employee = JSON.parse(sessionStorage.getItem('employeeUser'));
let user = document.getElementById("user")


function handleOnLoad()
{
    console.log(employee);
    user.appendChild(document.createTextNode("Welcome, " + employee[0].fName)); 
}

function handleOnClick(temp)
{
    location.href = temp
}