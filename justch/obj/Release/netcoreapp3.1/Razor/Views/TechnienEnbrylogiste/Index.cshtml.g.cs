#pragma checksum "E:\projet\projet\stage\code\justch\justch\Views\TechnienEnbrylogiste\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09bef09c559c2dcc748df6baf9bc45bd6f450377"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TechnienEnbrylogiste_Index), @"mvc.1.0.view", @"/Views/TechnienEnbrylogiste/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\projet\projet\stage\code\justch\justch\Views\_ViewImports.cshtml"
using justch;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\projet\projet\stage\code\justch\justch\Views\_ViewImports.cshtml"
using justch.Models.ENTITIES;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\projet\projet\stage\code\justch\justch\Views\_ViewImports.cshtml"
using justch.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\projet\projet\stage\code\justch\justch\Views\_ViewImports.cshtml"
using Core.Flash;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09bef09c559c2dcc748df6baf9bc45bd6f450377", @"/Views/TechnienEnbrylogiste/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa9bc2625cd12a3f4353ae6e86d829650faf496e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_TechnienEnbrylogiste_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/delete1.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("46"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/mesJS/techiciens.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""content"">
    <div class=""row"">
        <div class=""col-sm-4 col-3"">
            <h4 class=""page-title"">les Techniciens</h4>
        </div>
        <div class=""col-sm-8 col-9 text-right m-b-20"">
            <a href=""#addmodal"" onclick=""addmodalshow()"" class=""btn btn btn-primary btn-rounded float-right""><i class=""fa fa-plus""></i> Ajouter technicien</a>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""table-responsive"">
                <table id=""tableenbrologiste"" class=""table table-border table-striped custom-table datatable mb-0"">
                    <thead>
                        <tr>
                            <th>Nom </th>
                            <th>Prenom</th>
                           
                          
                            
                            <th class=""text-right"">Action</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 31 "E:\projet\projet\stage\code\justch\justch\Views\TechnienEnbrylogiste\Index.cshtml"
                         if(ViewBag.Techniciens!=null)
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "E:\projet\projet\stage\code\justch\justch\Views\TechnienEnbrylogiste\Index.cshtml"
                         foreach (var item in  ViewBag.Techniciens)
                        {
                            
                      

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>  ");
#nullable restore
#line 37 "E:\projet\projet\stage\code\justch\justch\Views\TechnienEnbrylogiste\Index.cshtml"
                             Write(item.FirsName);

#line default
#line hidden
#nullable disable
            WriteLiteral("     </td>\r\n                            <td>  ");
#nullable restore
#line 38 "E:\projet\projet\stage\code\justch\justch\Views\TechnienEnbrylogiste\Index.cshtml"
                             Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </td>\r\n                           <td class=\"text-right\">\r\n                            <a href=\"#editemodal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1592, "\"", 1618, 3);
            WriteAttributeValue("", 1602, "edited(", 1602, 7, true);
#nullable restore
#line 40 "E:\projet\projet\stage\code\justch\justch\Views\TechnienEnbrylogiste\Index.cshtml"
WriteAttributeValue("", 1609, item.Id, 1609, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1617, ")", 1617, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn btn-secondary btn-rounded \"><i class=\"fa fa-pencil\"> </i> \r\n                               edit  </a>\r\n                                                   \r\n                          <a href=\"#supprimermodal\"");
            BeginWriteAttribute("onclick", "  onclick=\"", 1842, "\"", 1880, 3);
            WriteAttributeValue("", 1853, "addtolocalsession(", 1853, 18, true);
#nullable restore
#line 43 "E:\projet\projet\stage\code\justch\justch\Views\TechnienEnbrylogiste\Index.cshtml"
WriteAttributeValue("", 1871, item.Id, 1871, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1879, ")", 1879, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn btn-danger btn-rounded \"><i class=\"fa fa-trash\"> </i> \r\n                           delete  </a>\r\n                         </td>\r\n                        </tr>\r\n");
#nullable restore
#line 47 "E:\projet\projet\stage\code\justch\justch\Views\TechnienEnbrylogiste\Index.cshtml"
                          }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                     
                       
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>





<div id=""supprimermodal"" class=""modal fade delete-modal"" role=""dialog"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "09bef09c559c2dcc748df6baf9bc45bd6f4503779757", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
               <p> la suppresion de ce Techinicien impliquerai la suppression des toute les table dont il appartient ?</p>
                <div class=""m-t-20"">
                    <a href=""#"" class=""btn btn-white"" data-dismiss=""modal"" onclick=""fermer()""   style=""width: 25%;"">Fermer</a>
                    <button type=""submit"" class=""btn btn-danger"" style=""width: 25%;"" onclick=""confirmationdelete()"">Supprimer</button>
                </div>
            </div>
        </div>
    </div>
</div>




<div id=""addmodal"" class=""modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""modal-dialog  modal-xl  "">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <div class=""modal-header p-1 mb-2 bg-primary text-white"">
                    <h3>   ajouter technicien </h3>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
            ");
            WriteLiteral(@"        </button>

                </div>
                <div class=""modal-body"">

                    <div class=""form-row"">




                        <div class=""form-group col-md-6"">
                            <label for=""inputPassword4"" class=""float-left"">  FirstName <span>*</span></label>

                            <input type=""text"" class=""form-control"" id=""FirstName"" placeholder=""FirstName"">
                            <label class=""text-danger"" id=""dee"">
                                saisir le Nom

                            </label>
                        </div>


                        <div class=""form-group col-md-6"">
                            <label for=""inputAddress2"" class=""float-left"">LastName </label>

                            <input type=""text"" class=""form-control"" id=""LastName"" placeholder=""LastName"">
                            <label class=""text-danger"" id=""dre"">
                                saisir le Nom

                            </label>");
            WriteLiteral(@"
                        </div>

                    </div>
                </div>
                <div class=""mx-auto"" style=""width: 200px;"">
                    <button type=""button"" class=""btn btn-primary"" onclick=""addTECHNICIEN()""><i class=""fa fa-plus m-r-5""> Ajouter </i> </button>
                </div>
            </div>
        </div>
    </div>
</div>
<div id=""editmodal"" class=""modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""modal-dialog  modal-xl  "">
        <div class=""modal-content"">
            <div id=""modal-container"" class=""modal-body text-center"">
               

             
               
            </div>
             <div class=""mx-auto"" style=""width: 200px;"">
                    <button type=""button"" class=""btn btn-primary"" onclick=""modifierTECHNICIEN()""><i class=""fa fa-pencil m-r-5""> modifier </i> </button>
                </div>
        </div>
    </div>
</div>



");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09bef09c559c2dcc748df6baf9bc45bd6f45037714314", async() => {
                    WriteLiteral("\r\n\r\n\r\n");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 147 "E:\projet\projet\stage\code\justch\justch\Views\TechnienEnbrylogiste\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n\r\n\r\n    ");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
