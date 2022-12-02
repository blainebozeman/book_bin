let customer = JSON.parse(sessionStorage.getItem('customerUser'));
let user = document.getElementById("user")

    function handleOnLoad()
    {
        console.log(customer)
        CustomerID.textContent= "Customer ID: " + customer[0].custID;
        CustomerName.textContent = "Customer Name: " + customer[0].fName + " " + customer[0].lName;
        if(customer[0].credits != 0)
        {
            CustomerCredits.textContent = "Customer Credit: $" + customer[0].credits;
        }
        else 
        {
            customer[0].credits = 0
            CustomerCredits.textContent = "Customer Credit: $" + customer[0].credits;
        }
    }
function handleOnClick()
{
    location.href = "SearchBooks.html"
}