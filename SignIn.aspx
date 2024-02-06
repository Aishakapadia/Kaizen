<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="UFS_Application.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Framework/JQuery/jquery-ui-1.12.1/jquery-ui.css" rel="stylesheet" />
    <link href="Framework/jquery/jquery-ui-1.12.1/jquery-ui.css" rel="stylesheet" />
    <link href="Framework/bootstrap/bootstrap-4.0.0-alpha.6-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Framework/bootstrap/bootstrap-4.0.0-alpha.6-dist/css/bootstrap.css" rel="stylesheet" />

    <script src="Framework/jquery/jquery-ui-1.12.1/external/jquery/jquery.js"></script>
    <script src="Framework/jquery/jquery-ui-1.12.1/jquery-ui.js"></script>

    <script src="Framework/bootstrap/bootstrap-4.0.0-alpha.6-dist/js/bootstrap.min.js"></script>
    <script src="Framework/SweetAlert/sweetalert.min.js"></script>
    <script src="Framework/UFS.js"></script>
    <style>
        @import url(https://fonts.googleapis.com/css?family=Roboto:300);

        .login-page {
            width: 360px;
            padding: 8% 0 0;
            margin: auto;
        }

        .form {
            position: relative;
            z-index: 1;
            background: #FFFFFF;
            max-width: 360px;
            margin: 0 auto 100px;
            padding: 45px;
            text-align: center;
            box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
        }

        .formAbove {
            position: relative;
            z-index: 1;
            background: #FFFFFF;
            max-width: 360px;
            margin: 0 auto 100px;
            padding: 0px;
            text-align: center;
            box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
        }


        .input {
            font-family: "Roboto", sans-serif;
            outline: 0;
            background: #f2f2f2;
            width: 100%;
            border: 0;
            margin: 0 0 15px;
            padding: 15px;
            box-sizing: border-box;
            font-size: 14px;
        }

        .button {
            font-family: "Roboto", sans-serif;
            text-transform: uppercase;
            outline: 0;
            width: 100%;
            border: 0;
            padding: 15px;
            color: #FFFFFF;
            font-size: 14px;
            -webkit-transition: all 0.3 ease;
            transition: all 0.3 ease;
            cursor: pointer;
            background: #4CAF50;
            background-color: #31a8e2;
        }


        .form button:hover, .form button:active, .form button:focus {
            background: #43A047;
        }

        .form .message {
            margin: 15px 0 0;
            color: #b3b3b3;
            font-size: 12px;
        }

            .form .message a {
                color: #4CAF50;
                text-decoration: none;
            }

        .form .register-form {
            display: none;
        }

        .container {
            position: relative;
            z-index: 1;
            max-width: 300px;
            margin: 0 auto;
        }

            .container:before, .container:after {
                content: "";
                display: block;
                clear: both;
            }

            .container .info {
                margin: 50px auto;
                text-align: center;
            }

                .container .info h1 {
                    margin: 0 0 15px;
                    padding: 0;
                    font-size: 36px;
                    font-weight: 300;
                    color: #1a1a1a;
                }

                .container .info span {
                    color: #4d4d4d;
                    font-size: 12px;
                }

                    .container .info span a {
                        color: #000000;
                        text-decoration: none;
                    }

                    .container .info span .fa {
                        color: #EF3B3A;
                    }

        body {
            background: #97cce6; /* fallback for old browsers */
            /*background: -webkit-linear-gradient(right, #76b852, #8DC26F);
            background: -moz-linear-gradient(right, #76b852, #8DC26F);
            background: -o-linear-gradient(right, #76b852, #8DC26F);
            background: linear-gradient(to left, #76b852, #8DC26F);*/
            font-family: "Roboto", sans-serif;
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
        }
    </style>
    <script>
        $(document).ready(function () {



            $('.message a').click(function () {
                $('.formDiv').animate({ height: "toggle", opacity: "toggle" }, "slow");
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="login-page">
                <div class="formAbove" style="background-color: #31a8e2">
                    <br />
                    <b>
                        <asp:Label ID="lblAppName" runat="server" Text="Kaizen" Font-Size="25px" ForeColor="#ffffff"></asp:Label>
                    </b>
                    <hr />


                    <div class="form">



                        <div id="f2" class="login-form formDiv">

                            <asp:TextBox ID="txtUsername" CssClass="input" runat="server" placeholder="User Name"></asp:TextBox>
                            <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="input" runat="server" placeholder="Password"></asp:TextBox>
                            <asp:Button ID="btnSignIn" CssClass="button" runat="server" Text="Sign In" OnClick="btnSignIn_Click" />
                            <%-- <p class="message">
                            Not registered? <a href="Registration.aspx">Create an account</a>
                            <br />
                            <a href="Forms/Home.aspx">Home</a>
                        </p>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
