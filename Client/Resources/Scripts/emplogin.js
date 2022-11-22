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
            username : event.target.elements.username.value,
            rating : event.target.elements.password.value,
            userType : "employee"
        }
        try
        {
            GetUser(user)
        }
        catch
        {
            error.innerHTML = '';
            error.appendChild(errormessage);
        }
    })
    addForm.appendChild(form);
}

function GetUser(user)
{
    fetch(categoryurl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        console.log(json);
    });

    // fetch(categoryurl, {method: 'GET', headers : {"Accept" : "application/json", "Content-Type" : 'application/json',},
    // body : JSON.stringify(user)
    // }).then(function(response){
    //     console.log(response);
    //     return response.json();
    // }).then(function(json){
    //     console.log(json);
    // });
}