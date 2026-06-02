import "./CategoryComponent.css";

interface CategoriasProps {
  categoriaAtiva: string;
  onCategoriaChange: (cat: string) => void;
}

function CategoryComponent({ categoriaAtiva, onCategoriaChange }: CategoriasProps) {
  const categorias = [
    "Todos",
    "Feminino",
    "Masculino",
    "Inverno",
    "Verão",
    "Infantil",
    "Acessórios",
  ];

  return (
    <>
       <nav className="categorias-container">
      <div className="catetegory-center">
        <ul className="categorias-list">
          {categorias.map((cat) => (
            <li
              key={cat}
              className={`categoria-item ${categoriaAtiva === cat ? "active" : ""}`}
              onClick={() => onCategoriaChange(cat)}
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
