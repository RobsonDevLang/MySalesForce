import InputComponent from "../../../shared/components/InputComponent/InputComponent";
import logo from "@/assets/logo.png";
import { Link } from "react-router-dom";
import "./HeaderComponent.css";
import ButtonComponent from "../../../shared/components/ButtonComponent/ButtonComponent";
import { useLocation } from "react-router-dom";

function HeaderComponent() {
  const location = useLocation();
  location.pathname;
  return (
    <>
      <header className="custom-header">
        <div className="header-logo">
          <Link to="/">
            <img src={logo} alt="Logo MySalesForce" className="logo-style" />
          </Link>
        </div>

        <InputComponent placeholder="Pesquisar: Ex.: Roupa..." />

        <nav className="menu">
          <Link to="/about" className="menu-item">
            Sobre
          </Link>
          <Link to="/login" className="menu-item btn-ghost">
            Login
          </Link>
          <ButtonComponent
            label="Cadastrar-se"
            to="/register"
          ></ButtonComponent>
        </nav>
      </header>
    </>
  );
}

export default HeaderComponent;
