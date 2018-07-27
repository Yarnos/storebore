using AvivaTestIanField.Core;

namespace AvivaTestIanField.Base

{
    public class BasePage<TM>
        where TM : BasePageElementMap, new()
    {
        protected readonly string Url;

        public BasePage(string url) => Url = url;

        public BasePage() => Url = null;

        protected TM Map
        {
            get
            {
                return new TM();
            }
        }

        public virtual void Navigate(string part = "")
        {
            Driver.Browser.Navigate().GoToUrl(string.Concat(Url, part));
        }
    }

    public class BasePage<TM, TV> : BasePage<TM>
        where TM : BasePageElementMap, new()
        where TV : BasePageValidator<TM>, new()
    {
        public BasePage(string url) : base(url)
        {
        }

        public BasePage()
        {
        }

        public TV Validate()
        {
            return new TV();
        }
    }
}