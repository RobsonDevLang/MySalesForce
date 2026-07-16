import type { RegisterForm } from "../types/user.types";
import type { LoginForm } from "../types/user.types";

type ValidationResult =
  | {
      success: true;
    }
  | {
      success: false;
      severity: "success" | "info" | "warning" | "error";
      message: string;
    };

export function validateRegisterForm(form: RegisterForm): ValidationResult {
  if (
    !form.name ||
    !form.surname ||
    !form.email ||
    !form.phone ||
    !form.password_hash ||
    !form.confirm_password
  ) {
    return {
      success: false,
      severity: "warning",
      message: "Todos os campos são obrigatórios.",
    };
  }

  if (!/^\S+@\S+\.\S+$/.test(form.email)) {
    return {
      success: false,
      severity: "warning",
      message: "Email inválido.",
    };
  }

  if (!/^\d{10,11}$/.test(form.phone)) {
    return {
      success: false,
      severity: "warning",
      message:
        "Telefone inválido. Deve conter apenas números e ter 10 ou 11 dígitos.",
    };
  }

  if (form.password_hash.length < 6) {
    return {
      success: false,
      severity: "warning",
      message: "A senha deve ter pelo menos 6 caracteres.",
    };
  }

  if (form.password_hash !== form.confirm_password) {
    return {
      success: false,
      severity: "warning",
      message: "As senhas não coincidem.",
    };
  }

  return {
    success: true,
  };
}

export function validateLoginForm(loginForm: LoginForm): ValidationResult {
  console.log("Validating login form:", loginForm);
  if (!loginForm.email || !loginForm.password_hash) {
    return {
      success: false,
      severity: "warning",
      message: "Todos os campos são obrigatórios.",
    };
  }

  if (!/^\S+@\S+\.\S+$/.test(loginForm.email)) {
    return {
      success: false,
      severity: "warning",
      message: "Email inválido.",
    };
  }

  if (loginForm.password_hash.length < 6) {
    return {
      success: false,
      severity: "warning",
      message: "A senha deve ter pelo menos 6 caracteres.",
    };
  }
  return {
    success: true,
  };
}
