function getBooks(){
    const allBooksUrl = "https://localhost:5001/api/books/";
    document.getElementById("singlebookview").innerHTML="";
    fetch(allBooksUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        console.log(json)
        let ul = document.createElement("ul");
        json.forEach((book)=>{
            let dateAdded = new Date(book.dateAdded);
            let li = document.createElement("li");

            let BookCondition = document.createElement("select");
            for(let i = 0; i<6; i++){
                BookCondition.innerHTML+=`<option>${i}</option>`;
            }
            BookCondition.value=book.BookCondition;

            li.innerHTML= `Book ID: ${book.bookID} <br />
            Book Title: ${book.title} <br />
            Date Added: ${dateAdded.toLocaleDateString('en-US')} <br />
            Author: ${book.author} <br />
            ISBN: ${book.isbn} <br />
            Condition: ${book.condition} <br />

            
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

            