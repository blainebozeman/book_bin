function getBooks(){
    const allBooksApiUrl = "https://localhost:5001/api/books"

    fetch(allBooksApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html = "<ul>";
        json.foreach((book)=>{
            html += "<li>" + book.Title + " Written by " + book.Author + "</li>";
        });
        html += "</ul>";
        document.getElementById("homePageBooks").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}
