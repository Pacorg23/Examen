<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <asp:TextBox ID="horaCarga" runat="server"></asp:TextBox>
        <asp:Table ID="tblClientes" runat="server" >
       </asp:Table>
    </main>

<script type="text/javascript">
    function actualizarFooter(celdaSexo, nombreUsuario) {
        document.getElementById('MainContent_footerCell1').innerText = "Registro modificado";

        document.getElementById('MainContent_footerCell2').innerText = nombreUsuario + "(" + celdaSexo.value[0] + ")";
        var footer = document.getElementById('MainContent_footerRow');

        if (celdaSexo.value[0] == 'F') {
            footer.style.backgroundColor = "pink";

        }
        else {
            footer.style.backgroundColor = "blue";

        }
        var tblClientesSexos = document.getElementsByTagName('select');
        var total = tblClientesSexos.length;
        var masculinos = 0;
        var femeninos = 0;
        console.log(tblClientesSexos[0].value);
        for (var i = 0; i < total; i++) {
            if (tblClientesSexos[i].value == "Masculino") {
                masculinos++;
            }
            else {
                femeninos++;
            } 
        }
        var pMasculinos = ((masculinos / total) * 100);

        var pfemeninos = ((femeninos / total) * 100);

        document.getElementById('MainContent_footerCell3').innerText = "Masculino: " + pMasculinos + "%, Femenino: " + pfemeninos + "%";
    }

</script>
</asp:Content>
