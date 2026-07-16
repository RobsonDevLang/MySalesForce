import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

import { createUser, loginUser } from "../services/user.service";
import {
  validateLoginForm,
  validateRegisterForm,
} from "../validators/register.validator";
import type { LoginForm, RegisterForm } from "../types/user.types";

export function useUser() {
  const navigate = useNavigate();

  const [form, setForm] = useState<RegisterForm>({
    name: "",
    surname: "",
    email: "",
    phone: "",
    password_hash: "",
    confirm_password: "",
  });

  const [loginForm, setLoginForm] = useState<LoginForm>({
    email: "",
    password_hash: "",
  });

  const [message, setMessage] = useState("");
  const [severity, setSeverity] = useState<
    "success" | "info" | "warning" | "error"
  >("info");

  const [showAlert, setShowAlert] = useState(false);
  const [showPassword, setShowPassword] = useState(false);
  const [acceptedTerms, setAcceptedTerms] = useState(false);

  function showMessage(
    severity: "success" | "info" | "warning" | "error",
    message: string,
  ) {
    setSeverity(severity);
    setMessage(message);
    setShowAlert(true);
  }

  function handleChange(event: React.ChangeEvent<HTMLInputElement>) {
    setForm((prev) => ({
      ...prev,
      [event.target.name]: event.target.value,
    }));
  }

  function handleChangeLogin(event: React.ChangeEvent<HTMLInputElement>) {
    setLoginForm((prev) => ({
      ...prev,
      [event.target.name]: event.target.value,
    }));
  }

  async function handleSubmitLogin(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();

    const validation = validateLoginForm(loginForm);

    if (!validation.success) {
      showMessage(validation.severity, validation.message);
      return;
    }

    try {
      await loginUser(loginForm);

      showMessage("success", "Usuário logado com sucesso.");

      setTimeout(() => {
        navigate("/login");
      }, 1000);
    } catch (error) {
      if (axios.isAxiosError(error)) {
        switch (error.response?.status) {
          case 400:
            showMessage("warning", "Dados inválidos.");
            break;

          case 500:
            showMessage("error", "Erro interno do servidor.");
            break;

          case 401:
            showMessage("error", "E-mail ou senha inválidos.");
            break;

          default:
            showMessage("error", "Erro inesperado.");
            break;
        }
      } else {
        showMessage("error", `Erro inesperado: ${String(error)}`);
      }
    }
  }

  async function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();

    const validation = validateRegisterForm(form);

    if (!validation.success) {
      showMessage(validation.severity, validation.message);
      return;
    }

    try {
      await createUser(form);

      showMessage("success", "Usuário criado com sucesso.");

      setTimeout(() => {
        navigate("/login");
      }, 1000);
    } catch (error) {
      if (axios.isAxiosError(error)) {
        switch (error.response?.status) {
          case 400:
            showMessage("warning", "Dados inválidos.");
            break;

          case 409:
            showMessage("error", "Usuário já existe.");
            break;

          case 500:
            showMessage("error", "Erro interno do servidor.");
            break;

          default:
            showMessage("error", "Erro ao criar usuário.");
            break;
        }
      } else {
        showMessage("error", `Erro inesperado: ${String(error)}`);
      }
    }
  }

  return {
    form,
    loginForm,
    setForm,
    setLoginForm,
    handleChange,
    handleChangeLogin,
    handleSubmit,
    handleSubmitLogin,
    message,
    severity,
    showAlert,
    showPassword,
    setShowPassword,
    acceptedTerms,
    setAcceptedTerms,
  };
}
