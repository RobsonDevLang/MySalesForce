import { useState, type SetStateAction } from "react";
import HeaderComponent from "@/app/layouts/HeaderComponent/HeaderComponent";
import LoginFormComponent from "@/modules/user/components/LoginFormComponent/LoginFormComponent";

function Login() {
  const [selectedOption, setSelectedOption] = useState("option1");

  return (
    <>
      <div className="register-page">
        <HeaderComponent />
        <LoginFormComponent />
      </div>
    </>
  );
}

export default Login;
