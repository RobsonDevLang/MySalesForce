import HeaderComponent from "@/app/layouts/HeaderComponent/HeaderComponent";
import LoginFormComponent from "@/modules/user/components/LoginFormComponent/LoginFormComponent";

function Login() {
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
