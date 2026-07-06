import { useState } from "react";
import { postUser } from "../services/user.service";
import axios from "axios";

export function useUser() {
  const [form, setForm] = useState({
    name: "",
    surname: "",
    email: "",
    phone: "",
    password_hash: "",
  });

  const [message, setMessage] = useState("");
  const [severity, setSeverity] = useState<
    "success" | "info" | "warning" | "error"
  >("info");
  const [showAlert, setShowAlert] = useState(false);

  function handleChange(event: React.ChangeEvent<HTMLInputElement>) {
    setForm((prev) => ({
      ...prev,
      [event.target.name]: event.target.value,
    }));
  }

  async function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();

    try {
      const response = await postUser(form);

      setSeverity("success");
      setMessage("Usuário criado com sucesso.");
      setShowAlert(true);
    } catch (error) {
      if (axios.isAxiosError(error)) {
        if (error.response?.status === 400) {
          setSeverity("warning");
          setMessage("Dados inválidos.");
        }

        if (error.response?.status === 409) {
          setSeverity("error");
          setMessage("Usuário já existe.");
        }

        if (error.response?.status === 500) {
          setSeverity("error");
          setMessage("Erro interno do servidor.");
        }

        setShowAlert(true);
      } else {
        setSeverity("error");
        setMessage(`Erro inesperado: ${String(error)}`);
        setShowAlert(true);
      }
    }
  }

  return {
    form,
    handleChange,
    handleSubmit,
    message,
    severity,
    showAlert,
  };
}
