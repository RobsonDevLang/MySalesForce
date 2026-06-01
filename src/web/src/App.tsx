import "./App.css";
import HeaderComponent from "./app/layouts/HeaderComponent/HeaderComponent";
import CarrosselComponent from "./modules/product/components/CarouselComponent/CarouselComponent";
import CategoriasComponent from "./shared/components/CategoryComponent/CategoryComponent";
import CardComponent from "./modules/product/components/CardComponent/CardComponent";
import { useState } from "react";

function App() {
  const [categoriaAtiva, setCategoriaAtiva] = useState("Todos");
  
  return (
    <>
      <HeaderComponent />
      <CategoriasComponent
        categoriaAtiva={categoriaAtiva}
        onCategoriaChange={setCategoriaAtiva}
      />
      <CarrosselComponent/>
      <CardComponent categoriaAtiva={categoriaAtiva} />
    </>
  );
}

export default App;
