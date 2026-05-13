import { BrowserRouter as Router, Link } from "react-router-dom";
import "./ButtonComponent.css";

export default function ButtonComponent({ label, to, onClick }: any) {
  if (to) {
    return (
      <>
        <Link to={to} className="custom-button">
          {label}
        </Link>
      </>
    );
  }
  return <button className="custom-button">{label}</button>;
}
