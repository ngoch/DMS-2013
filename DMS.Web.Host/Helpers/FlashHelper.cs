using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Resources;
using System.Diagnostics;

namespace DMS.Web.Host.Helpers
{
    public static class FlashHelper
    {
        const string MessageKey = "Message";
        const string ErrorKey = "Error";


        public static string FlashMessageClassName { get; set; }
        public static string ErrorMessageClassName { get; set; }
        public static string ContainerClassName { get; set; }
        public static string InformationIconClassName { get; set; }
        public static Type ResourceType { get; set; }

        static ResourceManager _resourceManager;
        static ResourceManager ResourceManager
        {
            get
            {
                if (_resourceManager == null)
                {
                    _resourceManager = new ResourceManager(ResourceType);
                }
                return _resourceManager;
            }
        }

        const string CreatedFormatResourceKey = "CreatedFormat";
        const string UpdatedFormatResourceKey = "UpdatedFormat";
        const string DeletedFormatResourceKey = "DeletedFormat";

        static FlashHelper()
        {
            FlashMessageClassName = "ui-state-highlight";
            ErrorMessageClassName = "ui-state-error";
            ContainerClassName = "flash-container";
            InformationIconClassName = "flash-icon ui-icon ui-icon-info";
        }

        public static MvcHtmlString RenderFlash(this TempDataDictionary tempData)
        {
            MvcHtmlString result = MvcHtmlString.Empty;

            if (tempData != null)
            {
                if (tempData.ContainsKey(MessageKey))
                {
                    result = CreateFlash(tempData, MessageKey, FlashMessageClassName);
                }
                if (tempData.ContainsKey(ErrorKey))
                {
                    result = CreateFlash(tempData, ErrorKey, ErrorMessageClassName);
                }
            }

            return result;
        }

        private static MvcHtmlString CreateFlash(TempDataDictionary tempData, string key, string className)
        {

            TagBuilder divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass(ContainerClassName);
            divBuilder.AddCssClass(className);

            TagBuilder informationIconBuilder = new TagBuilder("span");
            informationIconBuilder.AddCssClass(InformationIconClassName);

            TagBuilder flashContentBuilder = new TagBuilder("span");
            flashContentBuilder.SetInnerText(tempData[key].ToString());

            divBuilder.InnerHtml += informationIconBuilder.ToString(TagRenderMode.Normal);
            divBuilder.InnerHtml += flashContentBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(divBuilder.ToString(TagRenderMode.Normal));
        }

        public static void AddSuccesfullyCreatedFlash(this TempDataDictionary tempData, string description)
        {
            AddFlash(tempData, GetFormattedFlashMessage(CreatedFormatResourceKey, description));
        }

        public static void AddSuccesfullyUpdatedFlash(this TempDataDictionary tempData, string description)
        {
            AddFlash(tempData, GetFormattedFlashMessage(UpdatedFormatResourceKey, description));
        }

        public static void AddSuccesfullyDeletedFlash(this TempDataDictionary tempData, string description)
        {
            AddFlash(tempData, GetFormattedFlashMessage(DeletedFormatResourceKey, description));
        }

        private static string GetFormattedFlashMessage(string format, params string[] parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("description");
            }

            Debug.Assert(!string.IsNullOrEmpty(format), "format cannot be null");

            return string.Format(ResourceManager.GetString(format), parameters);
        }

        public static void AddError(this TempDataDictionary tempData, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException("message");
            }
            if (tempData != null)
            {
                tempData[ErrorKey] = message;
            }
        }

        public static void AddFlash(this TempDataDictionary tempData, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException("message");
            }
            if (tempData != null)
            {
                tempData[MessageKey] = message;
            }
        }

        public static void AddFormat(this TempDataDictionary tempData, string format, params object[] args)
        {
            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentNullException("format");
            }
            string message = string.Format(format, args);
            if (tempData != null)
            {
                tempData[MessageKey] = message;
            }
        }
    }
}
