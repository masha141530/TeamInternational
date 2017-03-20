namespace MvcUi.ViewModels
{
    public class IndexVM
    {
        public bool isAutorized { get; internal set; }
        public string UserName { get; internal set; }
        public IndexVM() {
            isAutorized = false;
            UserName = null;
        }
    }
}