<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEntry.aspx.cs" Inherits="CakeTest.UserEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.11.1/jquery.validate.js" type="text/javascript"></script>
    <script type="text/javascript">


        function handleSubmit() {
            jquerySubmit();
        }

        function jquerySubmit() {
            $(document).ready(function () {
           
                $("#form1").submit(function () {
                    $.post("UserEntry.aspx", $("#form1").serialize(), function (data) {
                        if (data.indexOf("html") > 0) {
                            location.href = "UserEntryResponse.aspx";
                        }
                        else {
                            result = eval(data);
                            errorHtml = "</br>";
                            for (var i = 0, len = result.length; i < len; ++i) {
                                errorHtml = errorHtml + result[i] + "</br>";
                            }
                            $("#errors").html(errorHtml);
                        }
                    });

                    return false;
                });
            });
        }
    </script>
</head>
<body id="body">
    <form id="form1" runat="server" onsubmit="handleSubmit();">
        
    <div>
        
        First name: </br>
        <input id="First Name" type="text" name="FirstName" required/>
        </br>
        Last name: </br>
        <input id="Last Name" type="text" name="LastName" required/>
        </br>
        Sex: </br>
        <select id="Sex" name="Sex">
            <option>Male</option>
            <option>Female</option>
        </select></br>
        Phone: </br>
        <input id="Phone" type="text" name="Phone" required/>
        </br>
        Street Address: </br>
        <input id="Street Address" type="text" name="Street Address" required/>
        </br>
        City: </br>
        <input id="City" type="text" name="City" required/>
        </br>
        State: </br>
        <input id="State" type="text" name="State" required/>
        </br>
        Zip code: </br>
        <input id="Zip" type="text" name="Zip" required digits/>
        </br>
        <input id="Submit1" type="submit" value="Submit" onclick="handleSubmit();" />
    </div>
    </form>

    <div id="errors">

    </div>
</body>
</html>
