import React, { useState } from 'react';
import { loginUser } from '../../api/user';
import { UserLoginDTO } from '../../models/account/UserLoginDTO';

function Login() {
    const [user, setUser] = useState<UserLoginDTO>({email: '', password: ''});

    function handleChange(e: React.ChangeEvent<HTMLInputElement>) {
        setUser((prevUser: UserLoginDTO) => ({
            ...prevUser,
            [e.target.name]: e.target.value
        }));
    }

    async function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        try {
            const response = await loginUser(user);
            console.log('User: ', response);
            setUser({email: '', password: ''}); 
        } catch (error) {
            console.error('Failed to login user:', error);
        }
    }

    return (
        <div className="auth-container">
            <h1 className="auth-header">Login</h1>
            <form className="auth-form" onSubmit={handleSubmit}>
                <div className="auth-form-group">
                    <label htmlFor="emailInput" className="auth-label">Email</label>
                    <input 
                        type="email" 
                        className="auth-form-control" 
                        id="emailInput" 
                        name="email"
                        value={user.email}
                        onChange={handleChange}
                    />
                </div>
                <div className="auth-form-group">
                    <label htmlFor="passwordInput" className="auth-label">Password</label>
                    <input 
                        type="password" 
                        className="auth-form-control" 
                        id="passwordInput" 
                        name="password"
                        value={user.password}
                        onChange={handleChange}
                    />
                </div>
                <button type="submit" className="auth-submit-button">Register</button>
            </form>
        </div>
    );
}

export default Login;
