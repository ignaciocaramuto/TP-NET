<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="LoginStyle.css" rel="stylesheet" type="text/css"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LogIn</title>
</head>
<body>
    
    <div class="wrapper fadeInDown">
        <div id="formContent">
            <div class="fadeIn first">
                <asp:Image ID="icon" runat="server" imageUrl="~/Imagenes/utn_logo.jpg"/>
            </div>
            <form id="form1" runat="server">
                <asp:TextBox ID="txtUsuario" class="fadeIn second" placeholder="Nombre de usuario" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtContraseña" class="fadeIn third" placeholder="Contraseña" runat="server"></asp:TextBox>
                <asp:Label ID="lblError" class="label-error" runat="server" Text="Usuario y/o contraseña incorrecto/s" Visible="false"></asp:Label>
                <asp:Button ID="btnIngresar" class="fadeIn fourth" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
            </form>
        </div>
    </div>
</body>
</html>
