#pragma checksum "D:\projet\stage\code\justch\justch\Views\DossierMedical\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8388d8b72fb6a6c361a93ff3bcc85f9c8f9fee46"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DossierMedical_Index), @"mvc.1.0.view", @"/Views/DossierMedical/Index.cshtml")]
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
#nullable restore
#line 4 "D:\projet\stage\code\justch\justch\Views\DossierMedical\Index.cshtml"
using justch.Models.ENTITIES;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8388d8b72fb6a6c361a93ff3bcc85f9c8f9fee46", @"/Views/DossierMedical/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29bfc70c29d416edd07ec37bddce3a4941f800f6", @"/Views/_ViewImports.cshtml")]
    public class Views_DossierMedical_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/delete1.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("46"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/dossiermedical.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-sm-4 col-3"">
        <h4 class=""page-title"">Dossiers Patients</h4>
    </div>
    <div class=""col-sm-8 col-9 text-right m-b-20"">
        <a href=""/DossierMedical/Add"" class=""btn btn-primary btn-rounded float-right""><i class=""fa fa-plus""></i>   Ajout Dossier</a>
        <button type=""button"" class=""btn btn btn-primary btn-rounded float-right"" onclick=""modalrecherche()""><i class=""fa  fa-search""></i> recherche Avancé </button>
    </div>
</div>


<div class=""profile-tabs "">
    <ul class=""nav nav-tabs nav-tabs-bottom "">
        <li class=""nav-item""><a class=""nav-link active"" href=""#about-cont"" data-toggle=""tab""><i class=""fa fa-list""></i> </a></li>
        <li class=""nav-item""><a class=""nav-link"" href=""#bottom-tab2"" data-toggle=""tab""><i class=""fa fa-th""></i></a></li>

    </ul>

    <div class=""tab-content"">
        <div class=""tab-pane show active"" id=""about-cont"">
            <div class=""content"">

                <div id=""toudossiers"" class=""table-r");
            WriteLiteral(@"esponsive"">
                    <table id=""table_id""  width=""100%"" class="" table table-striped table-bordered"">
                        <thead>
                            <tr>
                                <th>Reference</th>
                                <th>Type</th>
                                <th>State</th>
                                <th>DateAdmission</th>
                                <th>DateCreation</th>


                                <th class=""text-right"">Action</th>
                            </tr>
                        </thead>


                    </table>

                </div>
            </div>
        </div>
        <div class=""tab-pane"" id=""bottom-tab2"">

        


           
            <div class=""content"">

               <input class=""float-right""   type=""text"" id=""recherchereference"" placeholder=""rechercher"">
                <br /> <br />


                <div class=""row doctor-grid"" id=""conterr"">

                   


    ");
            WriteLiteral(@"            </div>
            </div>

        </div>
    </div>
<div id=""rechecher"" class=""modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""modal-dialog  modal-xl  "">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <h3> <i class=""fa fa-search m-r-5""> </i> recherche avancé</h3>
                <h3 id=""info"" class=""alert-danger"">   vous de remplir au moins un champ </h3>
                <div class=""row"">
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label>Réference </label>
                            <input id=""Ref"" name=""Ref"" class=""form-control"" type=""text"">

                        </div>
                    </div>
                    <div class=""col-md-4"">
                        <div class=""form-group"">
                            <label>Date de creation </label>
                            <div class=""cal-icon"">
                             ");
            WriteLiteral(@"   <input id=""dataa"" name=""dataa"" type=""text"" class=""form-control datetimepicker"">

                            </div>
                        </div>
                         </div>
                         <div class=""col-md-2"">
                           <div class=""form-group"">
                            <label>plage jours </label>
                            <input id=""nbr"" name=""nbr"" class=""form-control"" type=""number"" min=0 value=0>

                        </div>
                    </div>
                    <div class=""col-md"">
                        <div class=""form-group"">
                            <label> Patient </label>

                            <select class=""select"" id=""Id"" name=""Id"" multiple>
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8388d8b72fb6a6c361a93ff3bcc85f9c8f9fee469781", async() => {
                WriteLiteral(" ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 110 "D:\projet\stage\code\justch\justch\Views\DossierMedical\Index.cshtml"
                                 if (ViewBag.Patients != null)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 112 "D:\projet\stage\code\justch\justch\Views\DossierMedical\Index.cshtml"
                                     foreach (var item in ViewBag.Patients)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8388d8b72fb6a6c361a93ff3bcc85f9c8f9fee4611561", async() => {
#nullable restore
#line 114 "D:\projet\stage\code\justch\justch\Views\DossierMedical\Index.cshtml"
                                                            Write(item.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 114 "D:\projet\stage\code\justch\justch\Views\DossierMedical\Index.cshtml"
                                                                            Write(item.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 114 "D:\projet\stage\code\justch\justch\Views\DossierMedical\Index.cshtml"
                                           WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 115 "D:\projet\stage\code\justch\justch\Views\DossierMedical\Index.cshtml"

                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 116 "D:\projet\stage\code\justch\justch\Views\DossierMedical\Index.cshtml"
                                     
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </select>


                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label>Cin </label>

                            <input id=""Cin"" name=""Cin"" type=""text"" class=""form-control "">

                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label>Email </label>

                            <input id=""email"" name=""email"" type=""text"" class=""form-control "">


                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label> Telephone </label>

                            <input id=""telephone"" name=""telephone"" type=""text"" class=""form-control "">


                        </div>
                    </di");
            WriteLiteral(@"v>
                </div>


                <div class=""mx-auto"" style=""width: 200px;"">
                    <button type=""button"" class=""btn btn-primary"" onclick=""recher()""><i class=""fa fa-search m-r-5""> </i>  Rechercher</button>
                </div>
            </div>
        </div>
    </div>
</div>










<div id=""delete_doctor"" class=""modal fade delete-modal"" role=""dialog"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8388d8b72fb6a6c361a93ff3bcc85f9c8f9fee4615826", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <h3>Vous voulez sûrement supprimer ce dossier ?</h3>
                <div class=""m-t-20"">
                    <a href=""#"" class=""btn btn-white"" data-dismiss=""modal"" onclick=""fermer()""   style=""width: 25%;"">Fermer</a>
                    <button type=""submit"" class=""btn btn-primary"" style=""width: 25%;"" onclick=""deletedossier()"">Supprimer</button>
                </div>
            </div>
        </div>
    </div>
</div>



");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8388d8b72fb6a6c361a93ff3bcc85f9c8f9fee4617678", async() => {
                    WriteLiteral("\r\n\r\n\r\n");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#nullable restore
#line 189 "D:\projet\stage\code\justch\justch\Views\DossierMedical\Index.cshtml"
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
                WriteLiteral("\r\n\r\n ");
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
