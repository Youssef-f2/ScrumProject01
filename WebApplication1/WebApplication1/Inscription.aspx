<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="WebApplication1.Connexion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="css/style.css" />
      <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="main">

        <!-- Sign up form -->
        <section class="signup">
            <div class="container">
                <div class="signup-content">
                    <div class="signup-form">
                        <h2 class="form-title">Inscription</h2>
                        <form class="register-form" id="register-form">
                            <div class="form-group">
                                <label for="name"><i class="fa fa-user-circle"></i></label>
                                <asp:textBox runat="server" type="text" required name="name" id="name" placeholder="Your Name"></asp:textBox>
                            </div>
                            <div class="form-group">
                                <label for="email"><i class="fa fa-envelope"></i></label>
                                <asp:textBox runat="server" required type="email" name="email" id="email" placeholder="Your Email"></asp:textBox>
                            </div>
                            <div class="form-group">
                                <label for="pass"><i class="fa fa-address-card"></i></label>
                                <asp:textBox runat="server" required type="password" name="pass" id="pass" placeholder="Password"></asp:textBox>
                            </div>
                            <div class="form-group">
                                <label for="re-pass"><i class="fa fa-address-card"></i></label>
                                <asp:textBox runat="server" required type="password" name="re_pass" Id="re_pass" placeholder="Repeat your password"></asp:textBox>
                            </div>
                            
                            <div class="form-group form-button">
                                <asp:button runat="server" Id="btn_signup" OnClick="btn_signup_Click" class="form-submit" Text="Register"/>
                            </div>
                        </form>
                    </div>
                    <div class="signup-image">
                        <figure><img src="images/signup-image.jpg" alt="sing up image"></figure>
                        <a href="Connexion.aspx" class="signup-image-link">Se Connecter</a>
                    </div>
                </div>
            </div>
        </section>

        </div>
    </div>
    </form>
</body>
</html>
