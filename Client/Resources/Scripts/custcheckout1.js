let addForm = document.getElementById("login")
const categoryurl = "https://localhost:5001/api/customers"
let error = document.getElementById("error")

//Handle on Load
function handleOnLoad()
{
    createForm();
}

//Begin checkout
function handleCheckout()
{
    location.href = "\custcheckout2.html"
}

function handleBack()
{
    location.href = "\EmpLandingPage.html."
}

//Login Form
function createForm()
{
    let form = document.createElement("form");

    let user = document.createElement("input");
    user.type = "text";
    user.placeholder = "Username";
    user.id = "username";
    form.appendChild(user);

    let pass = document.createElement("input");
    pass.type = "password";
    pass.placeholder = "Password";
    pass.id = "password";
    form.appendChild(pass);

    let submitButton = document.createElement("button");
    submitButton.textContent = "Submit";
    submitButton.id = "Submit";
    form.appendChild(submitButton);

    form.addEventListener("submit", function(event)
    {
        event.preventDefault();
        let errormessage = document.createTextNode("Please enter a valid username and password")
        let user = 
        {
            CustUserName : event.target.elements.username.value,
            CustPassword : event.target.elements.password.value,
            FName : "",
            LName : ""
        }
            PostCustomer(user)
    })

    addForm.appendChild(form);
}

//Login Check
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
            error.innerHTML = '';
            error.appendChild(document.createTextNode("Please enter a valid username and password")); 
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
        error.appendChild(document.createTextNode("User Found!"));

    }
    else
    {
        error.innerHTML = '';
        error.appendChild(document.createTextNode("Please enter a valid username and password"));
    }
}
