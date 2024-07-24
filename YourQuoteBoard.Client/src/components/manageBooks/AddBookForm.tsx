import { useEffect, useState } from "react";
import { BookCreateDTO } from "../../models/books/BookCreateDTO";
import { createBook } from '../../api/book';
import ImageUploadButton from "../managers/ImageUpload";
import { TagDisplayDTO } from "../../models/tag/TagDisplayDTO";
import { getDefaultTags } from "../../api/tag";
import { TagType } from "../../enums/TagType";
import "./BookForm.css";
import TagSelect from "../tags/TagSelect";
import TagListAfterSelect from "../tags/TagListAfterSelect";

export default function AddBookForm(){

    const [book, setBook] = useState<BookCreateDTO>({
        title: '', 
        description: '', 
        author: '', 
        pages: 0, 
        coverImage: null,
        tagIds: []
    });

    const [tags, setTags] = useState<TagDisplayDTO[]>([]);
    const [selectedTag, setSelectedTag] = useState<TagDisplayDTO | null>(null);

    useEffect(() => {
        const fetchTags = async () => {
            try{
                const fetchedTags = await getDefaultTags(TagType.Book);
                
                setTags(fetchedTags);
            }catch(error){
                console.log("Failed to fetch tags: ", error);
            }
        }

        fetchTags();
    }, []);

    function handleTagSelection(tag: TagDisplayDTO){
        setSelectedTag(tag)
    }

    function handleTagAddition(){
        if (selectedTag == null || book.tagIds.length > 4){
            return;
        }

        if(!book.tagIds.includes(selectedTag.tagId)){
            setBook(prevBook => ({
                ...prevBook,
                tagIds: [...prevBook.tagIds, selectedTag.tagId]
            }));

        }else{
            console.log(selectedTag);
        }
    }

    function handleNewInput(e : React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>){
        setBook(prevBook => ({
            ...prevBook,
            [e.target.name]: e.target.value
        }));
    }

    function handleImageUpload(file: Blob){
        setBook(prevBook => ({
            ...prevBook,
            coverImage: file
        }));
    }

    function removeTag(tagToRemove: string) {
        setBook(prevBook => ({
            ...prevBook,
            tags: prevBook.tagIds.filter(tagId => tagId !== tagToRemove)
        }));
    }

    async function handleSubmit(e: React.FormEvent<HTMLFormElement>){
        e.preventDefault();
        try{
            const response = createBook(book);
            
            console.log('Book submitted:', response);
            setBook({title: '', description: '', author: '', pages: 0, coverImage: null, tagIds: []});
        } catch (error) {
            console.error('Failed to submit book:', error);
        }
    }

    
    return (
        <div className="default-form-container">
            <form className="default-form" onSubmit={handleSubmit}>
                <h1 className="default-header">Add a book</h1>

                <div className="form-group">
                    <label 
                        htmlFor="titleInput"
                        className="default-label"
                        >Book title</label>
                    <input 
                        type="text" 
                        className="form-control" 
                        id="titleInput" 
                        name="title"
                        value={book.title}
                        onChange={handleNewInput}
                        />
                </div>
                <div className="form-group">
                    <label 
                        htmlFor="authorInput"
                        className="default-label"
                        >Book author</label>
                    <input 
                        type="text" 
                        className="form-control" 
                        id="authorInput" 
                        name="author"
                        value={book.author}
                        onChange={handleNewInput}
                        />
                </div>
                <div className="form-group">
                    <label 
                        htmlFor="pageInput"
                        className="default-label"
                        >Number of pages</label>
                    <input 
                        type="number" 
                        className="form-control" 
                        id="pageInput" 
                        name="pages"
                        value={book.pages}
                        onChange={handleNewInput}
                        />
                </div>
                <div className="form-group">
                    <label 
                        htmlFor="descriptionInput"
                        className="default-label"
                        >Book description</label>
                    <textarea 
                        className="form-control" 
                        id="descriptionInput"
                        name="description"
                        value={book.description}
                        onChange={handleNewInput}
                        ></textarea>
                </div>

                <TagSelect onSelectedFromList={handleTagSelection} onTagAddition={handleTagAddition} tagType={TagType.Book}></TagSelect> 
                <TagListAfterSelect tags={tags} selectedTagIds={book.tagIds}  onRemoveTag={removeTag} />

                <div className="form-group">
                    <label 
                        htmlFor="imageInput"
                        className="default-label"
                        >Cover image of the book</label>
                    <ImageUploadButton onImageUpload={handleImageUpload} />
                </div>
                <button type="submit" className="btn btn-default submit-button">Submit book</button>
            </form>
        </div>
        );
}
