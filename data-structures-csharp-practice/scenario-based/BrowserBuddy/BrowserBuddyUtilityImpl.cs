namespace BrowserBuddy
{
    class BrowserBuddyUtilityImpl : IBrowserBuddy
    {

        private TabNode currentTab; // private referece for the current tab
        private Stack<string> closedTabs = new Stack<string>();     // maintainig stack to store all closed urls
        


        public void OpenNewTab()    // method to Open new tab
        {
            Console.Write("Enter URL: ");
            string url = Console.ReadLine();

            TabNode tab = new TabNode();
            tab.URL = url;

            if (currentTab != null)     // checking if we already have a open page
            {
                if(currentTab.Next != null)     // checking if the current page has forward pages [ curr <--> next ] 
                {
                    tab.Next = currentTab.Next;     // new tab now point to the next tabs of the current tab  [tab --> next]
                    currentTab.Next.Prev = tab;     // next tab now point to the new tab    [ tab <--> next ]
                }
                currentTab.Next = tab;          // current tab now points next to the new tab [ curr --> tab]
                tab.Prev = currentTab;          // new tab points back to the curr tab  [curr <--> tab ]
            }

            currentTab = tab;         // new tab will be now the curr tab [ curr = tab ]
            Console.WriteLine($"New Page `{url}` Opened");
        }

        public void BackTab()
        {
            if (currentTab == null)     // checking for empty tab
            {
                Console.WriteLine("==> No Page is Opened Right Now");
                return;
            }
            if(currentTab.Prev == null)     // cant back if no previous page
            {
                Console.WriteLine("==> No Previous Page");
                return;
            }
            currentTab = currentTab.Prev;   // current tab now points to the prev tab
            Console.WriteLine($"Back To Previous Page `{currentTab.URL}`");
        }

        public void ForwardTab()
        {
            if (currentTab == null)     // checking for empty tab
            {
                Console.WriteLine("==> No Page is Opened Right Now");
                return;
            }
            if(currentTab.Next == null)     // cant forward if no next page
            {
                Console.WriteLine("==> No Next Page");
                return;
            }
            currentTab = currentTab.Next;   // current tab now points to the next tab
            Console.WriteLine($"Forward To Next Page `{currentTab.URL}`");
        }

        public void CloseTab()
        {
            if (currentTab == null)     // checking for empty tab
            {
                Console.WriteLine("==> No Page is Open Right Now");
                return;
            }

            closedTabs.Push(currentTab.URL);    // pushing closed tab url into stack

            TabNode closedTab = currentTab;

            // for single tab
            if(currentTab.Prev == null && currentTab.Next == null) currentTab = null;

            // For No Next tab
            else if(currentTab.Prev !=null && currentTab.Next == null)
            {
                currentTab = currentTab.Prev;
                currentTab.Next = null;
                closedTab.Prev = null;
            }

            // For No Prev Tab
            else if(currentTab.Prev == null && currentTab.Next != null)
            {
                currentTab = currentTab.Next;
                currentTab.Prev = null;
                closedTab.Next = null;
            }
            // Middle tab
            else
            {
                currentTab.Prev.Next = currentTab.Next;
                currentTab.Next.Prev = currentTab.Prev;
                currentTab = currentTab.Next;

                closedTab.Prev = null;
                closedTab.Next = null;
            }

            closedTab = null;

            Console.WriteLine("==> Tab Closed SuccessFully");
        }

        public void OpenLastClosedTab()
        {
            if(closedTabs.Count==0)
            {
                Console.WriteLine("==> No Closed Tab History Found");
                return;
            }

            TabNode tab = new TabNode();
            tab.URL = closedTabs.Pop();

            if(currentTab==null) currentTab = tab;  // if no tab is open
            else
            {
                currentTab.Next = tab;
                tab.Prev = currentTab;
                currentTab = tab;
            }

            Console.WriteLine($"Page `{tab.URL}` Restored");


        }

    }
}