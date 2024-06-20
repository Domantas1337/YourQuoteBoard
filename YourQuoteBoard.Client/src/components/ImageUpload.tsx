import { ChangeEvent, useState } from "react";
import pica from 'pica';

interface ImageUploadButtonProps {
    onImageUpload: (file: Blob) => void;
}

export default function ImageUploadButton({onImageUpload} : ImageUploadButtonProps){
    const [preview, setPreview] = useState<string | null>(null);

    const resizeImage = async (file: File) : Promise<Blob | null> => {
        const img = new Image();
        img.src = URL.createObjectURL(file);
        await img.decode();

        const picaInstance = pica();
        const canvas = document.createElement('canvas');
        canvas.width = 600;
        canvas.height = 800;

        await picaInstance.resize(img, canvas);
        
        return new Promise((resolve) => {
            canvas.toBlob((blob) => resolve(blob), file.type);
        });
    };

    const handleFileChange = async (event: ChangeEvent<HTMLInputElement>) => {
        const file = event.target.files?.[0];
        
        if(file){
            setPreview(URL.createObjectURL(file));

            const resizedBlob = await resizeImage(file);
            if (resizedBlob) {
                onImageUpload(resizedBlob);
            }
        }
    }


    return (
        <div>
            <input type="file" accept="image/*" onChange={handleFileChange} />
            {preview && <img src={preview} alt="Preview" style={{maxWidth: '100%', marginTop: '10px'}}/>}
        </div>
    )
}