using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StepUpSample
{
    public partial class Tokens : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string itokenStr = string.Empty;
            string atokenStr = string.Empty;

            if (Request.IsAuthenticated)
            {
                var claimsList = HttpContext.Current.GetOwinContext().Authentication.User.Claims.ToList();
                foreach (var claimItem in claimsList)
                {
                    if (claimItem.Type == "id_token")
                    {
                        itokenStr = claimItem.Value;
                    }
                    else if (claimItem.Type == "access_token")
                    {
                        atokenStr = claimItem.Value;
                    }

                    if ((itokenStr.Length > 0) && (atokenStr.Length > 0))
                    {
                        break;
                    }
                }

                var ihandler = new JwtSecurityTokenHandler();
                var ijsonToken = ihandler.ReadToken(itokenStr);
                var itokenS = ihandler.ReadToken(itokenStr) as JwtSecurityToken;
                string userEmail = "";
                string userName = "";
                for (int i = 0; i < itokenS.Claims.ToList().Count; i++)
                {
                    if (itokenS.Claims.ToList()[i].Type == "email")
                    {
                        var userParam = Request.QueryString["email"] + "";
                        if (userParam.Length > 1)
                        {
                            userEmail = userParam;
                        }
                        else
                        {
                            userEmail = itokenS.Claims.ToList()[i].Value;
                        }
                    }
                    else if (itokenS.Claims.ToList()[i].Type == "preferred_username")
                    {
                        userName = itokenS.Claims.ToList()[i].Value;
                    }
                }

                if (userEmail.Length > 1 && userName.Length > 1)
                {
                    if (userEmail == "dummy@email.com")
                    {
                        Response.Redirect("WebForm5.aspx?userName=" + userName);
                    }
                }

                GridViewID.DataSource = itokenS.Claims.Select(x => new { Name = x.Type, Value = x.Value });
                GridViewID.DataBind();

                var ahandler = new JwtSecurityTokenHandler();
                var ajsonToken = ahandler.ReadToken(atokenStr);
                var atokenS = ahandler.ReadToken(atokenStr) as JwtSecurityToken;

                GridViewAccess.DataSource = atokenS.Claims.Select(x => new { Name = x.Type, Value = x.Value });
                GridViewAccess.DataBind();
            }
        }

        protected void GridViewID_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GridViewID.Rows)
            {
                row.Cells[1].Attributes.Add("id", $"claim-{row.Cells[0].Text}");
            }
        }

        protected void GridViewAccess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GridViewAccess.Rows)
            {
                row.Cells[1].Attributes.Add("id", $"claim-{row.Cells[0].Text}");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("https://ciam.oktapreview.com/home/ciam_mfaasaservice_2/0oa9rl65ajmpa2DvB1d6/aln9rm0ijoQFoLJ2U1d6");
            //Response.Redirect("https://ciam.oktapreview.com/oauth2/v1/authorize?client_id=0oa9rk756IOpj8vri1d6&redirect_uri=https%3A%2F%2Flocalhost%3A44363%2Fauthorize%2Fcallback.aspx&response_type=token&response_mode=fragment&state=state&nonce=nonce&scope=openid");
            Response.Redirect("https://ciam.oktapreview.com/oauth2/v1/authorize?client_id=0oa9rk756IOpj8vri1d6&redirect_uri=https%3A%2F%2Flocalhost%3A44363%2Fauthorize%2Fcallback.aspx&response_type=code&response_mode=fragment&state=state&nonce=nonce&scope=openid");
        }
    }
}