const bookCardTemplate = document.querySelector("[data-book-template]")
const bookCardContainer = document.querySelector("[data-book-cards-container]")
const searchInput = document.querySelector("[data-search")

let books=[]

searchInput.addEventListener("input", e => {
    const value = e.target.value.toLowerCase()
    books.forEach(book => {
        const isVisble =
        book.title.toLowerCase().includes(value)||
        book.author.toLowerCase().includes(value)
        book.element.classList.toggle("hide", !isVisble)
    })
})

fetch("https://localhost:5001/api/books")
.then(res => res.json())
.then(data => {
    books = data.map(book=>{
    //data.forEach(book => {
    const bookCard = bookCardTemplate.content.cloneNode(true).children[0]
    const header = bookCard.querySelector("[data-header]")
    const body = bookCard.querySelector("[data-body]")
    header.textContent = book.title
    body.textContent = book.author
    
    bookCardContainer.append(bookCard)
    
    return {title: book.title, author: book.author, element: book}
})
})
