import "./InputComponent.css";

export default function InputComponent(props: any) {
  const { placeholder, wdt } = props;
  wdt ? wdt : 200;
  return (
    <>
      <input
        className="custom-input"
        placeholder={placeholder}
        style={{ width: wdt }}
      ></input>
    </>
  );
}
