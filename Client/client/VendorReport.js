function getVendorReport(){
    const allVendorReportURL = "https://localhost:5001/api/books";
    document.getElementById("books").innerHTML="";
    fetch(allVendorReportURL).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        console.log(json)
        let ul = document.createElement("ul");
        json.forEach((getVendorReport)=>{
            let vendororcustomerName = new String(getVendorReport.vendororCustomerName);
            let li = document.createElement("li");

    
            //Number of Orders: ${getVendorReport.numberOfBooksSold} <br />
            li.innerHTML= `
            Vendor Or Customer Name: ${getVendorReport.vendororCustomerName} <br />

            
            `;
            // li.appendChild(BookCondition);

            // let deleteBtn = document.createElement("button"); //created delete button
            // deleteBtn.innerHTML = "Remove Book";

            // //onclick what it does pass book id
            // deleteBtn.onclick = function () { 
            //     deleteBook(book.BookID);
            //     li.remove();
            //   };

            //   //added onto list items
            // li.appendChild(deleteBtn);
            ul.appendChild(li);

            // let editBtn = document.createElement("button"); //created edit button
            // editBtn.innerHTML = "Edit";
            

            // editBtn.onclick = function () {
            //     // let bookid = document.getElementById('BookID').value;
            //     // let conditon = document.getElementById('condition').value;

            //     editBook(book.BookID, BookCondition.value);
              
            // };

            // li.appendChild(editBtn);
            ul.appendChild(li);
     
        });
       
        document.getElementById("books").appendChild(ul);
        console.log(json);
    }).catch(function(error){
        console.log(error);
    });
}

            