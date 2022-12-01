const bookCardTemplate = document.querySelector("[data-book-template]")
const bookCardContainer = document.querySelector("[data-book-cards-container]")
const searchInput = document.querySelector("[data-search]")

let books=[]

searchInput.addEventListener("input", e => {
    const value = e.target.value.toLowerCase()
    let searchedBooks = books;
    if(value != '') {
        searchedBooks = searchedBooks.filter((book) => book.title.toLowerCase().startsWith(value));
    }
    loadBooks(searchedBooks);
})


fetch("https://localhost:5001/api/books")
.then(res => res.json())
.then(data => {
    books = data;
    loadBooks(data);
})

function loadBooks(data) {
    bookCardContainer.innerHTML = '';
    data.map(book => {
        const card= bookCardTemplate.content.cloneNode(true).children[0]
       const header = card.querySelector("[data-header]")
       const body = card.querySelector("[data-body]")
       header.textContent = book.title
       body.textContent = "Author: "+ book.author +" Price: "+ book.price +" Condition: "+book.condition
       
        bookCardContainer.append(card)
        return {title: book.title, author: book.author, price: book.price, condition: book.condition, element: card}
   })
   //console.log(books);
}