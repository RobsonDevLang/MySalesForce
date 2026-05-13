import { useState } from "react";
import "./CategoriasComponent.css";

function CategoriasComponent() {
  const categorias = [
    "Ofertas",
    "Feminino",
    "Masculino",
    "Inverno",
    "Verão",
    "Infantil",
    "Acessórios",
  ];

  const [ativa, setAtiva] = useState("Ofertas");

  return (
    <>
      <nav className="categorias-container">
        <ul className="categorias-list">
          {categorias.map((categoria) => {
            return (
              <li
                key={categoria}
                className={`categoria-item ${ativa === categoria ? "active" : ""}`}
                onClick={() => setAtiva(categoria)}
              >
                {categoria}
              </li>
            );
          })}
        </ul>
      </nav>
    </>
  );
}
export default CategoriasComponent;
