namespace BrowserBuddy
{
    interface IBrowserBuddy
    {
        void OpenNewTab();
        void BackTab();
        void ForwardTab();
        void CloseTab();
        void OpenLastClosedTab();
    }
}