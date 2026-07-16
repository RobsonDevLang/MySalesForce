import "./App.css";
import HeaderComponent from "./app/layouts/HeaderComponent/HeaderComponent";
import CarrosselComponent from "./modules/product/components/CarouselComponent/CarouselComponent";
import CategoriasComponent from "./shared/components/CategoryComponent/CategoryComponent";
import CardComponent from "./modules/product/components/CardComponent/CardComponent";
import { useCategories } from "./modules/product/hooks/useCategories";

function App() {
  const { categorias, categoriaAtiva, setCategoriaAtiva } = useCategories();

  return (
    <>
      <HeaderComponent />
      <CategoriasComponent
        categorias={categorias}
        categoriaAtiva={categoriaAtiva || { id: 0, name: "Nenhuma categoria" }}
        onCategoriaChange={setCategoriaAtiva}
      />
      <CarrosselComponent />
      <CardComponent
        categoriaAtiva={categoriaAtiva?.name || "Nenhuma categoria"}
        categoriaId={categoriaAtiva?.id || 0}
      />
    </>
  );
}

export default App;
