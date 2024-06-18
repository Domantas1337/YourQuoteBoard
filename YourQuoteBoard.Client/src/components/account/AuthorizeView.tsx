import React, {useState, useEffect, createContext} from 'react';
import { Navigate } from 'react-router-dom';
import { apiClient } from '../../apiClient';

interface User{
    email: string;
}

export const UserContext = createContext<User | null>(null)

function AuthorizeView(props: {children: React.ReactNode}){
    const [authorized, setAuthorized] = useState<boolean>(false);
    const [loading, setLoading] = useState<boolean>(true);
    const emptyUser: User = {email: ""};

    const [user, setUser] = useState(emptyUser);

    useEffect(() => {
        let retryCount = 0;
        const maxRetries = 10;
        const delay: number = 1000;
    
        function wait(delay: number){
            return new Promise((resolve) => setTimeout(resolve, delay));
        }

        async function fetchWithRetry(url: string){
            try{    
                const response = await apiClient.get(url)

                if (response.status == 200){
                    const j = await response.data;
                    
                    setUser({email: j.email});
                    setAuthorized(true);

                    return response;
                }else if(response.status == 401){
                    return response;
                }else{
                    throw new Error("" + response.status);
                }
            }catch(error){
                retryCount++;

                if (retryCount > maxRetries){
                    throw error;
                }else{
                    await wait(delay);
                    return fetchWithRetry(url);
                }
            }
        }

        fetchWithRetry("/pingauth")
            .catch((error) => {
                console.log(error.message);
            })
            .finally(() => {
                setLoading(false);
            })
    }, []);

    if (loading){
        return (
            <>
                <p>Laoding...</p>
            </>
        );
    }else{
        if (authorized && !loading){
            return (
                <>
                    <UserContext.Provider value={user}>{props.children}</UserContext.Provider>
                </>
            )
        }else{
            return(
                <>
                    <Navigate to="/" />
                </>
            )
        }
    }
}

export default AuthorizeView;