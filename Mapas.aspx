<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Mapas.aspx.vb" Inherits="AppWeb.Mapas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
      <script>  
          var mapcode;
          var diag;
          function initialize() {
              mapcode = new google.maps.Geocoder();
              var lnt = new google.maps.LatLng(43.2814236, -2.9675669);
              var diagChoice = {
                  zoom: 10,
                  center: lnt,
                  diagId: google.maps.MapTypeId.ROADMAP
              }
              diag = new google.maps.Map(document.getElementById('map_populate'), diagChoice);
          }
          function getmap() {
              alert("holi1");
              var completeaddress = document.getElementById('txt_location').value;
              mapcode.geocode({ 'address': completeaddress }, function (results, status) {
                  if (status == google.maps.GeocoderStatus.OK) {
                      diag.setCenter(results[0].geometry.location);
                      var hint = new google.maps.Marker({
                          diag: diag,
                          position: results[0].geometry.location
                      });
                  } else {
                      alert('Location Not Tracked. ' + status);
                  }
              });
              alert("holi2");
          }
          google.maps.event.addDomListener(window, 'load', initialize);
    </script>  

    <div>Hola</div>
     <div>  
            <h1>Enter Your Location Details</h1>  
        </div>  
        <div>  
            <asp:TextBox ID="txt_location" TextMode="MultiLine" Width="400px" Height="70px" runat="server"></asp:TextBox>  
    </div>  
        <div>  
            <input type="button" value="Search" onclick="getmap()">  
        </div>  
    <div id="map_populate" style="width:100%; height:500px; border: 5px solid #5E5454;">  
    </div>  


   <!-- 
    <div class="container">
        <button type="button" data-toggle="modal" data-target="#ModalMap" class="btn btn-default">
        <span class="glyphicon glyphicon-map-marker"></span> <span id="ubicacion">Seleccionar Ubicación:</span>
        </button>
        
        <style>
            .pac-container{
                z-index:99999;
            }
        </style>

       <div class="modal fade" id="ModalMap" tabindex="-1" role="dialog" >
            
            <div class="modal-dialog" role="document">
            <div class="modal-content">
            <div class="modal-body">
            <div class="form-horizontal">
                <div class="form-group">
                <label class="col-sm-2 control-label">Ubicación:</label>
                    <div class="col-sm-9">
                    <input type="text" class="form-control" id="ModalMap-address" />
                    </div>
                    <div class="col-sm-1">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    </div>
                </div>
                    <div id="ModalMapPreview" style="width: 100%; height: 400px;"></div>
                
                        <div class="clearfix">&nbsp;</div>
                            <div class="m-t-small">
                                <label class="p-r-small col-sm-1 control-label">Lat.:</label>
                                <div class="col-sm-3">
                                <input type="text" class="form-control" id="ModalMap-lat" />
                                </div>
                                <label class="p-r-small col-sm-2 control-label">Long.:</label>

                                <div class="col-sm-3">
                                <input type="text" class="form-control" id="ModalMap-lon" />
                                </div>
                                <div class="col-sm-3">
                                <button type="button" class="btn btn-primary btn-block" data-dismiss="modal" >Aceptar</button>
                                </div>

                            </div>
                            <div class="clearfix"></div>
                            <script>
                            $("#ModalMapPreview").locationpicker({
                            radius: 0,
                            location: {
                            latitude: 20.938297181414647,
                            longitude: -89.61501516379462
                            },
                            inputBinding: {
                            latitudeInput: $("#ModalMap-lat"),
                            longitudeInput: $("#ModalMap-lon"),
                            locationNameInput: $("#ModalMap-address")
                            },
                            enableAutocomplete: true,
                            onchanged: function (currentLocation, radius, isMarkerDropped) {
                            $("#ubicacion").html($("#ModalMap-address").val());
                            }
                            });
                            $("#ModalMap").on("shown.bs.modal", function () {
                            $("#ModalMapPreview").locationpicker("autosize");
                            });
                            </script>
                        </div>
                    </div>
                </div>
            </div>
   
        </div>
    
        </div>
      -->
</asp:Content>
