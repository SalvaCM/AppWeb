<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Mapas.aspx.vb" Inherits="AppWeb.Mapas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
   
  
     <br />
     <br />
    <style>
    body {

      margin: 0;
      padding: 0;
    }

    #map {
      
      height: 100px;
      position: relative;
      top: 0;
      bottom: 0;
      width: 70%;
    }
    .auto-style3 {
      height: 600px;
    }
    </style>

    <div id='map'></div>
    <script>
        mapboxgl.accessToken = 'pk.eyJ1IjoiZWxvcnJpZXRhYSIsImEiOiJjazN6cjh2YmoweWZ4M3JzODRvOHFkOWV0In0.RBHlmFvs995psAb227nMKA';
        var map = new mapboxgl.Map({
            container: 'map', // Container ID
            style: 'mapbox://styles/mapbox/streets-v11', // Map style to use
            center: [-122.25948, 37.87221], // Starting position [lng, lat]
            zoom: 10, // Starting zoom level
        });
    </script>
   
</asp:Content>
