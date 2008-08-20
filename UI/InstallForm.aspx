<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstallForm.aspx.cs" Inherits="UI.InstallForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="LogonPanel" runat="server" Height="122px" Width="381px">
            <table style="width: 357px; height: 101px">
                <tr>
                    <td style="width: 59px">
                    </td>
                    <td style="width: 126px">
                        <asp:Label ID="lblMsg" runat="server" Text="初始化前请您登录系统" Width="170px"></asp:Label></td>
                    <td style="width: 82px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 59px; height: 22px">
                        <asp:Label ID="Label2" runat="server" Text="用户名：" Width="71px"></asp:Label></td>
                    <td style="width: 126px; height: 22px">
                        <asp:TextBox ID="txtUsrName" runat="server" Width="164px"></asp:TextBox></td>
                    <td style="width: 82px; height: 22px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 59px; height: 20px">
                        <asp:Label ID="Label3" runat="server" Text="密　码：" Width="70px"></asp:Label></td>
                    <td style="width: 126px; height: 20px">
                        <asp:TextBox ID="txtPassWd" runat="server" Width="163px" TextMode="Password"></asp:TextBox></td>
                    <td style="width: 82px; height: 20px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 59px">
                    </td>
                    <td style="width: 126px">
                        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="登录" /></td>
                    <td style="width: 82px">
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Label ID="lblErrorMsg" runat="server" Width="381px"></asp:Label><br />
        <asp:Panel ID="mainPanel" runat="server" Height="444px" Width="385px">
            <table style="height: 343px">
                <tr>
                    <td style="width: 165px">
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="Label1" runat="server" Text="数据库配置"></asp:Label></td>
                    <td style="width: 101px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 165px">
                        <asp:Label ID="Label4" runat="server" Text="服务器名称："></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtServer" runat="server"></asp:TextBox></td>
                    <td style="width: 101px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 165px">
                        <asp:Label ID="Label5" runat="server" Text="用户ID："></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox></td>
                    <td style="width: 101px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 165px">
                        <asp:Label ID="Label6" runat="server" Text="密码："></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
                    <td style="width: 101px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 165px">
                        <asp:Label ID="Label7" runat="server" Text="数据库名称："></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtInitialCatalog" runat="server"></asp:TextBox></td>
                    <td style="width: 101px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 165px">
                        <asp:Label ID="Label8" runat="server" Text="文件存储路径："></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtPath" runat="server"></asp:TextBox></td>
                    <td style="width: 101px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 165px">
                        <asp:Label ID="Label9" runat="server" Text="组织(根目录)名称：" Width="139px"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtOrgName" runat="server"></asp:TextBox></td>
                    <td style="width: 101px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 165px">
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="Label10" runat="server" Text="管理员设置"></asp:Label></td>
                    <td style="width: 101px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 165px">
                        <asp:Label ID="Label11" runat="server" Text="用户账号："></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtMember" runat="server"></asp:TextBox></td>
                    <td style="width: 101px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 165px">
                        <asp:Label ID="Label12" runat="server" Text="密码："></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtMemberPwd" runat="server" TextMode="Password" Width="149px"></asp:TextBox></td>
                    <td style="width: 101px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 165px">
                        <asp:Label ID="Label13" runat="server" Text="确认密码："></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtSurePwd" runat="server" TextMode="Password" Width="148px"></asp:TextBox></td>
                    <td style="width: 101px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 165px">
                        <asp:Label ID="Label14" runat="server" Text="真实姓名："></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtMemberName" runat="server"></asp:TextBox></td>
                    <td style="width: 101px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 165px">
                        <asp:Label ID="Label15" runat="server" Text="E_mail："></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                    <td style="width: 101px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 165px">
                    </td>
                    <td style="width: 100px">
                        <asp:Button ID="btnCreate" runat="server" Text="创建" Width="66px" OnClick="btnCreate_Click" />
                    </td>
                    <td style="width: 101px">
                        <asp:Button ID="btnInitial" runat="server" Text="初始化" Width="65px" OnClick="btnInitial_Click" /></td>
                </tr>
            </table>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
