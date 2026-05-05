import "./InputComponent.css";

export default function InputComponent(props: any) {
  const { placeholder } = props;
  return <input className="custom-input" placeholder={placeholder}></input>;
}
