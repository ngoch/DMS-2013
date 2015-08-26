using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using System.Collections;

namespace DMS.Web.Host.Helpers
{
    public static class SelectExtensions
    {
        public static MvcHtmlString CheckBoxList<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
        {
            ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            TagBuilder container = new TagBuilder("div");
            TagBuilder listBuilder = new TagBuilder("ul");
            container.AddCssClass("check-box-list");


            TagBuilder listItemBuilder = null;
            TagBuilder checkBoxBuilder = null;
            TagBuilder spanBuilder = null;

            selectList = selectList.ToList();

            if (modelMetadata.Model != null)
            {
                foreach (var item in ((IEnumerable)modelMetadata.Model))
                {
                    SelectListItem itemToBeSelected;
                    if ((itemToBeSelected = selectList.FirstOrDefault(x => x.Value.Equals(item.ToString()) || x.Text.Equals(item.ToString()))) != null)
                    {
                        itemToBeSelected.Selected = true;
                    }
                }
            }

            IDictionary<string, object> attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            foreach (var item in selectList)
            {
                listItemBuilder = new TagBuilder("li");
                spanBuilder = new TagBuilder("label");

                checkBoxBuilder = new TagBuilder("input");
                checkBoxBuilder.MergeAttribute("type", "checkbox");
                checkBoxBuilder.MergeAttribute("name", helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression)));
                checkBoxBuilder.MergeAttribute("value", item.Value);
                checkBoxBuilder.MergeAttributes(attributes);
                if (item.Selected)
                {
                    checkBoxBuilder.MergeAttribute("checked", "checked");
                }

                spanBuilder.InnerHtml += checkBoxBuilder.ToString(TagRenderMode.SelfClosing);
                spanBuilder.InnerHtml += item.Text;

                listItemBuilder.InnerHtml = spanBuilder.ToString(TagRenderMode.Normal);
                listBuilder.InnerHtml += listItemBuilder.ToString();
            }

            container.InnerHtml = listBuilder.ToString();

            return MvcHtmlString.Create(container.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString RadioButtonList<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
        {
            ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            TagBuilder container = new TagBuilder("div");
            TagBuilder listBuilder = new TagBuilder("ul");
            container.AddCssClass("radio-button-list");


            TagBuilder listItemBuilder = null;
            TagBuilder radioButtonBuilder = null;
            TagBuilder radioButtonBuilder2 = null;
            //TagBuilder labelBuilder = null;
            TagBuilder innerYesText = null;
            TagBuilder innerNoText = null;
            TagBuilder divElement = null;
            TagBuilder divElement2 = null;

            selectList = selectList.ToList();

            if (modelMetadata.Model != null)
            {
                foreach (var item in ((IEnumerable)modelMetadata.Model))
                {
                    SelectListItem itemToBeSelected;
                    if ((itemToBeSelected = selectList.FirstOrDefault(x => x.Value.Equals(item.ToString()) || x.Text.Equals(item.ToString()))) != null)
                    {
                        itemToBeSelected.Selected = true;
                    }
                }
            }

            IDictionary<string, object> attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            string inputName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));

            foreach (var item in selectList)
            {
                listItemBuilder = new TagBuilder("li");
                //labelBuilder = new TagBuilder("label");
                innerYesText = new TagBuilder("label");
                innerNoText = new TagBuilder("label");
                divElement = new TagBuilder("div");
                divElement2 = new TagBuilder("div");

                divElement2.InnerHtml += item.Text;

                //innerYesText.InnerHtml += Resources.InfrastructureResources.Yes;
                innerYesText.MergeAttribute("for", item.Value);
                radioButtonBuilder = new TagBuilder("input");
                radioButtonBuilder.MergeAttribute("type", "radio");
                radioButtonBuilder.MergeAttribute("name", inputName + "[" + item.Value + "]");
                radioButtonBuilder.MergeAttribute("value", item.Value);
                radioButtonBuilder.MergeAttribute("id", item.Value);
                radioButtonBuilder.MergeAttributes(attributes);

                //innerNoText.InnerHtml += Resources.InfrastructureResources.No;
                innerNoText.MergeAttribute("for", item.Value + "No");
                radioButtonBuilder2 = new TagBuilder("input");
                radioButtonBuilder2.MergeAttribute("type", "radio");
                radioButtonBuilder2.MergeAttribute("name", inputName + "[" + item.Value + "]");
                radioButtonBuilder2.MergeAttribute("value", "");
                radioButtonBuilder2.MergeAttribute("id", item.Value + "No");
                radioButtonBuilder2.MergeAttributes(attributes);

                if (item.Selected)
                {
                    radioButtonBuilder.MergeAttribute("checked", "checked");
                }
                else
                {
                    radioButtonBuilder2.MergeAttribute("checked", "checked");
                }

                divElement.InnerHtml += radioButtonBuilder.ToString(TagRenderMode.SelfClosing);
                divElement.InnerHtml += innerYesText.ToString(TagRenderMode.Normal);
                divElement.InnerHtml += radioButtonBuilder2.ToString(TagRenderMode.SelfClosing);
                divElement.InnerHtml += innerNoText.ToString(TagRenderMode.Normal);
                listItemBuilder.InnerHtml += divElement2.ToString(TagRenderMode.Normal);
                listItemBuilder.InnerHtml += divElement.ToString(TagRenderMode.Normal);

                //listItemBuilder.InnerHtml = labelBuilder.ToString(TagRenderMode.Normal);
                listBuilder.InnerHtml += listItemBuilder.ToString();
            }

            container.InnerHtml = listBuilder.ToString();

            return MvcHtmlString.Create(container.ToString(TagRenderMode.Normal));
        }
    }
}
