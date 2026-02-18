using System;
using TechVille.Modules; 

namespace TechVille.Services
{ 
    // Class For Updating Values or fields in the Module Classes
    public class CitizenProfileProcess
    {
        // Method To Update Email In The Citizen
        public void UpdateEmail(Citizen citizen,String Email)
        {
            citizen.CitizenEmail = Email;
        }
    }
}