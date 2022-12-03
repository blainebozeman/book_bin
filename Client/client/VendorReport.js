function getVendorReport()
{
    const allVendorReportURL = "https://localhost:5001/api/vendorreport";
    document.getElementById("books").innerHTML="";
    fetch(allVendorReportURL).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        console.log(json)
        let ul = document.createElement("ul");
        createTable(json)
    })
}
function createTable(driverData)
{
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
tableHeader1.style.width = "250px"
tableHeader1.style.border = "1px solid #000";
tableHeader1.appendChild(document.createTextNode('Vendor or Customer Name'));
tableRow.appendChild(tableHeader1);

let tableHeader2 = document.createElement("th");
tableHeader2.style.width = "200px"
tableHeader2.style.border = "1px solid #000";
tableHeader2.appendChild(document.createTextNode('Number of Books Sold'));
tableRow.appendChild(tableHeader2);

// let tableHeader3 = document.createElement("th");
// tableHeader3.style.border = "1px solid #000";
// tableHeader3.appendChild(document.createTextNode('Book Price'));
// tableRow.appendChild(tableHeader3);
driverData.forEach (driver => {
    let tr = document.createElement("tr");
    tableBody.appendChild(tr);
    
    let td1 = document.createElement("td");
    td1.style.border = "1px solid #000";
    td1.appendChild(document.createTextNode(`${driver.vendororCustomerName}`));
    tr.appendChild(td1);
    
    let td2 = document.createElement("td");
    td2.style.border = "1px solid #000";
    td2.appendChild(document.createTextNode(`${driver.numberofBooksSold}`));
    tr.appendChild(td2);
    
    let td3 = document.createElement("td");
    td3.style.border = "1px solid #000";
    td3.appendChild(document.createTextNode(`${driver.price}`));
    tr.appendChild(td3);
})
document.getElementById("books").appendChild(table);
}
