import { useState } from "react";
import "./CategoryComponent.css";

function CategoryComponent() {
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
export default CategoryComponent;
