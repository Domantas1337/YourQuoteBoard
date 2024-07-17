import React, { createContext, useState, useEffect } from 'react';
import { apiClient } from '../../apiClient';

interface User {
    email: string;
}

export const CurrentUserContext = createContext<User | null>(null);

function UserProvider(props: { children: React.ReactNode }) {
    const [user, setUser] = useState<User | null>(null);

    useEffect(() => {
        const fetchUser = async () => {
            try {
                const response = await apiClient.get('/pingauth');
                if (response.status === 200) {
                    setUser({ email: response.data.email });
                } else {
                    setUser(null);
                }
            } catch (error) {
                console.log(error);
                setUser(null);
            }
        };
        fetchUser();
    }, []);

    return (
        <CurrentUserContext.Provider value={user}>
            {props.children}
        </CurrentUserContext.Provider>
    );
}

export default UserProvider;
