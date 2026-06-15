import "./InputComponent.css";

type InputComponentProps = React.InputHTMLAttributes<HTMLInputElement>;
export default function InputComponent(props: InputComponentProps) {
  return <input className="custom-input" autoComplete="off" {...props} />;
}
