import InputComponent from "../InputComponent/InputComponent";
import logo from "../../assets/logo.png";
import { BrowserRouter as Router, Link } from "react-router-dom";

function HeaderComponent() {
  return (
    <>
      <header className="custom-header">
        <nav className="menu">
          <li className="menu-item">
            <Link to="/sobre">Sobre</Link>
          </li>
          <a href="#" className="menu-item">
            Login
          </a>
          <a href="#" className="menu-item">
            Cadastrar-se
          </a>
          <InputComponent placeholder="Pesquisar: Ex.: Roupa..."></InputComponent>
        </nav>
        <img src={logo} alt="Logo MySalesForce" className="logo-style" />
      </header>
    </>
  );
}

export default HeaderComponent;
