import "./ButtonComponent.css";

export default function ButtonComponent(props: any) {
  const { label } = props;
  return <button className="custom-button">{label}</button>;
}
