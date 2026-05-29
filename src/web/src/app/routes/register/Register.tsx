import "./Register.css";
import HeaderComponent from "@/app/layouts/HeaderComponent/HeaderComponent";
import RegisterFormComponent from "@/modules/user/components/RegisterFormComponent/RegisterFormComponent";

function Register() {
  return (
    <>
      <div className="register-page">
        <HeaderComponent />
        <RegisterFormComponent />
      </div>
    </>
  );
}

export default Register;
