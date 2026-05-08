import InputComponent from "../InputComponent/InputComponent";
import logo from "../../assets/logo.png";
import { BrowserRouter as Router, Link } from "react-router-dom";
import "./HeaderComponent.css";
import CategoriasComponent from "../CategoriasComponent/CategoriasComponent";

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
        <nav className="menu">
          <a href="#" className="menu-item">
            Login
          </a>
          <a href="#" className="menu-item">
            Cadastrar-se
          </a>
          <li className="menu-item">
            <Link to="/sobre">Sobre</Link>
          </li>
          <InputComponent
            placeholder="Pesquisar: Ex.: Roupa..."
            wdt={300}
          ></InputComponent>
        </nav>
        <img src={logo} alt="Logo MySalesForce" className="logo-style" />
      </header>
    </>
  );
}

export default HeaderComponent;
