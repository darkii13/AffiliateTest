using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Affiliate.AffiliateInterfaceClient client = new Affiliate.AffiliateInterfaceClient();
            client.authenticate("user", "klucz", true, Affiliate.Locale.pl_PL, false);
            ////client.co
            //var aagg = client.getAffiliateSiteTypes();

            var gh = client.getMaterialIncentiveVoucherItems("291450", Affiliate.MaterialOutputType.html, new Affiliate.MaterialItemFilter { sort = Affiliate.MaterialItemSort.ID });
            System.Console.ReadKey();
            client.Close();
            return;

            var aaa = client.getAffiliateSites(new Affiliate.AffiliateSiteFilter { sort = Affiliate.AffiliateSiteSort.ID });

            foreach (var item in aaa)
            {
                Console.WriteLine(item.ID + "   " + item.name + "   " + item.URL);
            }

            Affiliate.Campaign[] ggg = client.getCampaigns("291450", new Affiliate.CampaignFilter { sort = Affiliate.CampaignSort.name });

            foreach (var item in ggg)
            {
                string output = JsonConvert.SerializeObject(item);

                File.AppendAllText(string.Format(@"darek/{0}.json", item.name.Replace("/", "_")), output);
            }

            client.Close();
            System.Console.ReadKey();
        }
    }
}
