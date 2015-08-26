// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace DMS.Web.Host.Controllers
{
    public partial class AssessmentsController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AssessmentsController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Details()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Details);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult TestAssessment()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.TestAssessment);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ManualAssessment()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ManualAssessment);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult TestAssessmentQuestion()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.TestAssessmentQuestion);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ConfirmAssessment()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ConfirmAssessment);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AssessmentsController Actions { get { return MVC.Assessments; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Assessments";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Assessments";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Details = "Details";
            public readonly string TestAssessment = "TestAssessment";
            public readonly string ManualAssessment = "ManualAssessment";
            public readonly string TestAssessmentQuestion = "TestAssessmentQuestion";
            public readonly string ConfirmAssessment = "ConfirmAssessment";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Details = "Details";
            public const string TestAssessment = "TestAssessment";
            public const string ManualAssessment = "ManualAssessment";
            public const string TestAssessmentQuestion = "TestAssessmentQuestion";
            public const string ConfirmAssessment = "ConfirmAssessment";
        }


        static readonly ActionParamsClass_Details s_params_Details = new ActionParamsClass_Details();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Details DetailsParams { get { return s_params_Details; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Details
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_TestAssessment s_params_TestAssessment = new ActionParamsClass_TestAssessment();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_TestAssessment TestAssessmentParams { get { return s_params_TestAssessment; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_TestAssessment
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_ManualAssessment s_params_ManualAssessment = new ActionParamsClass_ManualAssessment();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ManualAssessment ManualAssessmentParams { get { return s_params_ManualAssessment; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ManualAssessment
        {
            public readonly string id = "id";
            public readonly string viewModel = "viewModel";
        }
        static readonly ActionParamsClass_TestAssessmentQuestion s_params_TestAssessmentQuestion = new ActionParamsClass_TestAssessmentQuestion();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_TestAssessmentQuestion TestAssessmentQuestionParams { get { return s_params_TestAssessmentQuestion; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_TestAssessmentQuestion
        {
            public readonly string id = "id";
            public readonly string index = "index";
            public readonly string chosenFactors = "chosenFactors";
        }
        static readonly ActionParamsClass_ConfirmAssessment s_params_ConfirmAssessment = new ActionParamsClass_ConfirmAssessment();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ConfirmAssessment ConfirmAssessmentParams { get { return s_params_ConfirmAssessment; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ConfirmAssessment
        {
            public readonly string id = "id";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string Details = "Details";
                public readonly string Index = "Index";
                public readonly string ManualAssessment = "ManualAssessment";
                public readonly string TestAssessmentQuestion = "TestAssessmentQuestion";
            }
            public readonly string Details = "~/Views/Assessments/Details.cshtml";
            public readonly string Index = "~/Views/Assessments/Index.cshtml";
            public readonly string ManualAssessment = "~/Views/Assessments/ManualAssessment.cshtml";
            public readonly string TestAssessmentQuestion = "~/Views/Assessments/TestAssessmentQuestion.cshtml";
            static readonly _DisplayTemplatesClass s_DisplayTemplates = new _DisplayTemplatesClass();
            public _DisplayTemplatesClass DisplayTemplates { get { return s_DisplayTemplates; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _DisplayTemplatesClass
            {
                public readonly string AssessmentTableRowModel = "AssessmentTableRowModel";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_AssessmentsController : DMS.Web.Host.Controllers.AssessmentsController
    {
        public T4MVC_AssessmentsController() : base(Dummy.Instance) { }

        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        partial void DetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        public override System.Web.Mvc.ActionResult Details(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Details);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DetailsOverride(callInfo, id);
            return callInfo;
        }

        partial void TestAssessmentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        public override System.Web.Mvc.ActionResult TestAssessment(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.TestAssessment);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            TestAssessmentOverride(callInfo, id);
            return callInfo;
        }

        partial void ManualAssessmentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        public override System.Web.Mvc.ActionResult ManualAssessment(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ManualAssessment);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ManualAssessmentOverride(callInfo, id);
            return callInfo;
        }

        partial void ManualAssessmentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id, DMS.Web.Host.Models.ManualAssessmentViewModel viewModel);

        public override System.Web.Mvc.ActionResult ManualAssessment(int id, DMS.Web.Host.Models.ManualAssessmentViewModel viewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ManualAssessment);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "viewModel", viewModel);
            ManualAssessmentOverride(callInfo, id, viewModel);
            return callInfo;
        }

        partial void TestAssessmentQuestionOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id, int index);

        public override System.Web.Mvc.ActionResult TestAssessmentQuestion(int id, int index)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.TestAssessmentQuestion);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "index", index);
            TestAssessmentQuestionOverride(callInfo, id, index);
            return callInfo;
        }

        partial void TestAssessmentQuestionOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id, int index, System.Collections.Generic.IEnumerable<int> chosenFactors);

        public override System.Web.Mvc.ActionResult TestAssessmentQuestion(int id, int index, System.Collections.Generic.IEnumerable<int> chosenFactors)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.TestAssessmentQuestion);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "index", index);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "chosenFactors", chosenFactors);
            TestAssessmentQuestionOverride(callInfo, id, index, chosenFactors);
            return callInfo;
        }

        partial void ConfirmAssessmentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        public override System.Web.Mvc.ActionResult ConfirmAssessment(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ConfirmAssessment);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ConfirmAssessmentOverride(callInfo, id);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591