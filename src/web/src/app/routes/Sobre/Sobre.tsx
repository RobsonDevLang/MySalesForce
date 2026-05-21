import { useState, type SetStateAction } from "react";
import ButtonComponent from "../../../../src/shared/components/ButtonComponent/ButtonComponent";
import SelectComponent from "../../../../src/shared/components/SelectComponent/SelectComponent";
import TableComponent from "../../../../src/shared/components/TableComponent/TableComponent";

function Sobre() {
  const [selectedOption, setSelectedOption] = useState("option1");

  return (
    <>
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
        headers={["Name", "Email", "Telefone"]}
        data={[
          ["John Doe", "john@example.com", "(123) 456-7890"],
          ["Jane Smith", "jane@example.com", "(098) 765-4321"],
        ]}
      />
    </>
  );
}

export default Sobre;
