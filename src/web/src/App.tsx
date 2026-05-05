import { useState, type SetStateAction } from "react";
import "./App.css";
import ButtonComponent from "./components/ButtonComponent/ButtonComponent";
import InputComponent from "./components/InputComponent/InputComponent";
import SelectComponent from "./components/SelectComponent/SelectComponent";
import logo from "./assets/logo.png";
import TableComponent from "./components/TableComponent/TableComponent";

function App() {
  const [selectedOption, setSelectedOption] = useState("option1");

  return (
    <>
      <div>
        <img src={logo} alt="Logo MySalesForce" className="logo-style" />
      </div>
      <hr />
      <h3 className="custom-h3">Primeiros components em React</h3>
      <ButtonComponent label="Clique aqui"></ButtonComponent> <br />
      <InputComponent placeholder="Pesquisar: Ex.: Roupa..."></InputComponent>
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
    </>
  );
}

export default App;
