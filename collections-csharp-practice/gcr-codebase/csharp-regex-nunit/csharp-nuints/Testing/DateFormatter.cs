using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class DateFormatter
    {
        public string FormatDate(string inputDate)
        {
            DateTime parsedDate;

            bool isValid = DateTime.TryParseExact(
                inputDate,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out parsedDate);

            if (!isValid)
            {
                throw new FormatException("Invalid date format. Expected yyyy-MM-dd.");
            }

            return parsedDate.ToString("dd-MM-yyyy");
        }
    }
}
