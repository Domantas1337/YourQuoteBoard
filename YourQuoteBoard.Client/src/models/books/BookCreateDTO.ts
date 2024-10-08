
export interface BookCreateDTO{
    title: string;
    description: string;
    author: string;
    pages: number;
    tagIds: string[];
    coverImage: Blob | null;
}