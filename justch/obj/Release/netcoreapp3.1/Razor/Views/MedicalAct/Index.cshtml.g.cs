#pragma checksum "D:\projet\stage\code\justch\justch\Views\MedicalAct\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24fce4dc291f41ba78dc8abf1269a9795349d0df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MedicalAct_Index), @"mvc.1.0.view", @"/Views/MedicalAct/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24fce4dc291f41ba78dc8abf1269a9795349d0df", @"/Views/MedicalAct/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa9bc2625cd12a3f4353ae6e86d829650faf496e", @"/Views/_ViewImports.cshtml")]
    public class Views_MedicalAct_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MedicalAct>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/mesJS/MedicalAct.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            <h4 class=""page-title"">Actes medical</h4>
        </div>
        <div class=""col-sm-8 col-9 text-right m-b-20"">
            <a href=""#ajoutermodal"" onclick=""showaddmodal()"" class=""btn btn btn-primary btn-rounded float-right""><i class=""fa fa-plus""></i> Ajouter</a>
        </div>
    </div>

    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""table-responsive"">
                <table id=""tableMEDICALACT""   class=""table table-border table-striped custom-table datatable mb-0"">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>MedicalActType</th>
                            <th>Duration</th>
                            <th>Category</th>
                            <th class=""text-right"">Action</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 31 "D:\projet\stage\code\justch\justch\Views\MedicalAct\Index.cshtml"
                         if (ViewBag.Medicalacts != null)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "D:\projet\stage\code\justch\justch\Views\MedicalAct\Index.cshtml"
                             foreach (var item in ViewBag.Medicalacts)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td> ");
#nullable restore
#line 36 "D:\projet\stage\code\justch\justch\Views\MedicalAct\Index.cshtml"
                                    Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                    <td> ");
#nullable restore
#line 37 "D:\projet\stage\code\justch\justch\Views\MedicalAct\Index.cshtml"
                                    Write(item.MedicalActType);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                    <td> ");
#nullable restore
#line 38 "D:\projet\stage\code\justch\justch\Views\MedicalAct\Index.cshtml"
                                    Write(item.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                    <td> ");
#nullable restore
#line 39 "D:\projet\stage\code\justch\justch\Views\MedicalAct\Index.cshtml"
                                    Write(item.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </td>
                                    <td class=""text-right"">
                                        <div class=""dropdown dropdown-action"">
                                            <a href=""#"" class=""action-icon dropdown-toggle"" data-toggle=""dropdown"" aria-expanded=""false""><i class=""fa fa-ellipsis-v""></i></a>
                                            <div class=""dropdown-menu dropdown-menu-right"">
                                                <a class=""dropdown-item"" href=""#EXPLORER""");
            BeginWriteAttribute("onclick", " onclick=\"", 2142, "\"", 2179, 3);
            WriteAttributeValue("", 2152, "showEXPLORERmodal(", 2152, 18, true);
#nullable restore
#line 44 "D:\projet\stage\code\justch\justch\Views\MedicalAct\Index.cshtml"
WriteAttributeValue("", 2170, item.ID, 2170, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2178, ")", 2178, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-pencil m-r-5\"></i> EXPLORER</a>\r\n\r\n                                                <a class=\"dropdown-item\" href=\"#consultermodal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2327, "\"", 2365, 3);
            WriteAttributeValue("", 2337, "showconsultermodal(", 2337, 19, true);
#nullable restore
#line 46 "D:\projet\stage\code\justch\justch\Views\MedicalAct\Index.cshtml"
WriteAttributeValue("", 2356, item.ID, 2356, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2364, ")", 2364, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-pencil m-r-5\"></i> Consulter</a>\r\n                                                <a class=\"dropdown-item\" href=\"#editmodal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2507, "\"", 2541, 3);
            WriteAttributeValue("", 2517, "showeditemodal(", 2517, 15, true);
#nullable restore
#line 47 "D:\projet\stage\code\justch\justch\Views\MedicalAct\Index.cshtml"
WriteAttributeValue("", 2532, item.ID, 2532, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2540, ")", 2540, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-pencil m-r-5\"></i> Modifier</a>\r\n                                                <a class=\"dropdown-item\" href=\"#supprimermodal\" data-toggle=\"modal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2707, "\"", 2741, 3);
            WriteAttributeValue("", 2717, "showmodaldelle(", 2717, 15, true);
#nullable restore
#line 48 "D:\projet\stage\code\justch\justch\Views\MedicalAct\Index.cshtml"
WriteAttributeValue("", 2732, item.ID, 2732, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2740, ")", 2740, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-trash-o m-r-5\"></i> Supprimer</a>\r\n                                            </div>\r\n                                        </div>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 53 "D:\projet\stage\code\justch\justch\Views\MedicalAct\Index.cshtml"

                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "D:\projet\stage\code\justch\justch\Views\MedicalAct\Index.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>

                </table>
            </div>
        </div>

    </div>
</div>
<div id=""ajoutermodal"" class=""modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""modal-dialog  modal-xl  "">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <div class=""modal-header p-2 mb-2 bg-primary text-white"">
                    <h3>   ajoute Medical Acte </h3>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>

                </div>
                <div class=""modal-body"">

                    <div class=""form-row"">




                        <div class=""form-group col-md-6"">
                            <label for=""inputPassword4"" class=""float-left"">  Name <span>*</span></label>

                            <input type=""text"" class=""form-control"" id=""Name"" placehold");
            WriteLiteral(@"er=""Name"">

                            <label class=""text-danger"" id=""mN"">
                                saisir le Nom de Act Medical

                            </label>

                        </div>


                        <div class=""form-group col-md-6"">
                            <label for=""inputAddress2"" class=""float-left"">ROOM </label>


                            <select class=""form-control"" id=""IdRoom"">

                              
                               
                              
                            </select>
                           

                        </div>
                        <div class=""form-group col-md-6"">
                            <label for=""inputAddress2"" class=""float-left"">Duré </label>
                            <input type=""number"" class=""form-control"" id=""Duration"" value=15 min=15>
                        </div>
                        <div class=""form-group col-md-6"">
                            <label for=""");
            WriteLiteral(@"inputAddress2"" class=""float-left"">Category </label>
                            <input type=""text"" class=""form-control"" id=""Category"" placeholder=""Category"">
                            <label class=""text-danger"" id=""mc"">
                                saisir LA Category

                            </label>
                        </div>
                    </div>
                </div>
                    <div class=""mx-auto"" style=""width: 200px;"">
                        <button type=""button"" class=""btn btn-primary"" onclick=""addMedicalAct()""><i class=""fa fa-plus m-r-5""> Ajouter </i> </button>
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


<div id=""EXPLORER"" class=""");
            WriteLiteral(@"modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""modal-dialog  modal-xl  "">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <div class=""modal-header p-2 mb-2 bg-primary text-white"">
                    <h3> <i class=""fa fa-book m-r-5""> </i>  EXPLORER ACT MEDICAL </h3>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>

                </div>
                <div class=""modal-body"">
                    <div class=""col-md-12"">
                        <div class=""table-responsive"">

                            <input type=""text"" placeholder=""search"" id=""cherchermedicalacte"" class=""form-control"" />
                            <table id=""mytabe"" width=""100%"" class=""table table-border table-striped custom-table  mb-0"">
                                <thead>
                                    ");
            WriteLiteral(@"<tr>
                                        <th>Nom</th>
                                        <th>Type</th>
                                        <th>Patient</th>
                                        <th>Rang</th>
                                        <th>State</th>

                                    </tr>
                                </thead>
                                <tbody id=""bodytableexpore""></tbody>
                            </table>
                        </div>


                    </div>
                </div>
                </div>
            </div>
    </div>
</div>

<div id=""consultermodal"" class=""modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""modal-dialog  modal-xl  "">
        <div class=""modal-content"">
            <div id=""modal-container1"" class=""modal-body text-center"">
            </div>
        </div>
    </div>
</div>

<div id=""supprimermodal"" class=""modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""moda");
            WriteLiteral(@"l-dialog modal-dialog-centered  "">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <div class=""container"">
                    <h1>Delete </h1>
                    <p> la suppresion de cet Act Medical impliquerai la suppression des toute les table dont il appartient ?</p>

                    <div class=""clearfix"">
                        <button type=""button"" class=""btn  btn-primary"">Cancel</button>
                        <button type=""button"" onclick=""confirmationdelete()"" class=""btn btn-danger"">Delete</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24fce4dc291f41ba78dc8abf1269a9795349d0df16507", async() => {
                    WriteLiteral("\r\n\r\n\r\n");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 208 "D:\projet\stage\code\justch\justch\Views\MedicalAct\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MedicalAct> Html { get; private set; }
    }
}
#pragma warning restore 1591
