import InputComponent from "../InputComponent/InputComponent";
import logo from "../../assets/logo.png";
import { BrowserRouter as Router, Link } from "react-router-dom";
import "./HeaderComponent.css";
import CategoriasComponent from "../CategoriasComponent/CategoriasComponent";
import ButtonComponent from "../ButtonComponent/ButtonComponent";

function HeaderComponent() {
  return (
    <>
      <header className="custom-header">
        <div className="header-logo">
          <img src={logo} alt="Logo MySalesForce" className="logo-style" />
        </div>

        <InputComponent placeholder="Pesquisar: Ex.: Roupa..." wdt={240} />

        <nav className="menu">
          <Link to="/sobre" className="menu-item">
            Sobre
          </Link>
          <Link to="/login" className="menu-item btn-ghost">
            Login
          </Link>
          <ButtonComponent
            label="Cadastrar-se"
            to="/cadastrar"
          ></ButtonComponent>
        </nav>
      </header>
      <CategoriasComponent />
    </>
  );
}

export default HeaderComponent;
