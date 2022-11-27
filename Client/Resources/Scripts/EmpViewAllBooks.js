function getBooks(){
    const allBooksUrl = "https://localhost:5000/api/books";
    document.getElementById("books").innerHTML="";
    fetch(allBooksUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let ul = document.createElement("ul");
        json.forEach((book)=>{
            let dateAdded = new Date(book.dateAdded);
            let li = document.createElement("li");

            let condition = document.createElement("select");
            for(let i = 0; i<6; i++){
                condition.innerHTML+=`<option>${i}</option>`;
            }
            condition.value=book.condition;

            li.innerHTML= `Book Title: ${book.Title} <br />
            Date Added: ${dateAdded.toLocaleDateString('en-US')} <br />
            
            `;
            li.appendChild(condition);

            let deleteBtn = document.createElement("button"); //created delete button
            deleteBtn.innerHTML = "Remove Book";

            //onclick what it does pass book id
            deleteBtn.onclick = function () { 
                deleteBook(book.BookID);
                li.remove();
              };

              //added onto list items
            li.appendChild(deleteBtn);
            ul.appendChild(li);

            let editBtn = document.createElement("button"); //created edit button
            editBtn.innerHTML = "Edit Condition";
            

            editBtn.onclick = function () {
                let bookid = document.getElementById('BookID').value;
                let conditon = document.getElementById('condition').value;

                editBook(book.BookID, condition.value);
              
            };

            li.appendChild(editBtn);
            ul.appendChild(li);
     
        });
       
        document.getElementById("books").appendChild(ul);
        console.log(json);
    }).catch(function(error){
        console.log(error);
    });
}