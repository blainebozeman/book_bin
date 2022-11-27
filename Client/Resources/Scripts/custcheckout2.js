let customer = JSON.parse(sessionStorage.getItem('customerUser'));
let employee = JSON.parse(sessionStorage.getItem('employeeUser'));
const categoryurl = "https://localhost:5001/api/customers"

let CustomerID = document.getElementById("CustomerID");
let CustomerName = document.getElementById("CustomerName");
let CustomerCredit = document.getElementById("CustomerCredits");
let addForm = document.getElementById("addForm");
let message = document.getElementById("message");
let booksList = document.getElementById("books")

function handleBack()
{
    location.href = "\EmpLandingPage.html."
}

function handleOnLoad()
{
    createForm()
    SetPage();
}
function SetPage()
{
    console.log(customer)
    CustomerID.textContent= "Customer ID: " + customer[0].custID;
    CustomerName.textContent = "Customer Name: " + customer[0].fName + " " + customer[0].lName;
    if(customer[0].credits != 0)
    {
        CustomerCredit.textContent = "Customer Credit: $" + customer[0].credits;
    }
    else 
    {
        customer[0].credits = 0
        CustomerCredit.textContent = "Customer Credit: $" + customer[0].credits;
    }
}

function createForm()
{
    let form = document.createElement("form");
    let credits = document.createElement("input");
    credits.type = "text";
    credits.placeholder = "BookID to Buy";
    credits.id = "credits";
    form.appendChild(credits);

    let submitButton = document.createElement("button");
    submitButton.textContent = "Add to Order";
    submitButton.id = "Submit";
    form.appendChild(submitButton);

    form.addEventListener("submit", function(event)
    {
        event.preventDefault();
        let user = 
        {
            CustID : customer[0].custID,
            CustUserName : customer[0].custUserName,
            CustPassword : customer[0].custPassword,
            FName : customer[0].fName,
            LName : customer[0].lName,
            Credits : parseInt(customer[0].credits)+parseInt(event.target.elements.credits.value)
        }
        console.log(user);
        PostCustomer(user)
        form.reset();
    })

    addForm.appendChild(form);
}
function PostCustomer(user)
{
    fetch(categoryurl, {method: 'POST', headers : {"Accept" : "application/json", "Content-Type" : 'application/json',},
    body : JSON.stringify(user)
    }).then(function(response){     
        console.log(response);
        return response.json();
    }).then(function(json){
        console.log(json);
        if (json.CustUserName == "nothing_here_34759842718928765432")
        {
            message.innerHTML = '';
            message.appendChild(document.createTextNode("Please enter a valid username and password")); 
        }
        else
        { 
            ControlBreak(json, user)
        }
    });
}
function ControlBreak(json, user)
{
    if(user.CustUserName == json[0].custUserName && user.CustPassword == json[0].custPassword)
    {
        sessionStorage.setItem('customerUser', JSON.stringify(json));
        customer = JSON.parse(sessionStorage.getItem('customerUser'));
        SetPage();
    }
    else
    {
        message.innerHTML = '';
        message.appendChild(document.createTextNode("Sorry, some error has occured"));
    }
}