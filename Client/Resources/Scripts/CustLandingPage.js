let customer = JSON.parse(sessionStorage.getItem('customerUser'));
let user = document.getElementById("user")

function handleOnLoad()
{
    console.log(employee);
    user.appendChild(document.createTextNode(employee[0].fName)); 
}
function handleOnClick()
{
    location.href = "CustSearchBooks.html"
}