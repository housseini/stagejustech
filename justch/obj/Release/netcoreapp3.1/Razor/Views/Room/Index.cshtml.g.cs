#pragma checksum "D:\projet\stage\code\justch\justch\Views\Room\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb4b98fa4cda9369cc9538d802fd97cc958d3c37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Room_Index), @"mvc.1.0.view", @"/Views/Room/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb4b98fa4cda9369cc9538d802fd97cc958d3c37", @"/Views/Room/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa9bc2625cd12a3f4353ae6e86d829650faf496e", @"/Views/_ViewImports.cshtml")]
    public class Views_Room_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/delete1.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("46"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/mesJS/Room.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<div class=""profile-tabs"">
	<ul class=""nav nav-tabs nav-tabs-bottom"">
						<li class=""nav-item""><a class=""nav-link active"" href=""#about-cont"" data-toggle=""tab"">Liste des RoomType</a></li>
						<li class=""nav-item""><a class=""nav-link"" href=""#bottom-tab2"" data-toggle=""tab"">Room</a></li>
                      
					</ul>

					<div class=""tab-content"">
						<div class=""tab-pane show active"" id=""about-cont"">
                            <div class=""content"">
                <div class=""row"">
                    <div class=""col-sm-4 col-3"">
                        <h4 class=""page-title"">RoomType</h4>
                    </div>
                    <div class=""col-sm-8 col-9 text-right m-b-20"">
                        <a href=""#ajoutermodalRoomtype""  onclick=""showmodaladdRoomType()"" class=""btn btn btn-primary btn-rounded float-right""><i class=""fa fa-plus""></i> Ajouter RoomType </a>
                    </div>
                </div>
				  <div class=""row"">
					<div class=""col-md-12"">
						<div ");
            WriteLiteral(@"class=""table-responsive"">
							<table  id=""roomtypetable"" class=""table table-border table-striped  "">
								<thead>
									<tr>
										<th>Nom</th>
										
										<th class=""text-right"" >Action</th>
									</tr>
								</thead>
                                <tbody>
");
            WriteLiteral(@"                                </tbody>

							
							</table>
						</div>
					</div>
                      </div>
                       </div>
						</div>
						<div class=""tab-pane"" id=""bottom-tab2"">
							  <div class=""row"">
                                  <div class=""col-sm-4 col-3"">
                              <h4 class=""page-title"">Room</h4>
                            </div>

                              <div class=""col-sm-8 col-9 text-right m-b-20"">
                                 <a href=""#ajoutermodalRoom""  onclick=""showmodaladdRoom()"" class=""btn btn btn-primary btn-rounded float-right""><i class=""fa fa-plus""></i> Ajouter Room </a>
                                 </div>
                                   </div>

                    <div class=""row"">
					<div class=""col-md-12"">
						<div class=""table-responsive"">
							<table  id=""room"" width=""100%"" class=""table table-border table-striped  "">
								<thead>
									<tr>
                                    ");
            WriteLiteral("    <th>Room Type</th>\r\n\t\t\t\t\t\t\t\t\t\t<th>Nom</th>\r\n\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t<th class=\"text-right\" >Action</th>\r\n\t\t\t\t\t\t\t\t\t</tr>\r\n\t\t\t\t\t\t\t\t</thead>\r\n                                <tbody>\r\n");
            WriteLiteral(@"                                </tbody>

							
							</table>
						</div>
					</div>
                      </div>
						</div>
						
					</div>
				</div>
<div id=""ajoutermodalRoomtype"" class=""modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""modal-dialog  modal-md  "">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <div class=""modal-header p-2 mb-2 bg-primary text-white"">
                    <h3>   ajoute ROOM TYPE </h3>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>

                </div>
                <div class=""modal-body"">

                    <div class=""form-group "">
                        <label for=""inputPassword4"" class=""float-left"">  Name <span>*</span></label>

                        <input type=""text"" class=""form-control"" id=""NameRoomType"" placeholde");
            WriteLiteral(@"r=""Name"">
                    </div>
                </div>


                    <div class=""mx-auto"" style=""width: 200px;"">
                        <button type=""button"" class=""btn btn-primary"" onclick=""addRoomType()""><i class=""fa fa-plus m-r-5""> Ajouter </i> </button>
                    </div>
                </div>
            </div>
    </div>
</div>

<div id=""ajoutermodalRoom"" class=""modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""modal-dialog  modal-md  "">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <div class=""modal-header p-2 mb-2 bg-primary text-white"">
                    <h3>   ajoute ROOM  </h3>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>

                </div>
                <div class=""modal-body"">
                    <div class=""form-group "">
       ");
            WriteLiteral(@"                 <label for=""inputPassword4"" class=""float-left"">  Name <span>*</span></label>

                        <input type=""text"" class=""form-control"" id=""NameRoom"" placeholder=""Name"">
                    </div>
                    <div class=""form-group "">
                        <label for=""inputAddress2"" class=""float-left"">Room Type </label>
                        <select class=""form-control"" id=""Idroomtype"">*
");
#nullable restore
#line 177 "D:\projet\stage\code\justch\justch\Views\Room\Index.cshtml"
                         if(ViewBag.Roomtype != null)
            {

          
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 181 "D:\projet\stage\code\justch\justch\Views\Room\Index.cshtml"
                             foreach (var item in ViewBag.Roomtype)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb4b98fa4cda9369cc9538d802fd97cc958d3c3711309", async() => {
                WriteLiteral(" ");
#nullable restore
#line 183 "D:\projet\stage\code\justch\justch\Views\Room\Index.cshtml"
                                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 183 "D:\projet\stage\code\justch\justch\Views\Room\Index.cshtml"
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
#line 184 "D:\projet\stage\code\justch\justch\Views\Room\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 184 "D:\projet\stage\code\justch\justch\Views\Room\Index.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </select>

                    </div>
                </div>
                <div class=""mx-auto"" style=""width: 200px;"">
                    <button type=""button"" class=""btn btn-primary"" onclick=""addRoom()""><i class=""fa fa-plus m-r-5""> Ajouter </i> </button>
                </div>
            </div>
        </div>
    </div>
</div>


<div id=""editemodalRoomtype"" class=""modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""modal-dialog  modal-md  "">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <div class=""modal-header p-2 mb-2 bg-primary text-white"">
                    <h3>   Modifier ROOM TYPE </h3>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>

                </div>
                <div class=""modal-body"">
                    <div class=""form-group "">
            WriteLiteral(@"
                        <label for=""inputPassword4"" class=""float-left"">  Name <span>*</span></label>

                        <input type=""text"" class=""form-control"" id=""NameRoomTypemodifier"" placeholder=""ENTREZ LE NOUVEAU NOM"">
                    </div>
                </div>
                    <div class=""mx-auto"" style=""width: 200px;"">
                        <button type=""button"" class=""btn btn-primary"" onclick=""modifierRoomtype()""><i class=""fa fa-pencil m-r-5""> modifier </i> </button>
                    </div>

                </div>
            </div>
    </div>
</div>
<div id=""editemodalRoom"" class=""modal fade bd-example-modal-xl"" role=""dialog"">
    <div class=""modal-dialog modal-md  "">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                <div class=""modal-header p-2 mb-2 bg-primary text-white"">
                    <h3>   EDIT ROOM  </h3>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""");
            WriteLiteral(">\r\n                        <span aria-hidden=\"true\">&times;</span>\r\n                    </button>\r\n\r\n                </div>\r\n                <div class=\"modal-body\">\r\n                    <div class=\"form-group\" id=\"editroom\">\r\n\r\n\r\n");
            WriteLiteral("                    </div>\r\n                    <div class=\"form-group \">\r\n                        <label for=\"inputAddress2\" class=\"float-left\">Room Type </label>\r\n                        <select class=\"form-control\" id=\"Idroomtypeedi\">\r\n\r\n");
#nullable restore
#line 246 "D:\projet\stage\code\justch\justch\Views\Room\Index.cshtml"
                             if (ViewBag.Roomtype != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 248 "D:\projet\stage\code\justch\justch\Views\Room\Index.cshtml"
                                 foreach (var item in ViewBag.Roomtype)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb4b98fa4cda9369cc9538d802fd97cc958d3c3716846", async() => {
                WriteLiteral(" ");
#nullable restore
#line 250 "D:\projet\stage\code\justch\justch\Views\Room\Index.cshtml"
                                                       Write(item.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 250 "D:\projet\stage\code\justch\justch\Views\Room\Index.cshtml"
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
#line 251 "D:\projet\stage\code\justch\justch\Views\Room\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 251 "D:\projet\stage\code\justch\justch\Views\Room\Index.cshtml"
                                 }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </select>

                    </div>
                </div>
                <div class=""mx-auto"" style=""width: 200px;"">
                    <button type=""button"" class=""btn btn-primary"" onclick=""editeRoom()""><i class=""fa fa-pencil m-r-5""> ENREGISTRER </i> </button>
                </div>
            </div>
        </div>
    </div>
</div>
<div id=""supprimermodalRoomtype"" class=""modal fade delete-modal"" role=""dialog"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "fb4b98fa4cda9369cc9538d802fd97cc958d3c3719688", async() => {
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
                <p> la suppresion de cet Room type impliquerai la suppression des toute les table dont il appartient ?</p>
                <div class=""m-t-20"">
                    <a href=""#"" class=""btn btn-white"" data-dismiss=""modal"" onclick=""fermer()""   style=""width: 25%;"">Fermer</a>
                    <button type=""submit"" class=""btn btn-danger"" style=""width: 25%;"" onclick=""confirmationdeleteroomtype()"">Supprimer</button>
                </div>
            </div>
        </div>
    </div>
</div>






<div id=""supprimermodalRoom"" class=""modal fade delete-modal"" role=""dialog"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-body text-center"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "fb4b98fa4cda9369cc9538d802fd97cc958d3c3721760", async() => {
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
                <p> la suppresion de cet Room  impliquerai la suppression des toute les table dont il appartient ?</p>>
                <div class=""m-t-20"">
                    <a href=""#"" class=""btn btn-white"" data-dismiss=""modal"" onclick=""fermer()""   style=""width: 25%;"">Fermer</a>
                    <button type=""submit"" class=""btn btn-danger"" style=""width: 25%;"" onclick=""confirmationdeleteroom()"">Supprimer</button>
                </div>
            </div>
        </div>
    </div>
</div>





");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb4b98fa4cda9369cc9538d802fd97cc958d3c3723675", async() => {
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
#line 304 "D:\projet\stage\code\justch\justch\Views\Room\Index.cshtml"
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