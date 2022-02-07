using Plugin.Multilingual;
using System;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaterTracker.Localization
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        const string ResourceId = "WaterTracker.Localization.LangResource";

        static readonly Lazy<ResourceManager> resmgr = new Lazy<ResourceManager>(
            () => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text is null)
                return "";
            return resmgr.Value.GetString(Text, CrossMultilingual.Current.CurrentCultureInfo) ?? Text;
        }
    }
}
