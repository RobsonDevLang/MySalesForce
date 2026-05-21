import "./App.css";
import HeaderComponent from "./shared/components/HeaderComponent/HeaderComponent";
import CarrosselComponent from "./modules/product/components/CarouselComponent/CarouselComponent";
import CategoriasComponent from "./shared/components/CategoriasComponent/CategoriasComponent";
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
