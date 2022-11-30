function getBook(bookid){
    const allBooksUrl = "https://localhost:5001/api/books/";
    allBooksUrl += bookid;
    document.getElementById("singlebookview").innerHTML="";
    fetch(allBooksUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        console.log(json)
        let ul = document.createElement("ul");
        
        let dateAdded = new Date(book.dateAdded);
        let li = document.createElement("li");

        // let BookCondition = 
        // BookCondition.value=book.BookCondition;

        li.innerHTML= `Book ID: ${book.bookID} <br />
        Book Title: ${book.title} <br />
        Date Added: ${dateAdded.toLocaleDateString('en-US')} <br />
        Author: ${book.author} <br />
        ISBN: ${book.isbn} <br />
        Condition: ${book.condition} <br />`;
        ul.appendChild(li);
        ul.appendChild(li);
       
        document.getElementById("singlebookview").appendChild(ul);
        console.log(json);
    }).catch(function(error){
        console.log(error);
    });
}

            