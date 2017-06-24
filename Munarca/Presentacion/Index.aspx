<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentacion.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .GMap1{
            background-color:aqua;
            width:100%;
            height:343px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="GMap1">
        <gmaps:GMap runat="server" ID="GMap1" enableServerEvents="true" Width="100%" ></gmaps:GMap>
    </div>
    </form>
</body>
</html>
