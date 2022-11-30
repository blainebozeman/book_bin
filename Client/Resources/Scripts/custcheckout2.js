let customer = JSON.parse(sessionStorage.getItem('customerUser'));
let employee = JSON.parse(sessionStorage.getItem('employeeUser'));
console.log(employee)
const categoryurl = "https://localhost:5001/api/customers"
const reporturl = "https://localhost:5001/api/report"

let CustomerID = document.getElementById("CustomerID");
let CustomerName = document.getElementById("CustomerName");
let CustomerCredit = document.getElementById("CustomerCredits");
let addForm = document.getElementById("addForm");
let message = document.getElementById("message");
let booksList = document.getElementById("books")
let totalPrice = document.getElementById("totalPrice")
let price= 0;
let drivers = [];
//Navigation
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
function handleBack()
{
    location.href = "\EmpLandingPage.html."
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
        if (json.title == "nothing_here_34759842718928765432")
        {
            message.innerHTML = '';
            message.appendChild(document.createTextNode("Please enter a valid book ID")); 
        }
        else
        { 
            ControlBreak(json)
        }
    });
}
function ControlBreak(json)
{
    price = price + json.price
    totalPrice.innerHTML= ""
    totalPrice.appendChild(document.createTextNode("Total Price: $" + price));
    drivers.push(json)
    createTable(drivers)
}
function createTable(driverData)
{
    booksList.innerHTML = "";
let table = document.createElement("table");
    
table.style.border = "1px solid #000";
table.id = "driversTable";

let tableBody = document.createElement("tbody");
tableBody.style.border = "1px solid #000";
tableBody.id = "driverstableBody";
table.appendChild(tableBody);

let tableRow = document.createElement("tr");
tableRow.style.border = "1px solid #000";
tableBody.appendChild(tableRow);

let tableHeader1 = document.createElement("th");
tableHeader1.style.width = "100px"
tableHeader1.style.border = "1px solid #000";
tableHeader1.appendChild(document.createTextNode('Book ID'));
tableRow.appendChild(tableHeader1);

let tableHeader2 = document.createElement("th");
tableHeader2.style.width = "200px"
tableHeader2.style.border = "1px solid #000";
tableHeader2.appendChild(document.createTextNode('Book Title'));
tableRow.appendChild(tableHeader2);

let tableHeader3 = document.createElement("th");
tableHeader3.style.border = "1px solid #000";
tableHeader3.appendChild(document.createTextNode('Book Price'));
tableRow.appendChild(tableHeader3);
driverData.forEach (driver => {
    let tr = document.createElement("tr");
    tableBody.appendChild(tr);
    
    let td1 = document.createElement("td");
    td1.style.border = "1px solid #000";
    td1.appendChild(document.createTextNode(`${driver.bookID}`));
    tr.appendChild(td1);
    
    let td2 = document.createElement("td");
    td2.style.border = "1px solid #000";
    td2.appendChild(document.createTextNode(`${driver.title}`));
    tr.appendChild(td2);
    
    let td3 = document.createElement("td");
    td3.style.border = "1px solid #000";
    td3.appendChild(document.createTextNode(`${driver.price}`));
    tr.appendChild(td3);
})
booksList.appendChild(table);
}
function handleSubmit()
{
    let temp;
    UpdateBook();
    PostOrder();
}
function UpdateBook()
{
    drivers.forEach (driver => {
        const deleteBooksURL = "https://localhost:5001/api/books/" + driver.bookID;
        
        fetch(deleteBooksURL, {
            method: "DELETE",
            headers: {
                "Accept": 'application/json',
                "Content-Type": 'application/json'
                // 'Access-Control-Allow-Origin, https://localhost:5001/api/books'
            }
        
        })
    
        .then((response)=> {
            console.log(response);
        })
    })
}
function PostOrder()
{
    let user = 
    {
        Cust_id : customer[0].custID,
        EmpId : employee[0].emp_ID,
        TotalAmount : price
    }
    fetch(reporturl, {method: 'POST', headers : {"Accept" : "application/json", "Content-Type" : 'application/json',},
    body : JSON.stringify(user)
    }).then(function(response){     
        console.log(response);
        return response.json();
    }).then(function(json){
        console.log(json)
        //PostOrderItemized(json)
    });
}
function PostOrderItemized(temp)
{
        drivers.forEach (driver => {
            let user = 
            {
                OrderID : temp.OrderID,
                BookID : driver.BookID
            }
            const itemizedOrderURL = "https://localhost:5001/api/itemizedorder";
            
            fetch(itemizedOrderURL, {
                method: "POST",
                headers: {
                    "Accept": 'application/json',
                    "Content-Type": 'application/json'
                    // 'Access-Control-Allow-Origin, https://localhost:5001/api/books'
                },
                body : JSON.stringify(user)
            })
        
            .then((response)=> {
                console.log(response);
            })
        })
}