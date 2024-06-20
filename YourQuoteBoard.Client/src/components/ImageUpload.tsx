
/*
import { useState } from "react";
import { uploadImage } from "../api/file";

export default function ImageUpload(){
    const [selectedFile, setSelectedFile] = useState(null);
    const [preview, setPreview] = useState(null);
    const [status, setStatus] = useState('');


    const handleFileChange = async (event) => {
        const file = event.target.files[0];
        
        if(file){
            setPreview(URL.createObjectURL(file));
            setSelectedFile(file);
        }
    }

    const handleUpload = async () =>{
        if (!selectedFile) return;

        setStatus('Processing...');
        
        try{
            const resizedBlob = await resizeImage(selectedFile);

            const formData = new FormData();
            formData.append('file', resizedBlob, selectedFile.name);

            const processedImage = await uploadImage(formData);

            setStatus('Upload successful!');
            console.log(processedImage);
        }catch(error){
            setStatus('Upload failed!');
            console.error(error);
        }
    }

    return (
        <div>
            <h2>Upload image</h2>
            <input type="file" accept="image/*" onChange={handleFileChange} />
            {preview && <img src={preview} alt="Preview" style={{maxWidth: '100%', marginTop: '10px'}}/>}
            <br />
            <button onClick={handleUpload}>Upload</button>
            <p>{status}</p>
        </div>
    )
}*/