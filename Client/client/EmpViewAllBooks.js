function getBooks(){
    const allBooksUrl = "https://localhost:5001/api/books";
    document.getElementById("books").innerHTML="";
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

            li.innerHTML= `Book Title: ${book.Title} <br />
            Date Added: ${dateAdded.toLocaleDateString('en-US')} <br />
            
            `;
            li.appendChild(BookCondition);

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
            editBtn.innerHTML = "Edit";
            

            editBtn.onclick = function () {
                // let bookid = document.getElementById('BookID').value;
                // let conditon = document.getElementById('condition').value;

                editBook(book.BookID, BookCondition.value);
              
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

function postBook(){
    const postDriversApiUrl = "https://localhost:5001/api/books";
    const Title = document.getElementById("Title").value;
    const ISBN = document.getElementById("ISBN").value;
    const Author = document.getElementById("Author").value;
    const Genre = document.getElementById("Genre").value;
    const Price = document.getElementById("Price").value;
    const BookCondition = document.getElementById("BookCondition").value;
    const dateAdded = document.getElementById("DateAdded").value;

    fetch(postDriversApiUrl,
        {
            method: "POST",
            headers: {
                // "Accept": 'application/json',
                // "Content-Type": 'application/json',
                "Content-Type": 'text/plain'
                //"Access-Control-Allow-Origin": 'https://localhost:5001/'
            },
            body: JSON.stringify({
                Title: Title,
                ISBN: ISBN,
                Author: Author,
                Genre: Genre,
                Price: Price,
                BookCondition: BookCondition,
                dateAdded: dateAdded
            }),
            // mode: "no-cors"
        })
        .then((response)=>{
            console.log(response);
            getBooks();
        })
}

function deleteBook(BookID){
    const deleteBooksURL = "https://localhost:5001/api/books" + BookID;
    
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
        // getDrivers();
    })
}
function editBook(BookID, BookCondition, Title, Genre, Author, Price, dateAdded, ISBN){
    const editBooksApiUrl = "https://localhost:5001/api/books" + BookID;
    
    // const id = document.getElementById("id").value;
    // const rating = document.getElementById("rating").value;
    fetch(editBooksApiUrl, {
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            BookID: BookID,
            Title: Title,
            ISBN: ISBN,
            Author: Author,
            Genre: Genre,
            Price: Price,
            BookCondition: BookCondition,
            dateAdded: dateAdded
        })
    })
    .then((response)=>{
        console.log(response);
    })
 }
