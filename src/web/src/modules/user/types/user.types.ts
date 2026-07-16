export interface User {
  name: string;
  surname: string;
  email: string;
  phone: string;
  password_hash: string;
}

export interface RegisterForm {
  name: string;
  surname: string;
  email: string;
  phone: string;
  password_hash: string;
  confirm_password: string;
}

export interface LoginForm {
  email: string;
  password_hash: string;
}
