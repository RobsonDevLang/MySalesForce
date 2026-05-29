import "./App.css";
import HeaderComponent from "./app/layouts/HeaderComponent/HeaderComponent";
import CarrosselComponent from "./modules/product/components/CarouselComponent/CarouselComponent";
import CategoriasComponent from "./shared/components/CategoryComponent/CategoryComponent";
import CardComponent from "./modules/product/components/CardComponent/CardComponent";

function App() {
  return (
    <>
      <HeaderComponent />
      <CategoriasComponent />
      <CarrosselComponent />
      <CardComponent />
    </>
  );
}

export default App;
