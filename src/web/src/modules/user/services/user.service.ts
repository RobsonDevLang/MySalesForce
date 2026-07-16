import axios from "axios";
import type { User, LoginForm } from "../types/user.types";
const VITE_API_URL_USER = import.meta.env.VITE_API_URL_USER;

export async function getUser(): Promise<User[]> {
  const response = await axios.get<User[]>(VITE_API_URL_USER + "/user");

  return response.data;
}

export async function createUser(user: User): Promise<User> {
  const response = await axios.post<User>(`${VITE_API_URL_USER}/user`, user);

  return response.data;
}

export async function loginUser(user: LoginForm): Promise<User> {
  const response = await axios.post<User>(
    `${VITE_API_URL_USER}/user/login`,
    user,
  );

  return response.data;
}
