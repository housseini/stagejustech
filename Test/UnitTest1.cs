using System;
using System.Net.Http;

using justch;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using FluentAssertions;
using Xunit;
using Org.BouncyCastle.Crypto.Tls;
using System.Collections.Generic;
using justch.Models.ENTITIES;
using System.Text.Json;
using System.Linq;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Ocsp;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using justch.Models.BLL;
using System.Reflection.Metadata;
using justch.Models.DAL;
using System.Xml.Linq;

namespace Test
{
    public class UnitTest1
    {
        private TestServer _server;
        public HttpClient Client { get; private set; }
        public UnitTest1()
        {
            SetUpClient();
        }

        public async void SetUpClient()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();


        }
      //  [Fact]
      //  public async void Test1()

      //  {

      //      using (var client = Client)
      //      {
      //          var logon = new Login
      //          {
      //              Passeword = "1234",
      //              Type = "Admis",
      //              Utilisateur = "bako"

      //          };


      //          //string json = JsonConvert.SerializeObject(logon);

      //          //StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

      //          //var reponse = await client.GetAsync("/Authentification/Login?Utilisateur=" + logon.Utilisateur + "&Passeword=" + logon.Passeword);


      //          //var content = await reponse.Content.ReadAsStringAsync();

      //          //content.Should().NotBeEmpty();

      //          //var baseAddress = new Uri("http://localhost:5000/");
      //          //var cookieContainer = new CookieContainer();
      //          //cookieContainer.Add(baseAddress, new Cookie("access_token", content));


      //          //reponse = await client.GetAsync("/Patient/Index");
      //          //content = await reponse.Content.ReadAsStringAsync();
      //          ////var response = JsonSerializer.Deserialize<IEnumerable<Patient>>(content);

      //          //content.Should().NotBeEmpty();
      //          //    .And.BeOfType<List<Patient>>();


      //          //var A = response ?? null;

      //          //var filtered = t.Where(x => x % 2 == 0).ToList();
      //          //var recherche = t.Where(x => x > 5);
      //      }



      //  }

      //  [Fact]
      //  public  void testeBLL_RenseignementClinique(){
      //    var    reponse =  BLL_RenseignementClinique.GETBYIDMEDICALE(1);
      //       Assert.NotNull(reponse);
      //}
        [Fact]
public void Bachkup()
{
         var reponse=  DAL_Database_Registre.Add("tesUNITAIRE ", "effetutr le teste unitaire : " , "Xunit ");
            Assert.Equal(" Database_Registre ENREGISTRE", reponse.message);
        } 
    }
}
