import { apiClient } from "../apiClient";
import { FolderType } from "../enums/FolderType";
import { FolderContentDisplayDTO } from "../models/folders/FolderContentDisplayDTO";
import { FoldersCreateDTO } from "../models/folders/FolderCreateDTO";
import { FoldersDisplayDTO } from "../models/folders/FolderDisplayDTO";
import { FolderUpdateDTO } from "../models/folders/FolderUpdateDTO";

export async function updateFolder(folder: FolderUpdateDTO, typeOfFolder: FolderType){
    const response = await apiClient.put(`api/Folders/update-${typeOfFolder}-folder`, folder);
    return response;
}

export async function createFolder(folderDTO: FoldersCreateDTO, typeOfFolder: FolderType){
    const response = await apiClient.post(`api/Folders/add-${typeOfFolder}-folder`, folderDTO);

    return response;
}

export async function getQuoteFoldersByUserId(typeOfFolder: FolderType): Promise<FoldersDisplayDTO[] | null>{
    const response = await apiClient.get<FoldersDisplayDTO[]>(`api/Folders/all-${typeOfFolder}-folders-display`); 
    const folders = response.data;

    return folders;
} 

export async function getFolderContentById(id: string, typeOfFolder: FolderType): Promise<FolderContentDisplayDTO | null>{
    const response = await apiClient.get<FolderContentDisplayDTO>(`api/Folders/${typeOfFolder}/${id}`);
    const folder = response.data;
    
    return folder;
}