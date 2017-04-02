namespace MvcUi.ViewModels
{
    public class Page1Model
    {
        public bool isAutorized { get; internal set; }
        public string UserName { get; internal set; }
        public Page1Model() {
            isAutorized = false;
            UserName = null;
        }
    }
}