<%@ Page Language="VB" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.vb" Inherits="WPSaxerBS._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <div class="container">
      <!-- Example row of columns -->
      <div class="row">
        <div class="col-md-4">

            <asp:Button ID="Button2" runat="server" Text=" &lt; " />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

            <asp:Button ID="Button1" runat="server" Text=" &gt; " />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="b_filter" runat="server" Text="" />


            <dx:BootstrapGridView ID="BootstrapGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Settings ShowFooter="True" ShowHeaderFilterBlankItems="False"/>
                <Columns>
                    <dx:BootstrapGridViewTextColumn FieldName="AUFTR_NR" VisibleIndex="0" Caption="A-Nr.">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="Auftraggeber" VisibleIndex="1">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="Typ" VisibleIndex="3">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="Mo" VisibleIndex="4">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="Di" VisibleIndex="5">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="Mi" VisibleIndex="6">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="Don" VisibleIndex="7" Caption="Do">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="Fr" VisibleIndex="8">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="Sa" VisibleIndex="9">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="So" VisibleIndex="10">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="Text1" VisibleIndex="11" Caption="Arbeitsbeschrieb">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="Text2" VisibleIndex="12" Caption="Infos">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="grMo" VisibleIndex="13" Visible="False">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="grDi" VisibleIndex="14" Visible="False">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="grMi" VisibleIndex="15" Visible="False">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="grDo" VisibleIndex="16" Visible="False">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="grFr" VisibleIndex="17" Visible="False">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="grSa" VisibleIndex="18" Visible="False">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="grSo" VisibleIndex="19" Visible="False">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="KW" VisibleIndex="20" Visible="False">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="Jahr" VisibleIndex="21" Visible="False">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewHyperLinkColumn Caption="Objekt" FieldName="PRJDESCR" VisibleIndex="2">
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="https://www.google.com/maps/place/{0}" Target="_blank">
                        </PropertiesHyperLinkEdit>
                    </dx:BootstrapGridViewHyperLinkColumn>
                </Columns>
            </dx:BootstrapGridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WocheplanSaxerConnectionString %>" SelectCommand="SELECT [AUFTR_NR], [Auftraggeber], [PRJDESCR], [Typ], [Mo], [Di], [Mi], [Don], [Fr], [Sa], [So], [Text1], [Text2], [grMo], [grDi], [grMi], [grDo], [grFr], [grSa], [grSo], [KW], [Jahr] FROM [tblWP] WHERE [AUFTR_NR] <> '' AND [KW] = @KWNR AND [Jahr] = @JAHRNR ORDER BY [Jahr], [KW]">
            <SelectParameters>
            <asp:Parameter Name="KWNR" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="JAHRNR" Type="Int32" DefaultValue="0" />
            </SelectParameters>

            </asp:SqlDataSource>
        </div>
        
      </div>
    
    </div>
</asp:Content>