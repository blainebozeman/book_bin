let addForm = document.getElementById("form")
let message = document.getElementById("message")
const categoryurl = "https://localhost:5001/api/customers"
let employee = JSON.parse(sessionStorage.getItem('employeeUser'));

function handleOnLoad()
{
    createForm();
    console.log(employee);
}

function createForm()
{
    let form = document.createElement("form");

    let fName = document.createElement("input");
    fName.type = "text";
    fName.placeholder = "First Name";
    fName.id = "fName";
    form.appendChild(fName);

    let lName = document.createElement("input");
    lName.type = "text";
    lName.placeholder = "Last Name";
    lName.id = "lName";
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
        try
        {
            let user = 
            {
                CustID : employee[0].emp_ID,
                CustUserName : event.target.elements.username.value,
                CustPassword : event.target.elements.password.value,
                FName : event.target.elements.fName.value,
                LName : event.target.elements.lName.value
            }
            console.log(user)
            PostUser(user)
        }
        catch
        {
            let user = 
            {
                CustID : 0,
                CustUserName : event.target.elements.username.value,
                CustPassword : event.target.elements.password.value,
                FName : event.target.elements.fName.value,
                LName : event.target.elements.lName.value
            }
            console.log(user)
            PostUser(user)
        }
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
    if(json[0].custUserName == "nothing_here")
    {
        message.innerHTML = '';
        message.appendChild(document.createTextNode("This user already exists. Please choose another username."));
    }
    else
    {
        message.innerHTML = '';
        message.appendChild(document.createTextNode("Success!"));
    }
}