<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="World.aspx.cs" Inherits="_1._3.World.World" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>World</title>
    <style type="text/css">
        .error-message {
            display: block;
            color: #ff0000;
        }
    </style>
</head>
<body>
    <form id="World" runat="server">
        <asp:Label ID="LiteralErrorMessages" runat="server" CssClass="error-message" EnableViewState="false"></asp:Label>

        <h1>Continents</h1>

        <asp:EntityDataSource ID="EntityDataSourceContinents" runat="server"
            ConnectionString="name=WorldEntities"
            DefaultContainerName="WorldEntities"
            EntitySetName="Continents" />

        <asp:ListBox ID="ListBoxContinents" runat="server" Rows="6" Width="150"
            DataSourceID="EntityDataSourceContinents"
            DataTextField="ContinentName" DataValueField="ContinentId"
            AutoPostBack="True" OnSelectedIndexChanged="ListBoxContinents_SelectedIndexChanged" /><br />

        <asp:Button ID="ButtonInsertContinent" Text="Insert continent" runat="server"
            OnClick="ButtonInsertContinent_Click" />
        <asp:Button ID="ButtonEditContinent" Text="Edit continent" runat="server"
            OnClick="ButtonEditContinent_Click" Visible="false" />
        <asp:Button ID="ButtonDeleteContinent" Text="Delete continent" runat="server"
            OnClick="ButtonDeleteContinent_Click" Visible="false" />

        <asp:Panel ID="PanelInsertContinent" runat="server" Visible="false">
            Continent name:
            <asp:TextBox runat="server" ID="TextBoxContinentName" />
            <asp:Button Text="Save" ID="ButtonEditExistingContinent" runat="server" OnClick="ButtonEditExistingContinent_Click" Visible="false" />
            <asp:Button Text="Save" ID="ButtonSaveContinent" runat="server" OnClick="ButtonSaveContinent_Click" Visible="false" />
        </asp:Panel>

        <h2>Countries</h2>
        <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server"
            ConnectionString="name=WorldEntities"
            DefaultContainerName="WorldEntities"
            EntitySetName="Countries"
            Where="it.ContinentId=@ContinentId"
            EnableInsert="true" EnableUpdate="true" EnableDelete="true"
            EnableFlattening="false">
            <WhereParameters>
                <asp:ControlParameter Name="ContinentId" Type="Int32"
                    ControlID="ListBoxContinents" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:GridView ID="GridViewCountries" runat="server" ItemType="_1._3.World.Country"
            DataSourceID="EntityDataSourceCountries"
            AutoGenerateColumns="False" DataKeyNames="CountryId"
            AllowPaging="True" AllowSorting="True" OnSelectedIndexChanged="GridViewCountries_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" HeaderText="Select" />
                <asp:BoundField DataField="CountryName" HeaderText="Country" SortExpression="CountryName" />
                <asp:BoundField DataField="SurfaceArea" HeaderText="Surface" SortExpression="SurfaceArea" />
                <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                <asp:BoundField DataField="Latitude" HeaderText="Latitude" SortExpression="Latitude" />
                <asp:BoundField DataField="Longitude" HeaderText="Longitude" SortExpression="Longitude" />
                <asp:ImageField DataImageUrlField="CountryId" DataImageUrlFormatString="~/ImageHttpHandler.ashx?id={0}" HeaderText="Flag" ReadOnly="true">
                    <ControlStyle Height="50px" Width="100px" />
                </asp:ImageField>
                <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonDeleteCountry" runat="server"
                            CommandName="DeleteCountry" CommandArgument="<%# Item.CountryId %>" Text="Delete"
                            OnCommand="LinkButtonDeleteCountry_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Button ID="ButtonInsertCountry" Text="Insert country" runat="server"
            OnClick="ButtonInsertCountry_Click" Visible="false" />

        <asp:Panel ID="PanelInsertCountry" runat="server" Visible="false" EnableViewState="false">
            Country name:
            <asp:TextBox runat="server" ID="TextBoxCountryName" />
            <br />
            Surface area:
            <asp:TextBox runat="server" ID="TextBoxSurfaceArea" />
            <br />
            Population:
            <asp:TextBox runat="server" ID="TextBoxPopulation" />
            <br />
            Language:
            <asp:TextBox runat="server" ID="TextBoxLanguage" />
            <br />
            Latitude:
            <asp:TextBox runat="server" ID="TextBoxLatitude" />
            <br />
            Longitude:
            <asp:TextBox runat="server" ID="TextBoxLongitude" />
            <br />
            Flag:
            <asp:FileUpload ID="FileUploadFlagImage" runat="server" />

            <asp:Button Text="Save" ID="ButtonSaveCountry" runat="server" OnClick="ButtonSaveCountry_Click" />
        </asp:Panel>

        <h3>Cities</h3>
        <asp:EntityDataSource ID="EntityDataSourceCities" runat="server"
            ConnectionString="name=WorldEntities"
            DefaultContainerName="WorldEntities"
            EntitySetName="Cities"
            Where="it.CountryId=@CountryId" EnableFlattening="false"
            EnableInsert="true" EnableUpdate="true" EnableDelete="true">
            <WhereParameters>
                <asp:ControlParameter Name="CountryId" Type="String"
                    ControlID="GridViewCountries" />
            </WhereParameters>
            <InsertParameters>
                <asp:ControlParameter Name="CountryId" ControlID="GridViewCountries" Type="String" />
            </InsertParameters>
        </asp:EntityDataSource>

        <asp:ListView ID="ListViewCities" runat="server"
            DataSourceID="EntityDataSourceCities"
            ItemType="_1._3.World.City"
            DataKeyNames="CityID"
            InsertItemPosition="None"
            OnItemInserted="ListViewCities_ItemInserted" Visible="false">

            <LayoutTemplate>
                <span runat="server" id="itemPlaceholder" />
                <div class="pagerLine">
                    <asp:Button ID="ButtonInsertCity" Text="Insert city" runat="server"
                        OnClick="ButtonInsertCity_Click" />

                    <asp:DataPager ID="DataPagerCities" runat="server" PageSize="2">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false"
                                ShowPreviousPageButton="true" ShowLastPageButton="false" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowNextPageButton="true"
                                ShowPreviousPageButton="false" ShowLastPageButton="true" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </LayoutTemplate>

            <EmptyDataTemplate>
                <asp:Button ID="ButtonInsertCity" Text="Insert city" runat="server"
                    OnClick="ButtonInsertCity_Click" />
                <div>No data was returned.</div>
            </EmptyDataTemplate>

            <ItemTemplate>
                <div class="item">
                    City name: <%#: Item.CityName %>
                    <br />
                    Population: <%#: Item.CityPopulation %>
                    <br />
                    Latitude: <%#: Item.Latitude %>
                    <br />
                    Longitude: <%#: Item.Longitude %>
                    <br />

                    <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" />
                </div>
            </ItemTemplate>

            <EditItemTemplate>
                City name:<asp:TextBox ID="TextBoxCityName" runat="server" Text='<%#: BindItem.CityName %>' /><br />
                Population:<asp:TextBox ID="TextBoxPopulation" runat="server" Text='<%# BindItem.CityPopulation %>' /><br />
                Latitude:<asp:TextBox ID="TextBoxLatitude" runat="server" Text='<%# BindItem.Latitude %>' /><br />
                Longitude:<asp:TextBox ID="TextBoxContactTitle" runat="server" Text='<%# BindItem.Longitude %>' /><br />

                <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>

            <InsertItemTemplate>
                <asp:Panel ID="PanelInsertCity" runat="server" EnableViewState="false">
                    <asp:HiddenField ID="HiddenFieldCountryId" runat="server" Value="<%#: BindItem.CountryId %>" />
                    City name:<asp:TextBox ID="TextBoxCityName" runat="server" Text='<%#: BindItem.CityName %>' /><br />
                    Population:<asp:TextBox ID="TextBoxPopulation" runat="server" Text='<%# BindItem.CityPopulation %>' /><br />
                    Latitude:<asp:TextBox ID="TextBoxLatitude" runat="server" Text='<%# BindItem.Latitude %>' />
                    <br />
                    Longitude:<asp:TextBox ID="TextBoxContactTitle" runat="server" Text='<%# BindItem.Longitude %>' /><br />

                    <asp:Button ID="ButtonInsert" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Clear" />
                </asp:Panel>
            </InsertItemTemplate>
        </asp:ListView>

    </form>
</body>
</html>
