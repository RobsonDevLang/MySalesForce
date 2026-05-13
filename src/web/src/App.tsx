import { useState, type SetStateAction } from "react";
import "./App.css";
// import ButtonComponent from "./components/ButtonComponent/ButtonComponent";
// import SelectComponent from "./components/SelectComponent/SelectComponent";
// import TableComponent from "./components/TableComponent/TableComponent";
import HeaderComponent from "./components/HeaderComponent/HeaderComponent";
import CarrosselComponent from "./components/CarrosselComponent/CarrosselComponent";

function App() {
  const [selectedOption, setSelectedOption] = useState("option1");

  return (
    <>
      <HeaderComponent />
      <CarrosselComponent />
      {/* 
      <h3 className="custom-h3">Primeiros components em React</h3>
      <ButtonComponent label="Clique aqui"></ButtonComponent> <br />
      <SelectComponent
        label=""
        value={selectedOption}
        options={[
          { value: "option1", label: "Opção 1" },
          { value: "option2", label: "Opção 2" },
          { value: "option3", label: "Opção 3" },
        ]}
        onChange={(value: SetStateAction<string>) => setSelectedOption(value)}
      />
      <TableComponent
        headers={["Nome", "Email", "Telefone"]}
        data={[
          ["John Doe", "john@example.com", "(123) 456-7890"],
          ["Jane Smith", "jane@example.com", "(098) 765-4321"],
        ]}
      />
       */}
    </>
  );
}

export default App;
