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
function PostCustomer(user)
{ console.log(user)
    fetch(categoryurl, {method: 'POST', headers : {"Accept" : "application/json", "Content-Type" : 'application/json',},
    body : JSON.stringify(user)
    }).then((response) => {
        console.log(response);
    })
}