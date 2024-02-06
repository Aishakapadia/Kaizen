<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/App_Master.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="UFS_Application.Forms.ChangePassword"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="smMain" runat="server" EnablePageMethods="true" />
    <script>
        function validatePasswordMatch() {
            var password = document.getElementById("password");
            var confirmPassword = document.getElementById("confirmPassword");

            if (password.value !== confirmPassword.value) {
                document.getElementById('confirmPassword').setCustomValidity("Passwords don't match");
                document.getElementById('confirmPassword').reportValidity();
                document.getElementById('submitButton').disabled = true;
                return false;
            } else {
                document.getElementById('confirmPassword').setCustomValidity('');
                document.getElementById('confirmPassword').reportValidity();
                document.getElementById('submitButton').disabled = false;
                return true;
            }
        }
        
        

        //function validateSignupForm() {
        //    var form = document.getElementById('signupForm');

        //    for (var i = 0; i < form.elements.length; i++) {
        //        if (form.elements[i].value === '' && form.elements[i].hasAttribute('required')) {
        //            console.log('There are some required fields!');
        //            return false;
        //        }
        //    }

        //    if (!validatePassword()) {
        //        return false;
        //    }

        //    onSignup();
        //}

        //document.addEventListener("DOMContentLoaded", function onSignup() {
        //    var xhttp = new XMLHttpRequest();
        //    xhttp.onreadystatechange = function () {

        //        disableSubmitButton();

        //        if (
        //            //this.readyState == 4
        //            //&&
        //            this.status == 200) {
        //            enableSubmitButton();
        //        }
        //        else {
        //            console.log('AJAX call failed!');
        //            setTimeout(function () {
        //                enableSubmitButton();
        //            }, 1000);
        //        }

        //    };

        //    xhttp.open("GET", "ajax_info.txt", true);
        //    xhttp.send();
        //});
    </script>
    <style>
        .head {
            background-color: #31708f;
            color: white;
        }

        .content {
            background-color: #31708f;
            font-family: "Times New Roman", Times, serif;
            color: black;
        }

        .mainDiv {
            display: flex;
            min-height: 100%;
            align-items: center;
            justify-content: center;
            background-color: #f9f9f9;
            font-family: 'Open Sans', sans-serif;
        }

        .cardStyle {
            width: 500px;
            border-color: white;
            background: #fff;
            padding: 36px 0;
            border-radius: 4px;
            margin: 30px 0;
            box-shadow: 0px 0 2px 0 rgba(0,0,0,0.25);
        }

        #signupLogo {
            max-height: 100px;
            margin: auto;
            display: flex;
            flex-direction: column;
        }

        .formTitle {
            font-weight: 600;
            margin-top: 20px;
            color: #2F2D3B;
            text-align: center;
        }

        .inputLabel {
            font-size: 12px;
            color: #555;
            margin-bottom: 6px;
            margin-top: 24px;
        }

        .inputDiv {
            width: 70%;
            display: flex;
            flex-direction: column;
            margin: auto;
        }

        input {
            height: 40px;
            font-size: 16px;
            border-radius: 4px;
            border: none;
            border: solid 1px #ccc;
            padding: 0 11px;
        }

            input:disabled {
                cursor: not-allowed;
                border: solid 1px #eee;
            }

        .buttonWrapper {
            margin-top: 40px;
        }

        .submitButton {
            width: 70%;
            height: 40px;
            margin: auto;
            display: block;
            color: #fff;
            background-color: #065492;
            border-color: #065492;
            text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.12);
            box-shadow: 0 2px 0 rgba(0, 0, 0, 0.035);
            border-radius: 4px;
            font-size: 14px;
            cursor: pointer;
        }

            .submitButton:disabled,
            button[disabled] {
                border: 1px solid #cccccc;
                background-color: #cccccc;
                color: #666666;
            }

        #loader {
            position: absolute;
            z-index: 1;
            margin: -2px 0 0 10px;
            border: 4px solid #f3f3f3;
            border-radius: 50%;
            border-top: 4px solid #666666;
            width: 14px;
            height: 14px;
            -webkit-animation: spin 2s linear infinite;
            animation: spin 2s linear infinite;
        }

        @keyframes spin {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }
    </style>

    <div class="mainDiv">
        <div class="cardStyle">
            <form action="" method="post" name="signupForm" id="signupForm">

                <h2 class="formTitle">Change Password
                </h2>

                <div class="inputDiv">
                    <label class="inputLabel" for="password">New Password</label>
                    <input type="password" id="password" name="password" required onchange="validatePasswordMatch()">
                </div>

                <div class="inputDiv">
                    <label class="inputLabel" for="confirmPassword">Confirm Password</label>
                    <input type="password" id="confirmPassword" name="confirmPassword" required onkeyup="validatePasswordMatch()">
                </div>

                <div class="buttonWrapper">
                    <button type="submit" id="submitButton" onclick="ChangeUserPassword()" runat="server" class="submitButton pure-button pure-button-primary">
                        <span>Continue</span>
                        <%--<span id="loader"></span>--%>
                    </button>
                </div>

            </form>
        </div>
    </div>

    <%-- <div class="container">
        <div class="row">
            <hr />
        </div>

        <div class="row">
            <div class="col-12">
                 <asp:Label ID="lblUsername" runat="server" CssClass="mainHeading" Text="Enter User Name: "></asp:Label>   &nbsp; &nbsp; &nbsp; 
                 <asp:TextBox ID="txtUsername" CssClass="input" runat="server" placeholder="User Name"></asp:TextBox>
                <div class="row">
                    <hr />
                </div>
                <asp:Label ID="lblPassword" runat="server" CssClass="mainHeading" Text="Enter New Password: "></asp:Label>
                <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="input" runat="server" placeholder="Password"></asp:TextBox>
            </div>
        </div>

    </div>--%>
</asp:Content>


