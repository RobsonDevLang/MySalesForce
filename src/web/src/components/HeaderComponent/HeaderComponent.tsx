import InputComponent from "../InputComponent/InputComponent";
import logo from "../../assets/logo.png";
import { BrowserRouter as Router, Link } from "react-router-dom";
import "./HeaderComponent.css";
import CategoriasComponent from "../CategoriasComponent/CategoriasComponent";
import ButtonComponent from "../ButtonComponent/ButtonComponent";

function HeaderComponent() {
  const listaPesquisa = [
    { label: "The Shawshank Redemption", year: 1994 },
    { label: "The Godfather", year: 1972 },
    { label: "The Godfather: Part II", year: 1974 },
    { label: "The Dark Knight", year: 2008 },
    { label: "12 Angry Men", year: 1957 },
  ];
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
