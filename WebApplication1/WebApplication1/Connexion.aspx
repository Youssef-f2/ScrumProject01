<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Connexion.aspx.cs" Inherits="WebApplication1.Connexion1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
         .switch {
  position: relative;
  display: inline-block;
  width: 54px;
  height: 24px;
}

.switch input { 
  opacity: 0;
  width: 0;
  height: 0;
}
input:checked + .slider {
  background-color: #2196F3;
}

input:focus + .slider {
  box-shadow: 0 0 1px #2196F3;
}

input:checked + .slider:before {
  -webkit-transform: translateX(26px);
  -ms-transform: translateX(26px);
  transform: translateX(26px);
}
        .loader {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            TEXT-ALIGN: center;
            z-index: 9999;
            background-color: rgba(0,0,0,0.8);
        }
        .loader .lds{
            position: relative;
            top: 45%;
        }
        .lds-ripple {
  display: inline-block;
  position: relative;
  width: 100px;
  height: 100px;
}
.lds-ripple div {
  position: absolute;
  border: 4px solid #fff;
  opacity: 1;
  border-radius: 50%;
  animation: lds-ripple 1s cubic-bezier(0, 0.2, 0.8, 1) infinite;
}
.lds-ripple div:nth-child(2) {
  animation-delay: -0.5s;
}
@keyframes lds-ripple {
  0% {
    top: 28px;
    left: 28px;
    width: 0;
    height: 0;
    opacity: 1;
  }
  100% {
    top: -1px;
    left: -1px;
    width: 58px;
    height: 58px;
    opacity: 0;
  }
}

    </style>
     <link rel="stylesheet" href="css/style.css" />
      <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="main">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="update_login">
            <ContentTemplate>
                 <section class="sign-in">
            <div class="container">
                <div class="signin-content">
                    <div class="signin-image">
                        <figure><img src="images/signin-image.jpg" alt="sing up image"></figure>
                        <a href="Inscription.aspx" class="signup-image-link">S'inscrire</a>
                    </div>
      
                    <div class="signin-form">
                        <h2 class="form-title">Se Connecter</h2>
                        <div class="register-form" id="login-form">
                            <div class="form-group">
                                <label for="your_name"><i class="fa fa-user-circle"></i></label>
                                <asp:textBox runat="server"  required type="text" name="your_name" id="your_name" placeholder="Your Name"></asp:textBox>
                            </div>
                            <div class="form-group">
                                <label for="your_pass"><i class="fa fa-address-card"></i></label>
                                <asp:textBox runat="server" required type="password" name="your_pass" id="your_pass" placeholder="Password"></asp:textBox>
                            </div>
                           <div class="form-group">                                
                                <asp:CheckBox runat="server" id="accept_arg" Text="Se Souvenir de moi"/> 
                            </div>
 
                            
                            <div class="form-group form-button">
                                <asp:button runat="server" type="submit" Id="Btn_Cnx" OnClick="btn_SeConnecter_Click" class="form-submit" Text="Log in"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
                
                                 
            </ContentTemplate>
        </asp:UpdatePanel>
         <!-- Sing in  Form -->
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
              <div class="loader">
                        <div class="lds">
                            <div class="lds-ripple"><div></div><div></div></div>
                        </div>
                        
                    </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </div>
    </form>
</body>
</html>
