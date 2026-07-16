import "./CategoryComponent.css";

export interface Categoria {
  id: number;
  name: string;
}

interface CategoriasProps {
  categorias: Categoria[];
  categoriaAtiva: Categoria;
  onCategoriaChange: (categoria: Categoria) => void;
}

function CategoryComponent({
  categorias,
  categoriaAtiva,
  onCategoriaChange,
}: CategoriasProps) {
  return (
    <>
      <nav className="categorias-container">
        <div className="catetegory-center">
          <ul className="categorias-list">
            {categorias.map((cat) => (
              <li
                key={cat.id}
                className={`categoria-item ${
                  categoriaAtiva.id === cat.id ? "active" : ""
                }`}
                onClick={() => onCategoriaChange(cat)}
              >
                {cat.name}
              </li>
            ))}
          </ul>
        </div>
      </nav>
    </>
  );
}
export default CategoryComponent;
