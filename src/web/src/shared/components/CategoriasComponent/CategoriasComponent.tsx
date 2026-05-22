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
        <div className="catetegory-center">
          <ul className="categorias-list">
            {categorias.map((cat) => (
              <li
                key={cat}
                className={`categoria-item ${ativa === cat ? "active" : ""}`}
                onClick={() => setAtiva(cat)}
              >
                {cat}
              </li>
            ))}
          </ul>
        </div>
      </nav>
    </>
  );
}
export default CategoriasComponent;
