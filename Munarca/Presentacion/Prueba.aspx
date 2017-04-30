<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="Presentacion.Prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .starRating {
            width: 70px;
            height: 70px;
            cursor: pointer;
            background-repeat: no-repeat;
            display: block;
        }

        .FilledStars {
            background-image: url("../img/star_rojo.png");
        }

        .WatingStars {
            background-image: url("../img/star_amarrillo.png");
        }

        .EmptyStars {
            background-image: url("../img/star_Plateado.png");
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <ajaxToolkit:Rating ID="Rating1" runat="server" StarCssClass="starRating" WaitingStarCssClass="WatingStars" EmptyStarCssClass="EmptyStars" FilledStarCssClass="FilledStars"></ajaxToolkit:Rating>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>
</body>
</html>
