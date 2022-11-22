let addForm = document.getElementById("login")
let error = document.getElementById("error")
const categoryurl = "https://localhost:5001/api/employee"

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
            EmpUserName : event.target.elements.username.value,
            EmpPassword : event.target.elements.password.value,
        }
        GetUser(user);
    })
    addForm.appendChild(form);
}

function GetUser(user)
{
    fetch(categoryurl, {method: 'POST', headers : {"Accept" : "application/json", "Content-Type" : 'application/json',},
    body : JSON.stringify(user)
    }).then((response) => {     
    console.log(response);
    })
}