using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ComboBoxWPF
{
    public class ComboBoxViewModel
    {
        public List<string> giftForCategory { get; set; }
        public List<string> ocassionCategory { get; set; }
        public List<string> sortBy { get; set; }
        public List<int> itemCount { get; set; }
        public ComboBoxViewModel()
        {
            giftForCategory = new List<string>
            {
                "Show All",
                "Him",
                "Her",
                "Teen -> boy",
                "Teen -> girl",
                "Kids -> boy",
                "Kids -> girl",
                "Baby -> boy",
                "Baby -> girl"
            };
            ocassionCategory = new List<string>
            {
            };
            sortBy = new List<string>
            {
                "Price -> Low",
                "Price -> High"
            };
            itemCount = new List<int>
            {
            };
        }
        public ComboBoxViewModel(string obj)
        {
            itemCount = new List<int>
            {
            };
            sortBy = new List<string>
            {
                "Price -> Low",
                "Price -> High"
            };
            giftForCategory = new List<string>
            {
                "Show All",
                "Him",
                "Her",
                "Teen -> boy",
                "Teen -> girl",
                "Kids -> boy",
                "Kids -> girl",
                "Baby -> boy",
                "Baby -> girl"
            };
            if (obj.Contains("Him") || obj.Contains("Her"))
            {
                ocassionCategory = new List<string>
                {
                    "Show All",
                    "Birthday",
                    "Anniversary",
                    "Wedding",
                    "Sports fan",
                    "Graduation"
                };
            }
            else if (obj.Contains("Teen -> boy") || obj.Contains("Teen -> girl"))
            {
                ocassionCategory = new List<string>
                {
                    "Show All",
                    "Birthday",
                    "Anniversary",
                    "Wedding",
                    "Sports fan",
                    "Graduation"
                };
            }
            else if (obj.Contains("Kids -> boy") || obj.Contains("Kids -> girl"))                                 
            {
                ocassionCategory = new List<string>
                {
                    "Show All",
                    "Birthday",
                    "Sports",
                    "Kids Toys"
                };
            }
            else if (obj.Contains("Baby -> boy") || obj.Contains("Baby->girl"))  
            {
                ocassionCategory = new List<string>
                {
                    "Show All",
                    "Birthday",
                    "New Baby Gifts",
                    "Baby Shower"
                };
            }
            else
            {
                ocassionCategory = new List<string> { };
            }
        }
    }
}
