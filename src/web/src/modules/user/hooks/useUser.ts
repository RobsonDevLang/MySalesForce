import { useState } from "react";
import { postUser } from "../services/user.service";

export function useUser() {
  const [form, setForm] = useState({
    name: "",
    surname: "",
    email: "",
    phone: "",
    password_hash: "",
  });

  function handleChange(event: React.ChangeEvent<HTMLInputElement>) {
    setForm((prev) => ({
      ...prev,
      [event.target.name]: event.target.value,
    }));
  }

  async function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();

    console.log("HANDLE SUBMIT CHAMADO");

    try {
      const response = await postUser(form);

      console.log("Usuário criado:", response);
    } catch (error) {
      console.error("Erro ao criar usuário:", error);
    }
  }

  return {
    form,
    handleChange,
    handleSubmit,
  };
}
