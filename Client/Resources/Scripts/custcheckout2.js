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
    credits.id = "bookID";
    form.appendChild(credits);

    let submitButton = document.createElement("button");
    submitButton.textContent = "Add to Order";
    submitButton.id = "Submit";
    form.appendChild(submitButton);

    form.addEventListener("submit", function(event)
    {
        event.preventDefault();
        let book = 
        {
            BookID : event.target.elements.bookID.value,
            Title : "",
            Author : "",
            Condition : "",
            Genre : ""
            //Credits : parseInt(customer[0].credits)+parseInt(event.target.elements.credits.value)
        }
        console.log(book);
        GetBook(book)
        form.reset();
    })

    addForm.appendChild(form);
}
function GetBook(book)
{
    fetch("https://localhost:5001/api/books/"+book.BookID).then(function(response)
    {     
        console.log(response);
        return response.json();
    }).then(function(json){
        console.log(json);
        // if (json.CustUserName == "nothing_here_34759842718928765432")
        // {
        //     error.innerHTML = '';
        //     error.appendChild(document.createTextNode("Please enter a valid username and password")); 
        // }
        // else
        // { 
        //     ControlBreak(json, user)
        // }
    });
// .then(res => res.json())
// .then(data => {
//     books = data.map(book=>{
//     //data.forEach(book => {
//     const bookCard = bookCardTemplate.content.cloneNode(true).children[0]
//     const header = bookCard.querySelector("[data-header]")
//     const body = bookCard.querySelector("[data-body]")
//     header.textContent = book.title
//     body.textContent = book.author
    
//     bookCardContainer.append(bookCard)
    
// //     return {title: book.title, author: book.author, element: book}
// })
// })
    // fetch(categoryurl, {method: 'GET', headers : {"Accept" : "application/json", "Content-Type" : 'application/json',},
    // body : JSON.stringify(book)
    // }).then(function(response){     
    //     console.log(response);
    //     return response.json();
    // }).then(function(json){
    //     console.log(json);
    //     if (json.CustUserName == "nothing_here_34759842718928765432")
    //     {
    //         message.innerHTML = '';
    //         message.appendChild(document.createTextNode("Please enter a valid username and password")); 
    //     }
    //     else
    //     { 
    //         ControlBreak(json, user)
    //     }
    // });
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