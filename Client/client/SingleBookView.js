let book = JSON.parse(sessionStorage.getItem('bookItem'));
let booksList = document.getElementById("books")

// function getBook()
// {
//     event.preventDefault();
//     var allBooksUrl = "https://localhost:5001/api/books/";
//     let singleBookID = document.getElementById("singleBookID").value;
//     console.log(singleBookID);
//     allBooksUrl += singleBookID;
//     let book = 
//     {
//         BookID : singleBookID,
//         Title : "",
//         Author : "",
//         Condition : "",
//         Genre : "",
//         VendororCustomerName: ""
//     }
//     console.log(book);
//     GetBook(book);
// }
function GetBook()
{
    // fetch("https://localhost:5001/api/books/"+book.BookID).then(function(response)
    // {     
    //     console.log(response);
    //     return response.json();
    // }).then(function(json){
    //     console.log(json);
    //     if (json.title == "nothing_here_34759842718928765432")
    //     {

    //     }
    //     else
    //     { 
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
            tableHeader3.style.width = "200px"
            tableHeader3.style.border = "1px solid #000";
            tableHeader3.appendChild(document.createTextNode('Author'));
            tableRow.appendChild(tableHeader3);

            let tableHeader4 = document.createElement("th");
            tableHeader4.style.width = "100px"
            tableHeader4.style.border = "1px solid #000";
            tableHeader4.appendChild(document.createTextNode('Genre'));
            tableRow.appendChild(tableHeader4);

            let tableHeader5 = document.createElement("th");
            tableHeader5.style.width = "100px"
            tableHeader5.style.border = "1px solid #000";
            tableHeader5.appendChild(document.createTextNode('ISBN'));
            tableRow.appendChild(tableHeader5);

            let tableHeader6 = document.createElement("th");
            tableHeader6.style.width = "50px"
            tableHeader6.style.border = "1px solid #000";
            tableHeader6.appendChild(document.createTextNode('Price'));
            tableRow.appendChild(tableHeader6);

            // driverData.forEach (driver => {
                let tr = document.createElement("tr");
                tableBody.appendChild(tr);
                
                let td1 = document.createElement("td");
                td1.style.border = "1px solid #000";
                td1.appendChild(document.createTextNode(`${book.bookID}`));
                tr.appendChild(td1);
                
                let td2 = document.createElement("td");
                td2.style.border = "1px solid #000";
                td2.appendChild(document.createTextNode(`${book.title}`));
                tr.appendChild(td2);
                
                let td3 = document.createElement("td");
                td3.style.border = "1px solid #000";
                td3.appendChild(document.createTextNode(`${book.author}`));
                tr.appendChild(td3);

                let td4 = document.createElement("td");
                td4.style.border = "1px solid #000";
                td4.appendChild(document.createTextNode(`${book.genre}`));
                tr.appendChild(td4);

                let td5 = document.createElement("td");
                td5.style.border = "1px solid #000";
                td5.appendChild(document.createTextNode(`${book.isbn}`));
                tr.appendChild(td5);

                let td6 = document.createElement("td");
                td6.style.border = "1px solid #000";
                td6.appendChild(document.createTextNode(`${book.price}`));
                tr.appendChild(td6);
            booksList.appendChild(table);
        }
//     });
// }