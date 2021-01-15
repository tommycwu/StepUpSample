using RestSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StepUpSample
{
    public partial class Authorzied : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var domain = @"https://ciam.oktapreview.com";
                var client_id = "0oa9rk756IOpj8vri1d6";
                var client_secret = "-6tGgfOxaNclgwhkxVC7KopnnLhOB2e2FT30eH_q";
                var redirectUrl = @"https://localhost:44363/authorize/callback.aspx";
                var redirect_uri = System.Net.WebUtility.UrlEncode(redirectUrl);
                var grant_type = "authorization_code";
                var basicAuth = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(client_id)) + " " + System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(client_secret));
                var code = Request.QueryString["code"]; ;

                var addParam = $"client_secret={client_secret}&client_id={client_id}&grant_type={grant_type}&redirect_uri={redirect_uri}&code={code}";
                var tokenUri = $"{domain}/oauth2/v1/token";
                var client = new RestClient(tokenUri);
                var request = new RestRequest(Method.POST);
                request.AddHeader("accept", "application/json");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("application/x-www-form-urlencoded", addParam, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                _ = response.Content;
                if (response.Content.Contains("access_token"))
                {
                    var jObject = Newtonsoft.Json.Linq.JObject.Parse(response.Content);
                    var a = jObject.GetValue("access_token").ToString();


                    var retToken = a;
                    var ahandler = new JwtSecurityTokenHandler();
                    var ajsonToken = ahandler.ReadToken(retToken);
                    var atokenS = ahandler.ReadToken(retToken) as JwtSecurityToken;

                    GridViewAccess.DataSource = atokenS.Claims.Select(x => new { Name = x.Type, Value = x.Value });
                    GridViewAccess.DataBind();
                }
            }
            catch
            { 
            
            }

        }

        protected void GridViewAccess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GridViewAccess.Rows)
            {
                row.Cells[1].Attributes.Add("id", $"claim-{row.Cells[0].Text}");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}