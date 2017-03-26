namespace MvcUi.ViewModels
{
    public class IndexModel
    {
        public bool isAutorized { get; internal set; }
        public string UserName { get; internal set; }
        public IndexModel() {
            isAutorized = false;
            UserName = null;
        }
    }
}