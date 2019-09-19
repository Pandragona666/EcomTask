using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EcomLocatorV2.Helpers
{
    public class AlternateColorDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EvenTemplate { get; set; }
        public DataTemplate UnevenTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((List<string>)((ListView)container).ItemsSource)
                .IndexOf(item as string) % 2 == 0 ? EvenTemplate : UnevenTemplate;
        }
    }
}
