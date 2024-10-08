import { UserRegisterDTO } from "../models/account/UserRegisterDTO";
import { apiClient } from "../apiClient";
import { UserLoginDTO } from "../models/account/UserLoginDTO";

export async function registerUser(user: UserRegisterDTO) {
    const response = await apiClient.post('api/Account/register', user)

    return response
}

export async function loginUser(user: UserLoginDTO) {
    const response = await apiClient.post('/login?useCookies=true', user)
    return response
}