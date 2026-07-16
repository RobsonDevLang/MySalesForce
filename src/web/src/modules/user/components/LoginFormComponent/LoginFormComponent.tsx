import InputComponent from "@/shared/components/InputComponent/InputComponent";
import "./LoginFormComponent.css";
import EmailIcon from "@mui/icons-material/Email";
import LockIcon from "@mui/icons-material/Lock";
import VisibilityIcon from "@mui/icons-material/Visibility";
import VisibilityOffIcon from "@mui/icons-material/VisibilityOff";
import GoogleIcon from "@mui/icons-material/Google";
import FacebookIcon from "@mui/icons-material/Facebook";
import { useUser } from "../../hooks/useUser";
import Alert from "@mui/material/Alert";

export default function LoginFormComponent() {
  const {
    loginForm,
    handleChangeLogin,
    handleSubmitLogin,
    message,
    severity,
    showAlert,
    showPassword,
    setShowPassword,
  } = useUser();

  return (
    <>
      <div className="register-container">
        <div className="register-card">
          <h1 className="logo">MySalesForce</h1>

          <h2>Entrar</h2>

          <p className="subtitle">Preencha os dados abaixo para começar.</p>

          <form onSubmit={handleSubmitLogin}>
            <div className="input-group">
              <div className="input-wrapper">
                <EmailIcon className="input-icon" />
                <InputComponent
                  type="email"
                  name="email"
                  placeholder="E-mail"
                  value={loginForm.email}
                  onChange={handleChangeLogin}
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
                  value={loginForm.password_hash}
                  onChange={handleChangeLogin}
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

            <button type="submit" className="btn-register">
              Entrar
            </button>
          </form>
          {showAlert && <Alert severity={severity}>{message}</Alert>}

          <div className="divider">
            <span>ou entre com</span>
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
            Ainda não tem uma conta?
            <a href="#"> Crie uma conta</a>
          </p>
        </div>
      </div>
    </>
  );
}
