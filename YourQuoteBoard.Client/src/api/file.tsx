import { apiClientFile } from "../apiClient/client";

export async function uploadImage(formData: FormData){
    const response = await apiClientFile.post('api/File/iamgeUpload', formData);
    const processedImage = response.data;

    return processedImage;
}