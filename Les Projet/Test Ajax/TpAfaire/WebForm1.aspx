<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TpAfaire.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table class="auto-style1">
            <tr>
                <td class="auto-style2">CIN</td>
                <td>
                    <input  id="CIN"  type="text"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Nom</td>
                <td>
                    <input  id="NOM"  type="text"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">PRENOM</td>
                <td>
                    <input  id="PRENOM"  type="text"/>
                </td>
            </tr>
        </table>
        </div>
         <input id="btnajoute" onclick="Ajouter();" type="button" value="Ajouter" />
         <input id="btnafficher" onclick="Afficher();" type="button" value="Afficher" />
         <input id="btnRechercher" onclick="Rechercher();"type="button" value="Rechercher "/>
        <input id="btnModifier" onclick="Modifier();" type="button" value="Modifier" />
        <input id="btnSupprimer" onclick="Supprimer();" type="button" value="Supprimer " />
        </br>
       
        <div id="show"></div>
    </form>
      <script type="text/javascript">
        function Ajouter()
        {


            var CIN = document.getElementById("CIN").value;
            var NOM = document.getElementById("NOM").value;
            var PRENOM = document.getElementById("PRENOM").value;
            if (CIN != "" && NOM != "" && PRENOM != "")
            {
                
                var xhr = new XMLHttpRequest();
                xhr.open("GET", "Ajout.aspx?CIN=" + CIN + "&NOM=" + NOM + "&PRENOM=" + PRENOM + "&op=insert", false);
                xhr.send(null);
                document.getElementById("CIN").value = "";
                document.getElementById("NOM").value = "";
                document.getElementById("PRENOM").value = "";
                alert("Enregistrer avec succès");
            } else { alert("veuiller Remplir toute les zones ") }
        }
        function Afficher() {
            var xhr = new XMLHttpRequest();
            xhr.open("GET", "Ajout.aspx?op=afficher", false);
            xhr.send(null);
            document.getElementById("show").innerHTML = xhr.response;

        }
        function Supprimer() {
            if (CIN == "" && NOM == "" && PRENOM == "")
            {
                alert("veuiller Remplir toute les zones ");
                return;
            }
            var cin = document.getElementById('CIN').value;

            var xmlhttp = new XMLHttpRequest();
            xmlhttp.open("GET", "Ajout.aspx?CIN=" + cin + "&op=supprimer", false);
            xmlhttp.send(null);
            Afficher();

            //document.getElementById("Div1").innerHTML = xmlhttp.responseText;
        }
        function Rechercher() {
            var cin = document.getElementById('CIN').value;

            var xmlhttp = new XMLHttpRequest();
            xmlhttp.open("GET", "Ajout.aspx?CIN=" + cin + "&op=rechercher", false);
            xmlhttp.send(null);

            document.getElementById("Div1").innerHTML = xmlhttp.responseText;
        }
        function Modifier() {
            var cin = document.getElementById('CIN ').value;
            var nom = document.getElementById('NOM').value;
            var prenom = document.getElementById('PRENOM').value;

            var xmlhttp = new XMLHttpRequest();
            xhr.open("GET", "Ajout.aspx?CIN=" + CIN + "&NOM=" + NOM + "&PRENOM=" + PRENOM + "&op=modifier", false);
            xmlhttp.send(null);

            Afficher();

            document.getElementById('CIN').value = "";
            document.getElementById('NOM').value = "";
            document.getElementById('PRENOM').value = "";

            alert("Modification avec succés");
        }



    </script>
</body>
</html>