using plagiarism.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Sockets;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace plagiarism.Mobile.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        private readonly APIService _historiesService = new APIService("histories");

        public ChatViewModel()
        {
        }
        public string FriendlyName { get; set; }
        public byte[] byteImage { get; set; }
        public string AlbumPath { get; set; }
        public int listSize = 10;
        public async Task Init()
        {
            try
            {
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        public async Task SaveMessage(string message)
        {
            try
            {
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        public string Connect(String server, String message)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 2222;
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                // Close everything.
                stream.Close();
                client.Close();
                return responseData;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
                return "";
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                return "";
            }
        }
    }
}