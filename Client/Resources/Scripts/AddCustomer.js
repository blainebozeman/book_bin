let addForm = document.getElementById("form")
const categoryurl = "https://localhost:5001/api/customers"

function handleOnLoad()
{
    createForm();
}

function createForm()
{
    let form = document.createElement("form");

    let fName = document.createElement("input");
    fName.type = "text";
    fName.placeholder = "First Name";
    fName.id = "firstname";
    form.appendChild(fName);

    let lName = document.createElement("input");
    lName.type = "text";
    lName.placeholder = "Last Name";
    lName.id = "lastname";
    form.appendChild(lName);

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
            FName : event.target.elements.fName.value,
            LName : event.target.elements.lName.value
        }
        PostUser(user)
    })

    addForm.appendChild(form);
}
function PostUser(user)
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