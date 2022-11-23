const bookCardTemplate = document.querySelector("[data-book-template]")
fetch("https://localhost:5001/api/books")
.then(res => res.json())
.then(data => {
    data.forEach(book => {
    const books = bookCardTemplate.content.cloneNode(true).children[0]
    const header = books.querySelector("[dat-header]")
    const body = books.querySelector("[data-body]")
     
    console.log(books)
})
})
