import InputComponent from "@/shared/components/InputComponent/InputComponent";
import "./RegisterFormComponent.css";
import PersonIcon from "@mui/icons-material/Person";
import EmailIcon from "@mui/icons-material/Email";
import LocalPhoneIcon from "@mui/icons-material/LocalPhone";
import LockIcon from "@mui/icons-material/Lock";
import VisibilityIcon from "@mui/icons-material/Visibility";
import VisibilityOffIcon from "@mui/icons-material/VisibilityOff";
import GoogleIcon from "@mui/icons-material/Google";
import FacebookIcon from "@mui/icons-material/Facebook";
import { useUser } from "../../hooks/useUser";
import Alert from "@mui/material/Alert";

export default function RegisterFormComponent() {
  const {
    form,
    handleChange,
    handleSubmit,
    message,
    severity,
    showAlert,
    showPassword,
    setShowPassword,
    acceptedTerms,
    setAcceptedTerms,
  } = useUser();

  return (
    <>
      <div className="register-container">
        <div className="register-card">
          <h1 className="logo">MySalesForce</h1>

          <h2>Crie sua conta</h2>

          <p className="subtitle">Preencha os dados abaixo para começar.</p>

          <form onSubmit={handleSubmit}>
            <div className="row">
              <div className="input-group">
                <div className="input-wrapper">
                  <PersonIcon className="input-icon" />
                  <InputComponent
                    type="text"
                    name="name"
                    placeholder="Nome"
                    value={form.name}
                    onChange={handleChange}
                  />
                </div>
              </div>

              <div className="input-group">
                <div className="input-wrapper">
                  <PersonIcon className="input-icon" />
                  <InputComponent
                    type="text"
                    name="surname"
                    placeholder="Sobrenome"
                    value={form.surname}
                    onChange={handleChange}
                  />
                </div>
              </div>
            </div>

            <div className="input-group">
              <div className="input-wrapper">
                <EmailIcon className="input-icon" />
                <InputComponent
                  type="email"
                  name="email"
                  placeholder="E-mail"
                  value={form.email}
                  onChange={handleChange}
                />
              </div>
            </div>

            <div className="input-group">
              <div className="input-wrapper">
                <LocalPhoneIcon className="input-icon" />
                <InputComponent
                  type="text"
                  name="phone"
                  placeholder="Telefone"
                  value={form.phone}
                  onChange={handleChange}
                />
              </div>
            </div>

            <div className="input-group">
              <div className="input-wrapper">
                <LockIcon className="input-icon" />
                <InputComponent
                  type={showPassword ? "text" : "password"}
                  name="password_hash"
                  placeholder="Senha"
                  value={form.password_hash}
                  onChange={handleChange}
                />
                {showPassword ? (
                  <VisibilityOffIcon
                    className="visibility-icon"
                    onClick={() => setShowPassword(false)}
                  />
                ) : (
                  <VisibilityIcon
                    className="visibility-icon"
                    onClick={() => setShowPassword(true)}
                  />
                )}
              </div>
            </div>

            <div className="input-group">
              <div className="input-wrapper">
                <LockIcon className="input-icon" />
                <InputComponent
                  type={showPassword ? "text" : "password"}
                  name="confirm_password"
                  placeholder="Confirmar senha"
                  value={form.confirm_password}
                  onChange={handleChange}
                />
                {showPassword ? (
                  <VisibilityOffIcon
                    className="visibility-icon"
                    onClick={() => setShowPassword(false)}
                  />
                ) : (
                  <VisibilityIcon
                    className="visibility-icon"
                    onClick={() => setShowPassword(true)}
                  />
                )}
              </div>
            </div>

            <label className="terms">
              <InputComponent
                type="checkbox"
                name="acceptedTerms"
                checked={acceptedTerms}
                onChange={(e) => setAcceptedTerms(e.target.checked)}
              />
              <span>
                Eu concordo com os
                <a href="#"> Termos de Uso </a>e
                <a href="#"> Política de Privacidade</a>
              </span>
            </label>

            <button
              type="submit"
              className="btn-register"
              disabled={!acceptedTerms}
            >
              Criar conta
            </button>
          </form>
          {showAlert && <Alert severity={severity}>{message}</Alert>}

          <div className="divider">
            <span>ou cadastre-se com</span>
          </div>

          <div className="social-buttons">
            <button type="button">
              <GoogleIcon className="google-icon" />
            </button>

            <button type="button">
              <FacebookIcon className="facebook-icon" />
            </button>
          </div>

          <p className="login-link">
            Já tem uma conta?
            <a href="#"> Faça login</a>
          </p>
        </div>
      </div>
    </>
  );
}
