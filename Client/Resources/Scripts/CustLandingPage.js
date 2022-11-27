let customer = JSON.parse(sessionStorage.getItem('customerUser'));
let user = document.getElementById("user")

function handleOnLoad()
{
    console.log(customer)
}
function handleOnClick()
{
    location.href = "CustSearchBooks.html"
}