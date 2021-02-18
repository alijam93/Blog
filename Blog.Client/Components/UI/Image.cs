using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Client.Components.UI
{
    public class Image : ComponentBase
    {
        [Parameter] public string Url { get; set; }
        string img;
        private string? _class;

        /// <summary>
        /// Gets or sets a collection of additional attributes that will be applied to the created element.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
        /// <summary>
        /// Gets a CSS class string that combines the <c>class</c> attribute and <see cref="FieldClass"/>
        /// properties. Derived components should typically use this value for the primary HTML element's
        /// 'class' attribute.
        /// </summary>
        //protected string CssCldass
        //{
        //    get
        //    {
        //        if (AdditionalAttributes != null &&
        //            AdditionalAttributes.TryGetValue("class", out var @class) &&
        //            !string.IsNullOrEmpty(Convert.ToString(@class, CultureInfo.InvariantCulture)))
        //        {
        //            return $"{@class} ";
        //        }

        //        return $"{@class} ";
        //    }
        //}


        /// <summary>
        /// Gets or sets the computed CSS class based on whether or not the link is active.
        /// </summary>
        protected string? CssClass { get; set; }

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            // Update computed state
            var href = (string?)null;
            if (AdditionalAttributes != null && AdditionalAttributes.TryGetValue("href", out var obj))
            {
                href = Convert.ToString(obj, CultureInfo.InvariantCulture);
            }

            _class = (string?)null;
            if (AdditionalAttributes != null && AdditionalAttributes.TryGetValue("class", out obj))
            {
                _class = Convert.ToString(obj, CultureInfo.InvariantCulture);
            }

            CssClass = _class;

        }


        ///// <summary>
        ///// Gets or sets the computed CSS class based on whether or not the link is active.
        ///// </summary>
        //[Parameter] public string? CssClass { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "img");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "src", ImageSrc(Url));
            builder.AddAttribute(3, "class", CssClass);
            builder.CloseElement();
        }

        string ImageSrc(string address)
        {
            if (address != null)
            {
                img = address.Trim('"');
            }
            return img;
        }
    }
}
