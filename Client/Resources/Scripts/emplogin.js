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
        let user = 
        {
            EmpUserName : event.target.elements.username.value,
            EmpPassword : event.target.elements.password.value,
            FName: "",
            LNAME: ""
        }
        GetUser(user);
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
        if (json.EmpUserName == "nothing_here_34759842718928765432")
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
    if(user.EmpUserName == json[0].empUserName && user.EmpPassword == json[0].empPassword)
    {
        sessionStorage.setItem('employeeUser', JSON.stringify(json));
        location.href = "\EmpLandingPage.html"
    }
    else
    {
        error.innerHTML = '';
        error.appendChild(document.createTextNode("Please enter a valid username and password"));
    }
}