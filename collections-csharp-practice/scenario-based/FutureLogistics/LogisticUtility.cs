using System.Text.RegularExpressions;

namespace FutureLogistics;

class LogisticUtility : ILogistic
{
    public void CreateNewTransport()
    {
        Console.WriteLine("Enter the Goods Transport details\n");
        string input = Console.ReadLine();
        
        GoodsTransport details = ParseDetails(input);
        if(details==null) return;

        bool isValid = ValidateTransportId(details.GetTransportId());
        if(!isValid) return;

        details.DisplayDetails();


    
    }
    public GoodsTransport ParseDetails(string input)
    {
        string[] details = input.Split(":");
        
        GoodsTransport newTransport;
        if (details[3].Equals("BrickTransport", StringComparison.OrdinalIgnoreCase))
        {
            newTransport = new BrickTransport(details[0],details[1],int.Parse(details[2]),float.Parse(details[4]),int.Parse(details[5]),float.Parse(details[6]));
            return newTransport;
        }

        else if(details[3].Equals("TimberTransport", StringComparison.OrdinalIgnoreCase))
        {
            newTransport = new TimberTransport(details[0],details[1],int.Parse(details[2]),float.Parse(details[4]),int.Parse(details[5]),details[6],float.Parse(details[7]));
            return newTransport;
        }

        return null;
    }

    public bool ValidateTransportId (string transportId)
    {
        string rgx = "^RTS[0-9][0-9][0-9][A-Z]$";

        bool isValid =  Regex.IsMatch(transportId,rgx);
        if(!isValid)
        {
            Console.WriteLine($"Transport id <{transportId}> is invalid" + "\nPlease provide a valid record");
        }

        return isValid;
    }


    public string FindObjectType(GoodsTransport goodsTransport)
    {
        if(goodsTransport==null) return null;

        if(goodsTransport is BrickTransport) return "BrickTransport";
        else if(goodsTransport is TimberTransport) return "TimberTransport";
        else return null;
    }


}