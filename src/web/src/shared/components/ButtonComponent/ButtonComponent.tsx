import { Link } from "react-router-dom";
import "./ButtonComponent.css";

interface ButtonComponentProps {
  label?: string;
  to?: string;
  onClick?: () => void;
  children?: React.ReactNode;
  className?: string;
}
export default function ButtonComponent({
  label,
  to,
  onClick,
  children,
  className,
}: ButtonComponentProps) {
  const content = children || label;

  if (to) {
    return (
      <>
        <Link to={to} className={`custom-button ${className}`}>
          {label}
        </Link>
      </>
    );
  }
  return (
    <button className={`custom-button ${className}`} onClick={onClick}>
      {content}
    </button>
  );
}
