let addForm = document.getElementById("login")
const categoryurl = "https://localhost:5001/api/customers"
let error = document.getElementById("error")


function handleOnLoad()
{
    createForm();
}

function createForm()
{
    let form = document.createElement("form");

    let user = document.createElement("input");
    user.type = "text";
    user.placeholder = "Username";
    user.id = "username";
    form.appendChild(user);

    let pass = document.createElement("input");
    pass.type = "text";
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
        // try
        // {
            PostCustomer(user)
        // }
        // catch
        // {
        //     error.innerHTML = '';
        //     error.appendChild(errormessage);
        // } 
    })

    addForm.appendChild(form);
}
function GetUser(user)
{
    fetch(categoryurl, {method: 'POST', headers : {"Accept" : "application/json", "Content-Type" : 'application/json',},
    body : JSON.stringify(user)
    }).then(function(response){     
        console.log(response);
        return response.json();
    }).then(function(json){
        console.log(json);
        ControlBreak(json, user)
    });
}
function ControlBreak(json, user)
{
    if(user.CustUserName == json[0].custUserName && user.CustPassword == json[0].custPassword)
    {
        sessionStorage.setItem('employeeUser', JSON.stringify(json));
        location.href = "\CustLandingPage.html"
    }
    else
    {
        error.innerHTML = '';
        error.appendChild(document.createTextNode("Please enter a valid username and password"));
    }
}