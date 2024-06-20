import React, { useState } from 'react';
import { UserRegisterDTO } from '../../models/account/UserRegisterDTO';
import { registerUser } from '../../api/user';
import "./auth.css"
import { useNavigate } from 'react-router-dom';


function Register() {
    const [user, setUser] = useState<UserRegisterDTO>({email: '', password: ''});
    const [confirmationPassword, setConfirmationPassword] = useState("");
    const navigate = useNavigate()

    function handleChange(e: React.ChangeEvent<HTMLInputElement>) {
        if (e.target.name === "confirmPassword") {
            setConfirmationPassword(e.target.value);
        } else {
            setUser((prevUser: UserRegisterDTO) => ({
                ...prevUser,
                [e.target.name]: e.target.value
            }));
        }
    }

    async function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        if (user.password !== confirmationPassword) {
            console.error('Passwords do not match');
            return;
        }
        try {
            const response = await registerUser(user);
            console.log('User registered:', response);
            setUser({email: '', password: ''}); // Reset form
            setConfirmationPassword('');
            navigate('/login');
        } catch (error) {
            console.error('Failed to register user:', error);
        }
    }

    return (
        <div className="auth-container">
            <h1 className="auth-header">Register Account</h1>
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
                <div className="auth-form-group">
                    <label htmlFor="confirmPasswordInput" className="auth-label">Confirm Password</label>
                    <input 
                        type="password" 
                        className="auth-form-control" 
                        id="confirmPasswordInput" 
                        name="confirmPassword"
                        value={confirmationPassword}
                        onChange={handleChange}
                    />
                </div>
                <button type="submit" className="auth-submit-button">Register</button>
            </form>
        </div>
    );
}

export default Register;
