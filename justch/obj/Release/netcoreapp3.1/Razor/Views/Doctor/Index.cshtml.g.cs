#pragma checksum "D:\projet\stage\code\justch\justch\Views\Doctor\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0412254c43946a6b03a3cd4010ae830ac232729"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctor_Index), @"mvc.1.0.view", @"/Views/Doctor/Index.cshtml")]
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
#line 1 "D:\projet\stage\code\justch\justch\Views\_ViewImports.cshtml"
using justch;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\projet\stage\code\justch\justch\Views\_ViewImports.cshtml"
using justch.Models.ENTITIES;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\projet\stage\code\justch\justch\Views\_ViewImports.cshtml"
using justch.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\projet\stage\code\justch\justch\Views\_ViewImports.cshtml"
using Core.Flash;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0412254c43946a6b03a3cd4010ae830ac232729", @"/Views/Doctor/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa9bc2625cd12a3f4353ae6e86d829650faf496e", @"/Views/_ViewImports.cshtml")]
    public class Views_Doctor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/delete1.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("46"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/mesJS/Doctor.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<div class=""content"">
    <div class=""row"">
        <div class=""col-sm-4 col-3"">
            <h4 class=""page-title"">les Medecins</h4>
        </div>
        <div class=""col-sm-8 col-9 text-right m-b-20"">
            <a href=""#addmodal"" onclick=""addmodalshow()"" class=""btn btn btn-primary btn-rounded float-right""><i class=""fa fa-plus""></i> Ajouter medecin</a>
        </div>
    </div>
    <br />
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""table-responsive"">
                <table id=""tabledocteuqqr"" class=""table table-border table-striped custom-table datatable mb-0"">
                    <thead>
                        <tr>
                            <th>Nom Prenom</th>
                            <th>Speciality</th>
                            <th>Telephones </th>
                            <th>Email</th>
                            <th>Adress</th>
                            <th>Affiliation</th>
                            <th>Type</th>

            ");
            WriteLiteral("                <th class=\"text-right\">Action</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 34 "D:\projet\stage\code\justch\justch\Views\Doctor\Index.cshtml"
                         foreach (var item in ViewBag.Doctors)
                        {



#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>  ");
#nullable restore
#line 39 "D:\projet\stage\code\justch\justch\Views\Doctor\Index.cshtml"
                                 Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("   &nbsp;   ");
#nullable restore
#line 39 "D:\projet\stage\code\justch\justch\Views\Doctor\Index.cshtml"
                                                            Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("   </td>\r\n                                <td>");
#nullable restore
#line 40 "D:\projet\stage\code\justch\justch\Views\Doctor\Index.cshtml"
                               Write(item.Speciality);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td> ");
#nullable restore
#line 41 "D:\projet\stage\code\justch\justch\Views\Doctor\Index.cshtml"
                                Write(item.Phone1);

#line default
#line hidden
#nullable disable
            WriteLiteral("   &nbsp;  ");
#nullable restore
#line 41 "D:\projet\stage\code\justch\justch\Views\Doctor\Index.cshtml"
                                                       Write(item.Phone2);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td>");
#nullable restore
#line 42 "D:\projet\stage\code\justch\justch\Views\Doctor\Index.cshtml"
                               Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </td>\r\n                                <td>");
#nullable restore
#line 43 "D:\projet\stage\code\justch\justch\Views\Doctor\Index.cshtml"
                               Write(item.Adress);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td>");
#nullable restore
#line 44 "D:\projet\stage\code\justch\justch\Views\Doctor\Index.cshtml"
                               Write(item.Affiliation);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td>");
#nullable restore
#line 45 "D:\projet\stage\code\justch\justch\Views\Doctor\Index.cshtml"
                               Write(item.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </td>
                                <td class=""text-right"">
                                    <div class=""dropdown dropdown-action"">
                                        <a href=""#"" class=""action-icon dropdown-toggle"" data-toggle=""dropdown"" aria-expanded=""false""><i class=""fa fa-ellipsis-v""></i></a>
                                        <div class=""dropdown-menu dropdown-menu-right"">
                                            <a class=""dropdown-item"" href=""#editmodal""");
            BeginWriteAttribute("onclick", " onclick=\"", 2360, "\"", 2394, 3);
            WriteAttributeValue("", 2370, "showeditemodal(", 2370, 15, true);
#nullable restore
#line 50 "D:\projet\stage\code\justch\justch\Views\Doctor\Index.cshtml"
WriteAttributeValue("", 2385, item.Id, 2385, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2393, ")", 2393, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-pencil m-r-5\"></i> Modifier</a>\r\n                                            <a class=\"dropdown-item\" href=\"#supprimermodal\" data-toggle=\"modal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2556, "\"", 2590, 3);
            WriteAttributeValue("", 2566, "showmodaldelle(", 2566, 15, true);
#nullable restore
#line 51 "D:\projet\stage\code\justch\justch\Views\Doctor\Index.cshtml"
WriteAttributeValue("", 2581, item.Id, 2581, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2589, ")", 2589, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-trash-o m-r-5\"></i> Supprimer</a>\r\n                                        </div>\r\n                                    </div>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 56 "D:\projet\stage\code\justch\justch\Views\Doctor\Index.cshtml"
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






<div id=""addmodal"" class=""modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""modal-dialog  modal-xl  "">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <div class=""modal-header p-3 mb-2 bg-primary text-white"">

                    <h3>   ajouter MEDECIN </h3>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>

                </div>

                <div class=""modal-body"">

                    <div class=""form-row"">




                        <div class=""form-group col-md-4"">
                            <label for=""inputPassword4"" class=""float-left"">  FirstName <span>*</span></label>

                            <input type=""text"" class=""form-control"" id=""Fi");
            WriteLiteral(@"rstName"" placeholder=""FirstName"">
                            <label class=""text-danger"" id=""a"">
                                saisir le Nom

                            </label>
                        </div>


                        <div class=""form-group col-md-4"">
                            <label for=""inputAddress2 "" class=""float-left"">LastName </label>
                            <input type=""text"" class=""form-control"" id=""LastName"" placeholder=""LastName"">
                            <label class=""text-danger"" id=""dk"">
                                saisir le prenom

                            </label>
                        </div>
                        <div class=""form-group col-md-4"">
                            <label for=""inputAddress2"" class=""float-left"">Speciality </label>
                            <input type=""text"" class=""form-control"" id=""Speciality"" placeholder=""Speciality"">
                            <label class=""text-danger"" id=""di"">
                         ");
            WriteLiteral(@"       saisir la specialite

                            </label>
                        </div>
                        <div class=""form-group col-md-4"">
                            <label for=""inputAddress2"" class=""float-left"">Telephone </label>
                            <input type=""tel"" class=""form-control"" id=""Phone1"" placeholder=""Telephone"">
                            <label class=""text-danger"" id=""dij"">
                                saisir le Numereau de telephone

                            </label>
                        </div>
                        <div class=""form-group col-md-4"">
                            <label for=""inputAddress2"" class=""float-left"">Telephone 2 </label>
                            <input type=""tel"" class=""form-control"" id=""Phone2"" placeholder=""Telephone"">
                        </div>
                        <div class=""form-group col-md-4"">
                            <label for=""inputAddress2"" class=""float-left"">Email  </label>
                    ");
            WriteLiteral(@"        <input type=""email"" class=""form-control"" id=""Email"" placeholder=""email"">
                            <label class=""text-danger"" id=""dijk"">
                                saisir votre adresse mail
                            </label>
                        </div>
                        <div class=""form-group col-md-4"">
                            <label for=""inputAddress2"" class=""float-left"">Adress  </label>
                            <input type=""text"" class=""form-control"" id=""Adress"" placeholder=""Adress"">
                        </div>

                        <div class=""form-group col-md-4"">
                            <label for=""inputAddress2"" class=""float-left"">Affiliation  </label>
                            <input type=""text"" class=""form-control"" id=""Affiliation"" placeholder=""Affiliation"">
                        </div>
                        <div class=""form-group col-md-4"">
                            <label for=""inputAddress2"" class=""float-left"">Type  </label>
        ");
            WriteLiteral(@"                    <input type=""text"" class=""form-control"" id=""Type"" placeholder=""Type"">
                        </div>
                    </div>
                </div>
                    <div class=""mx-auto"" style=""width: 200px;"">
                        <button type=""button"" class=""btn btn-primary"" onclick=""addDooctor()""><i class=""fa fa-plus m-r-5""> Ajouter </i> </button>
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
        </div>
    </div>
</div>






<div id=""supprimermodal"" class=""modal fade delete-modal"" role=""dialog"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b0412254c43946a6b03a3cd4010ae830ac23272916676", async() => {
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
                <h3>Vous voulez sûrement supprimer cet docteur  ?</h3>
                <h3>  cette action impliquera la suppression des tous ces rendez vous et les actes qu'il avait fait ou qu'il fera </h3>
                <div class=""m-t-20"">
                    <a href=""#"" class=""btn btn-white"" data-dismiss=""modal"" onclick=""fermer()"" style=""width: 25%;"">Fermer</a>
                    <button type=""submit"" class=""btn btn-danger"" style=""width: 25%;"" onclick=""confirmationdelete()"">Supprimer</button>
                </div>
            </div>
        </div>
    </div>
</div>








");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0412254c43946a6b03a3cd4010ae830ac23272918679", async() => {
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
#line 198 "D:\projet\stage\code\justch\justch\Views\Doctor\Index.cshtml"
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
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591