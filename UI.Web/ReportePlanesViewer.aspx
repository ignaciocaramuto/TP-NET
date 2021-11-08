<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportePlanesViewer.aspx.cs" Inherits="UI.Web.ReportePlanesViewer" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    
    
    <CR:CrystalReportViewer ID="crvPlanes" runat="server" AutoDataBind="true" />
    
    
    
</asp:Content>
