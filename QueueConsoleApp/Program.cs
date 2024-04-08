using AzureStorageLibrary;
using AzureStorageLibrary.Services;
using System.Text;

namespace QueueConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            GetData();   
            Console.ReadLine();
        }

        static async void GetData()
        {
            ConnectionStrings.AzureStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=mystoragestep;AccountKey=0tQssKr+IS9no9mrT4t6Dh7DFSuh0oua+7I0awFAtHp/g3p9H4lL8kR41fKMaY+7oU3gQDse5058+ASt+qKjiA==;EndpointSuffix=core.windows.net";


            AzQueue queue = new AzQueue("testqueue");

            string base64message = Convert.ToBase64String(Encoding.UTF8.GetBytes("Salam Amin"));

            // queue.SendMessageAsync(base64message).Wait();

            //Console.WriteLine("Message Send Queue Successfully");

            var result = await queue.RetrieveNextMessageAsync();
            var message = Encoding.UTF8.GetString(Convert.FromBase64String(result.MessageText));
            Console.WriteLine(message);

            await queue.DeleteMessage(result.MessageId, result.PopReceipt);
            await Console.Out.WriteLineAsync("Message delete from queue");



        }
    }
}
