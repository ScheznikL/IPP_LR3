///Програма-сервер містить два вікна edit, у які користувач може уводити свій текст. 
///Програма-клієнт має 2 кнопки, по натисканню однієї з який, клієнт одержує текст відповідного вікна програми-сервера.
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace IPP_LR3_Server
{
    public partial class ServerForm : Form
    {
        private Socket serverSocket;
        private Socket clientSocket;
        private byte[] receivingBuffer;
        private byte[] sendingbuffer = new byte[1];

        public ServerForm()
        {
            InitializeComponent();
            StartServer();
        }

        private static void ShowErrorDialog(string message)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void StartServer()
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, 3333));
                serverSocket.Listen(10);
                serverSocket.BeginAccept(AcceptCallback, null);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        private void AcceptCallback(IAsyncResult AR)
        {
            try
            {
                clientSocket = serverSocket.EndAccept(AR);
                receivingBuffer = new byte[clientSocket.ReceiveBufferSize];
                clientSocket.BeginReceive(receivingBuffer, 0, receivingBuffer.Length, SocketFlags.None, ReceiveCallback, null);
                var responce = Encoding.ASCII.GetString(receivingBuffer).Trim('\0');
                serverSocket.BeginAccept(AcceptCallback, null);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        private void SendCallback(IAsyncResult AR)
        {
            try
            {
                clientSocket.EndSend(AR);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        private void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                int received = clientSocket.EndReceive(AR);
                if (received == 0)
                {
                    return;
                }
                var rec = Encoding.ASCII.GetString(receivingBuffer).Trim('\0');
                if (rec == "Left")
                {
                    sendingbuffer = new byte[tbLeft.Text.Length];
                    sendingbuffer = Encoding.ASCII.GetBytes(tbLeft.Text);
                }
                else if (rec == "Right")
                {
                    sendingbuffer = new byte[tbRight.Text.Length];
                    sendingbuffer = Encoding.ASCII.GetBytes(tbRight.Text);
                }
                Array.Clear(receivingBuffer, 0, receivingBuffer.Length);
                if (sendingbuffer.Length > 1)
                    clientSocket.BeginSend(sendingbuffer, 0, sendingbuffer.Length, SocketFlags.None, SendCallback, null);
                clientSocket.BeginReceive(receivingBuffer, 0, receivingBuffer.Length, SocketFlags.None, ReceiveCallback, null);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverSocket?.Shutdown(SocketShutdown.Both);
            serverSocket?.Close();
            clientSocket?.Shutdown(SocketShutdown.Both);
            clientSocket?.Close();
            Application.Exit();
        }
    }
}
