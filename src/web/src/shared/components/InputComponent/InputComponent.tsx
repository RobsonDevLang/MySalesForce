import "./InputComponent.css";

type InputComponentProps = {
  type?: React.HTMLInputTypeAttribute;
  placeholder?: string;
  value?: string;
  name?: string;
};

export default function InputComponent({
  type = "text",
  placeholder,
  value,
  name,
}: InputComponentProps) {
  return (
    <input
      className="custom-input"
      type={type}
      placeholder={placeholder}
      value={value}
      name={name}
      autoComplete="off"
      readOnly={value !== undefined}
    />
  );
}
