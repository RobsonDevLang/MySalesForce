import Select from "react-select";
import "./SelectComponent.css";

export default function SelectComponent(props: any) {
  const { options, value, onChange } = props;

  return (
    <Select
      className="custom-select"
      value={options.find((option: any) => option.value === value)}
      onChange={(selectedOption) => onChange(selectedOption?.value)}
      options={options}
      placeholder="Selecione uma opção"
      styles={{
        container: (base) => ({
          ...base,
          width: 200,
          boxSizing: "border-box",
        }),
      }}
    />
  );
}
