#pragma checksum "E:\projet\projet\stage\code\justch\justch\Views\Incubateur_Chambre\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d62a8ee0943be9f02719cc5609e9bd16a1de7464"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Incubateur_Chambre_Index), @"mvc.1.0.view", @"/Views/Incubateur_Chambre/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d62a8ee0943be9f02719cc5609e9bd16a1de7464", @"/Views/Incubateur_Chambre/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa9bc2625cd12a3f4353ae6e86d829650faf496e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Incubateur_Chambre_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ajouterIncubateur"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("modifierIncubateur"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ajouterchambre"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("modifierchambre"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/mesJS/Incubateur_Chambre.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""profile-tabs"">
    <ul class=""nav nav-tabs nav-tabs-bottom"">
        <li class=""nav-item""><a class=""nav-link active"" href=""#about-cont"" data-toggle=""tab"">Liste Incubateur</a></li>
        <li class=""nav-item""><a class=""nav-link"" href=""#bottom-tab2"" data-toggle=""tab""> Liste Chambre</a></li>

    </ul>

    <div class=""tab-content"">
        <div class=""tab-pane show active"" id=""about-cont"">
            <div class=""content"">
                <div class=""row"">
                    <div class=""col-sm-4 col-3"">
                        <h4 class=""page-title"">Incubateurs </h4>
                    </div>
                    <div class=""col-sm-8 col-9 text-right m-b-20"">
                        <a href=""#ajoutermodalIncubateurs"" onclick=""showmodaladdIncubateurs()"" class=""btn btn btn-primary btn-rounded float-right""><i class=""fa fa-plus""></i> Ajouter Incubateur </a>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-md-12");
            WriteLiteral(@""">
                        <div class=""table-responsive"">
                            <table id=""TableIncubateurs"" class=""table table-border table-striped  "">
                                <thead>
                                    <tr>
                                        <th>Nom</th>
                                        <th>Nombre de chambre </th>

                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody id=""TableIncubateursBody"">
                                </tbody>


                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""tab-pane"" id=""bottom-tab2"">
            <div class=""row"">
                <div class=""col-sm-4 col-3"">
                    <h4 class=""page-title"">CHAMBRE</h4>
                </div>

                <div class=""col-");
            WriteLiteral(@"sm-8 col-9 text-right m-b-20"">
                    <a href=""#ajoutermodalchambre"" onclick=""showmodaladdCHAMBRE()"" class=""btn btn btn-primary btn-rounded float-right""><i class=""fa fa-plus""></i> Ajouter CHAMBRE </a>
                </div>
            </div>

            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""table-responsive"">
                        <table id=""chambreTable"" width=""100%"" class=""table table-border table-striped  "">
                            <thead>
                                <tr>
                                    <th>Nom</th>
                                    <th>Nom Incubateur</th>

                                    <th class=""text-right"">Action</th>
                                </tr>
                            </thead>
                            <tbody id=""chambreTablebody"">
                            </tbody>


                        </table>
                    </div>
                </div>
       ");
            WriteLiteral(@"     </div>
        </div>

    </div>
</div>

<div id=""ajoutermodalIncubateurs"" class=""modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""modal-dialog  modal-md  "">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <div class=""modal-header p-2 mb-2 bg-primary text-white"">
                    <h3>   Ajout Incubateur </h3>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>

                </div>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d62a8ee0943be9f02719cc5609e9bd16a1de74649567", async() => {
                WriteLiteral(@"
                    <div class=""modal-body"">
                        <div class=""row"">


                            <div class=""form-group col-md-6 "">
                                <label for=""NameIncubate"" class=""float-left"">  Nom <span>*</span></label>

                                <input type=""text"" class=""form-control"" id=""NameIncubate"" name=""NameIncubate"" placeholder=""Name"" required>
                            </div>
                            <div class=""form-group col-md-6  "">
                                <label for=""nombrechambre"" class=""float-left""> Nombre de chambre </label>
                                <input type=""number"" class=""form-control"" id=""nombrechambre"" name=""nombrechambre"" required min=""2"">


                            </div>
                        </div>
                    </div>
                    <div class=""mx-auto"" style=""width: 200px;"">
                        <button type=""submit"" class=""btn btn-primary""><i class=""fa fa-plus m-r-5""> enregistre ");
                WriteLiteral("</i> </button>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>


<div id=""modifiermodalIncubateurs"" class=""modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""modal-dialog  modal-md  "">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <div class=""modal-header p-2 mb-2 bg-primary text-white"">
                    <h3>   Modifier Incubateur </h3>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>

                </div>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d62a8ee0943be9f02719cc5609e9bd16a1de746412716", async() => {
                WriteLiteral(@"
                    <div class=""modal-body"">
                        <div class=""row"">
                            <div class=""form-group col-md-6 "">
                                <label for=""NameIncubate1"" class=""float-left"">  Nom <span>*</span></label>

                                <input type=""text"" class=""form-control"" id=""NameIncubate1"" name=""NameIncubate1"" required>
                            </div>
                            <div class=""form-group col-md-6  "">
                                <label for=""nombrechambre1"" class=""float-left""> Nombre de chambre </label>
                                <input type=""number"" class=""form-control"" id=""nombrechambre1"" name=""nombrechambre1"" required min=""2"">


                            </div>
                        </div>
                    </div>
                    <div class=""mx-auto"" style=""width: 200px;"">
                        <button type=""submit"" class=""btn btn-primary""><i class=""fa fa-plus m-r-5""> enregistre </i> </button>
 ");
                WriteLiteral("                   </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>

<div id=""supprimerIncubateurM"" class=""modal fade delete-modal"" role=""dialog"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <img src=""/img/delete1.png""");
            BeginWriteAttribute("alt", " alt=\"", 7032, "\"", 7038, 0);
            EndWriteAttribute();
            WriteLiteral(@" width=""50"" height=""46"">
                <h3>Vous voulez  supprimer cet IncUBATEUR   ?</h3>
                <div class=""m-t-20"">
                    <a href=""#"" class=""btn btn-white"" data-dismiss=""modal"" onclick=""fermer()"" style=""width: 25%;"">Fermer</a>
                    <button type=""submit"" class=""btn btn-danger"" style=""width: 25%;"" onclick=""confirmesuppressionIN()"">Supprimer</button>
                </div>
            </div>
        </div>
    </div>
</div>

<div id=""ajoutermodalchambre"" class=""modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""modal-dialog  modal-md  "">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <div class=""modal-header p-2 mb-2 bg-primary text-white"">
                    <h3>   Ajout chambre </h3>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>

          ");
            WriteLiteral("      </div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d62a8ee0943be9f02719cc5609e9bd16a1de746416784", async() => {
                WriteLiteral(@"
                    <div class=""modal-body"">
                        <div class=""row"">


                            <div class=""form-group col-md-6 "">
                                <label for=""Namechambre"" class=""float-left"">  Nom <span>*</span></label>

                                <input type=""text"" class=""form-control"" id=""Namechambre"" name=""Namechambre"" placeholder=""Name"" required>
                            </div>
                            <div class=""form-group col-md-6  "">
                                <label for=""IncubateurId"" class=""float-left""> Incubateur </label>
                                <select class=""form-control"" id=""IncubateurId"" name=""IncubateurId"">
                                </select>


                            </div>
                        </div>
                    </div>
                    <div class=""mx-auto"" style=""width: 200px;"">
                        <button type=""submit"" class=""btn btn-primary""><i class=""fa fa-plus m-r-5""> enregistre ");
                WriteLiteral("</i> </button>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>


<div id=""modifiermodalchambre"" class=""modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""modal-dialog  modal-md  "">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <div class=""modal-header p-2 mb-2 bg-primary text-white"">
                    <h3>  modifie chambre </h3>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>

                </div>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d62a8ee0943be9f02719cc5609e9bd16a1de746419921", async() => {
                WriteLiteral(@"
                    <div class=""modal-body"">
                        <div class=""row"">


                            <div class=""form-group col-md-6 "">
                                <label for=""Namechambre1"" class=""float-left"">  Nom <span>*</span></label>

                                <input type=""text"" class=""form-control"" id=""Namechambre1"" name=""Namechambre1"" placeholder=""Name"" required>
                            </div>
                            <div class=""form-group col-md-6  "">
                                <label for=""IncubateurId1"" class=""float-left""> Incubateur </label>
                                <select class=""form-control"" id=""IncubateurId1"" name=""IncubateurId1"">
                                </select>


                            </div>
                        </div>
                    </div>
                    <div class=""mx-auto"" style=""width: 200px;"">
                        <button type=""submit"" class=""btn btn-primary""><i class=""fa fa-plus m-r-5""> enreg");
                WriteLiteral("istre </i> </button>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>


<div id=""supprimercHAMBREM"" class=""modal fade delete-modal"" role=""dialog"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <img src=""/img/delete1.png""");
            BeginWriteAttribute("alt", " alt=\"", 11295, "\"", 11301, 0);
            EndWriteAttribute();
            WriteLiteral(@" width=""50"" height=""46"">
                <h3>Vous voulez  supprimer cet CHAMBRE   ?</h3>
                <div class=""m-t-20"">
                    <a href=""#"" class=""btn btn-white"" data-dismiss=""modal"" onclick=""fermer()"" style=""width: 25%;"">Fermer</a>
                    <button type=""submit"" class=""btn btn-danger"" style=""width: 25%;"" onclick=""confirmesuppressionCHMA()"">Supprimer</button>
                </div>
            </div>
        </div>
    </div>
</div>



");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d62a8ee0943be9f02719cc5609e9bd16a1de746423486", async() => {
                    WriteLiteral("\r\n\r\n\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 272 "E:\projet\projet\stage\code\justch\justch\Views\Incubateur_Chambre\Index.cshtml"
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
                WriteLiteral("\r\n");
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
