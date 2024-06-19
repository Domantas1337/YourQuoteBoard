import { apiClient } from "../apiClient";
import { BookCreateDTO } from "../models/books/BookCreateDTO";
import BookDisplayDTO from "../models/books/BookDisplayDTO";

export async function getAllBooks(): Promise<BookDisplayDTO[]>{
    const response = await apiClient.get<BookDisplayDTO[]>('api/Book/all-books') 
    const books = response.data;

    return books;
}

export async function getBookById(id: string){
    const response = await apiClient.get(`api/Book/get-display/${id}`)
    const book = response.data;

    return book;
}


export async function createBook(newBook: BookCreateDTO){
    const response = await apiClient.post('api/Book/add-book', newBook)

    return response
}
