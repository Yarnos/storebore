namespace AvivaTestIanField.Base
{
    public interface IPage<TM, TV>
        where TM : BasePageElementMap, new()
        where TV : BasePageValidator<TM>, new()
    {
        TV Validate();

        void Navigate(string part = "");
    }
}
